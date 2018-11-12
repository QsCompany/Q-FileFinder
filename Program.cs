using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32.SafeHandles;
using System.Linq;
namespace FastFinder
{
    internal class Dictionary<k, v>:IDisposable
    {
        internal class KeyValuePair<k, v>:IDisposable
        {
            public readonly k Key;
            public v Value;

            public KeyValuePair(k key,v val)
            {
                Key = key;
                Value = val;
            }

            public void Dispose()
            {
                if (Key is IDisposable) ((IDisposable)Key).Dispose();
                if (Value is IDisposable) ((IDisposable)Value).Dispose();
                GC.SuppressFinalize(Key);
                GC.SuppressFinalize(Value);
                GC.SuppressFinalize(this);
            }
        }
        private KeyValuePair<k, v>[] lst;
        private readonly int _capacity;
        private int cur = -1;
        public int Length{get { return cur + 1; }}
        public Dictionary(int capacity)
        {
            lst = new KeyValuePair<k, v>[_capacity = capacity];
        }

        public void add(k key, v val)
        {
            if (cur >= lst.Length) expand();
            lst[++cur] = new KeyValuePair<k, v>(key, val);
        }

        private void expand()
        {
            var t = new KeyValuePair<k, v>[lst.Length + _capacity];
            Array.Copy(lst, t, lst.Length);
            lst = t;
            GC.WaitForPendingFinalizers();
        }

        public KeyValuePair<k,v> this[int i]
        {
            get { return lst[i]; }
        }
        public v this[k key]
        {
            get
            {
                for (int i = cur; i >= 0; i--)
                {
                    var kv = lst[i];
                    if (kv.Key.Equals(key)) return kv.Value;
                }
                return default(v);
            }
            set
            {
                for (int i = cur; i >= 0; i--)
                {
                    var kv = lst[i];
                    if (kv.Key.Equals(key))
                    {
                        kv.Value = value;
                        return;
                    }
                }
            }
        }


        public void Dispose()
        {
            for (int i = 0; i <= cur; i++)
            {
                var kv = lst[i];
                kv.Dispose();
            }
            GC.SuppressFinalize(lst);
            GC.SuppressFinalize(this);
        }
    }

    enum crt
    {
        contain = 0,
        startwith = 1,
        endwith = 2,
    }

    [Flags]
    enum crtlg
    {
        or = 0,
        and = 1,
        not = 2,
    }

    enum sv
    {
        continuedby,
        anywhere,
    }

    [Serializable]
    class rslts:IDisposable
    {
        public readonly string path;
        public List<WIN32_FIND_DATA> files = new List<WIN32_FIND_DATA>();
        public rslts(string path)
        {
            this.path = path;
        }

        #region Implementation of IDisposable

        public void Dispose()
        {
            GC.SuppressFinalize(this.path);
            var count = files.Count;
            for (int i = 0; i < count; i++)
            {
                var win32FindData = files[i];
                win32FindData.Dispose();
            }
            GC.SuppressFinalize(this.files);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
    [Serializable]
    class FFinder:IDisposable
    {
        private readonly Stack<string> stack = new Stack<string>(4096);
        public List<rslts> result = new List<rslts>(65536);
        private const int nt = 1;
        public int i;

        public int find(string path,srch srch)
        {
            Console.WriteLine("searche for {0} at {1}", srch.val, path);
            stack.Push(path);
            if (threads.Count == 0)
            {
                for (int i1 = 0; i1 < nt; i1++)
                {
                    var x = new Thread(e =>
                    {
                        sleep.add(Thread.CurrentThread, false);
                        var m = _find(srch);
                        Console.WriteLine("i: {0};\t m:{1}", i, m);
                    });
                    threads.Add(x);
                }
                foreach (var thread in threads)
                {
                    thread.Start();
                }
                threads.Add(Thread.CurrentThread);
                sleep.add(Thread.CurrentThread, false);
            }
            var mm = _find(srch);
            Console.WriteLine("i: {0};\t m:{1}", i, mm);
            return i;
        }
        [NonSerialized] internal List<Thread> threads=new List<Thread>();
        [NonSerialized]
        private Dictionary<Thread, bool> sleep = new Dictionary<Thread, bool>(5);
        private string get()
        {
            if (stack.Count == 0) return null;
            return stack.Pop();
        }

        private bool isallsleep()
        {
            lock (sleep)
            {
                for (int i = sleep.Length - 1; i >= 0; i--)
                {
                    if (!sleep[i].Value) return false;
                }
                return true;
            }
        }

        public bool waiting
        {
            get { return sleep[Thread.CurrentThread]; }
            private set { sleep[Thread.CurrentThread] = value; }
        }

        private int _find(srch srch)
        {
            int i = 0;
            string s;
            var data = new WIN32_FIND_DATA();
           
        deb:
            string path = null;
            lock (stack)
                if (stack.Count == 0)
                    if (isallsleep())
                        return i;
                    else
                    {
                        waiting = true;
                        Thread.Sleep(1);
                        goto deb;
                    }
                else
                    path = stack.Pop();
            if (path == null)
                goto deb;
            waiting = false;
            rslts rslt = null;
            var ff = Win32Native.FindFirstFile(path + "*", data);
            if (!ff.IsInvalid)
            {
                do
                {
                    if (!data.IsFileOrDir) continue;
                    s = data.cFileName;
                    if (data.IsDir) stack.Push(string.Concat(path, data.cFileName, "\\"));
                    if (srch.match(s))
                    {
                        this.i++;
                        if (rslt == null) rslt = new rslts(path);
                        rslt.files.Add(data);
                        data = new WIN32_FIND_DATA();
                    }
                    
                } while (Win32Native.FindNextFile(ff, data));
            }
            if (rslt != null) result.Add(rslt);
            goto deb;
        }

        private int getBuffer()
        {
            var s = 0;
            for (int k = result.Count - 1; k >= 0; k--)
            {
                var c = result[k];
                s += c.path.Length*2;
                for (int j = c.files.Count - 1; j >= 0; j--)
                    s += c.files[j].cFileName.Length*2;
            }
            return s;
        }
        public void Save(string path)
        {
            var b = new BinaryFormatter
            {
                FilterLevel = TypeFilterLevel.Full,
                TypeFormat = FormatterTypeStyle.TypesWhenNeeded
            };

            using (var x = File.Create(path, getBuffer()))
            {
                b.Serialize(x, this);
            }
        }

        public static FFinder Open(string path)
        {

            try
            {
                var b = new BinaryFormatter
                {
                    FilterLevel = TypeFilterLevel.Full,
                    TypeFormat = FormatterTypeStyle.TypesWhenNeeded
                };
                object deserialize;
                using (var x = File.Open(path, FileMode.Open, FileAccess.Read))
                    deserialize = b.Deserialize(x);
                var f = deserialize as FFinder;
                f.threads = new List<Thread>();
                f.sleep = new Dictionary<Thread, bool>(5);
                return f;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            for (int i = result.Count - 1; i >= 0; i--)
                result[i].Dispose();
            foreach (var thread in threads)
            {
                if (thread != Thread.CurrentThread)
                {
                    thread.Abort();
                    GC.SuppressFinalize(thread);
                }
            }
            GC.SuppressFinalize(stack);
            GC.SuppressFinalize(result);
            GC.SuppressFinalize(threads);
            sleep.Dispose(); GC.SuppressFinalize(this);
            
        }
    }
    
    internal class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            var dr = new DirectoryInfo(@"D:\Program Files\");
            foreach (var item in dr.GetDirectories())
            {
                try
                {
                    item.Delete(true);
                }
                catch (Exception)
                {
                    Console.WriteLine("deleted????");
                    item.SetAccessControl(new System.Security.AccessControl.DirectorySecurity("everyone", System.Security.AccessControl.AccessControlSections.All));

                }
        
                var x = item.Name.ToCharArray();
                foreach (var c in x)
                {
                    Console.WriteLine("{0}==>{1}", (int)c, c);
                }
            }
            FFinder fFinder = null;
            foreach (string s in args)
            {
                MessageBox.Show(s);
                var f = new FileInfo(s);
                if (f.Extension == ".jsr" && f.Exists)
                {
                    fFinder = FFinder.Open(s);
                    break;
                }
            }
            Application.Run(new FastFinder(fFinder));
        }
    }
}

[Serializable, StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto), BestFitMapping(false)]
class WIN32_FIND_DATA:IDisposable
{
    internal FileAttributes dwFileAttributes;
    internal uint ftCreationTime_dwLowDateTime;
    internal uint ftCreationTime_dwHighDateTime;
    internal uint ftLastAccessTime_dwLowDateTime;
    internal uint ftLastAccessTime_dwHighDateTime;
    internal uint ftLastWriteTime_dwLowDateTime;
    internal uint ftLastWriteTime_dwHighDateTime;
    internal int nFileSizeHigh;
    internal int nFileSizeLow;
    internal int dwReserved0;
    internal int dwReserved1;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1260)] internal string cFileName;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1114)] internal string cAlternateFileName;
    private string _extention;

    public long Size
    {
        get { return (long)nFileSizeHigh << 0x20 | nFileSizeLow; }
    }
    
    internal bool IsDir
    {
        [SecurityCritical]
        get { return ((((dwFileAttributes & FileAttributes.Directory ) != 0) && !cFileName.Equals(".")) && !cFileName.Equals("..")); }
    }

    
    internal bool IsFile
    {
        [SecurityCritical]
        get { return ((dwFileAttributes & FileAttributes.Directory) == 0); }
    }

    public bool IsFileOrDir
    {
        get { return !cFileName.Equals(".") && !cFileName.Equals(".."); }
    }

    public string Extension
    {
        get
        {
            var lastIndexOf = cFileName.LastIndexOf('.');
            return IsDir ? " Directory" : (lastIndexOf == -1 ? " File" : cFileName.Substring(lastIndexOf + 1));
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this.cFileName);
        GC.SuppressFinalize(this.cAlternateFileName);
        GC.SuppressFinalize(this);
    }
}

static class Win32Native
{

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false)]
    internal extern static SafeFindHandle FindFirstFile(string fileName, [In, Out] WIN32_FIND_DATA data);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false)]
    internal extern static bool FindNextFile(SafeFindHandle hndFindFile, [MarshalAs(UnmanagedType.LPStruct), In, Out] WIN32_FIND_DATA lpFindFileData);

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    [DllImport("kernel32.dll")]
    internal extern static bool FindClose(IntPtr handle);
    
    [DllImport("kernel32.dll", SetLastError = true)]
    internal extern static int GetFileSize(SafeFileHandle hFile, out int highSize);
    
   

    [SecurityCritical]
    internal sealed class SafeFindHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        [SecurityCritical]
        internal SafeFindHandle()
            : base(true)
        {
        }

        [SecurityCritical]
        protected override bool ReleaseHandle()
        {
            return FindClose(handle);
        }

    }
}

