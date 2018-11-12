using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastFinder
{
    partial class FastFinder : Form
    {
        private NotifyIcon n;
        public Icon dir = Properties.Resources.dir;
        public Icon file = Properties.Resources.file;

        public FastFinder(FFinder finder = null)
        {
         
            if (finder == null) finder = new FFinder();
            else Load += FastFinder_Load;
            this.finder = finder;
            InitializeComponent();
            locations.Add("a:\\");
            locations.Add("c:\\");
            locations.Add("e:\\");
            locations.Add("d:\\");
            locations.Add("b:\\");
            searchLocations.Text = locations.Aggregate<string, string>(null,
                (current, l) => current == null ? l : current + ";" + l);
            FormClosing += FastFinder_FormClosing;
            size.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Load+=_FastFinder_Load;
        }

        private void _FastFinder_Load(object sender, EventArgs e)
        {
            n = new NotifyIcon();
            n.BalloonTipText = "hellow";
            n.ContextMenuStrip = contextMenuStrip1;
            n.Text = "Joojle";
            n.Visible = true;
            n.BalloonTipIcon = ToolTipIcon.Info;
            n.Icon = Properties.Resources.joojlesearch;
            n.Click += n_Click;
            
                
        }

        void n_Click(object sender, EventArgs e)
        {
            this.Visible = !this.Visible;
        }

        private async void FastFinder_Load(object sender, EventArgs e)
        {
            end = false;
            await Task.Run(() => loadResults());
        }

        private void FastFinder_FormClosing(object sender, FormClosingEventArgs e)
        {
            Marshal.CleanupUnusedObjectsInCurrentContext();
            n.Visible = false;
        }

        private bool end;

        private Task find()
        {
            return Task.Run(() =>
            {
                Invoke(new Action(() => { spanel.Enabled = false; }));
                end = false;
                foreach (var location1 in locations)
                    finder.find(location1.EndsWith("\\") ? location1 : location1 + "\\",
                        new srch(patent.Text) {crt = crt.contain});
                Invoke(new Action(() => { spanel.Enabled = true; }));
                loadResults();
            });
        }

        private void clearRows()
        {
            for (var i = 0; i < nav.Rows.Count; i++)
            {
                var row = nav.Rows[i];
                foreach (DataGridViewCell cell in row.Cells)
                    cell.Dispose();
                row.Dispose();
            }
            GC.SuppressFinalize(nav);
            GC.SuppressFinalize(this);
            GC.RemoveMemoryPressure(Process.GetCurrentProcess().NonpagedSystemMemorySize64);
            nav.Rows.Clear();
        }

        private void loadResults()
        {
            Invoke(new Action(() =>
            {
                Text = finder.i.ToString(CultureInfo.InvariantCulture);
                clearRows();
            }));
            for (var i = 0; i < finder.result.Count; i++)
            {
                var result = finder.result[i];
                for (var j = 0; j < result.files.Count; j++)
                {
                    var _filex = result.files[j];
                    if (end) return;
                    Invoke(new Action<WIN32_FIND_DATA>(_file =>
                    {
                        var row = nav.Rows[nav.Rows.Add()];
                        ((DataGridViewImageCell) row.Cells[0]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                        row.Cells[0].Value = _file.IsDir ? dir : file;
                        row.Cells[1].Value = _file.cFileName;
                        row.Cells[2].Value = _file.Extension;
                        row.Cells[3].Value = result.path;
                        row.Cells[4].Value = _file.Size/1024;
                        row.Cells[5].Value = "KB";
                    }), _filex);
                }
            }
        }

        private void disposeresult()
        {
            for (int i = finder.result.Count - 1; i >= 0; i--)
                finder.result[i].Dispose();
            finder.result.Clear();
        }
        private async void search_Click(object sender, EventArgs e)
        {
            end = true;
            Thread.Sleep(10);
            locations.Clear();
            locations.AddRange(searchLocations.Text.Split(new[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries));
            disposeresult();
            await find();
        }

        public FFinder finder;

        private readonly List<string> locations = new List<string>();

        private void browser_Click(object sender, EventArgs e)
        {
            var fb = new FolderBrowserDialog();
            fb.ShowDialog();
            searchLocations.Text = fb.SelectedPath;
            locations.Clear();
            locations.Add(fb.SelectedPath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fb = new FolderBrowserDialog();
            fb.ShowDialog();
            locations.Add(fb.SelectedPath);
            searchLocations.Text = locations.Aggregate<string, string>(null,
                (current, l) => current == null ? l : current + ";" + l);
        }


        private static void open(string path)
        {
            try
            {

                var pi = new ProcessStartInfo(@"c:\Windows\explorer.exe", "\"" + path + "\"")
                {
                    CreateNoWindow = true,
                    Verb = "open",
                    WorkingDirectory = Path.GetTempPath()
                };
                Process.Start(pi);
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message, es.HelpLink);
            }
        }

        private void nav_CellDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var row = nav.Rows[e.RowIndex];
            var arguments = ((string) row.Cells[3].Value) + (string) row.Cells[1].Value;
            open(arguments);
        }

        private void nav_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Home)
            {
                if (e.Control && e.Shift)
                {
                    if (nav.SelectedRows.Count <= 0) return;
                    for (var i = 0; i < nav.SelectedRows[0].Index; i++)
                        nav.Rows[i].Selected = true;
                }
                else
                {
                    nav.ClearSelection();
                    if (nav.RowCount > 0)
                        nav.Rows[0].Selected = true;
                }
            }
            else if (e.KeyCode == Keys.End)
            {
                if (e.Control && e.Shift)
                {
                    if (nav.SelectedRows.Count <= 0) return;
                    for (var i = nav.RowCount; i > nav.SelectedRows[nav.SelectedRows.Count - 1].Index; i++)
                        nav.Rows[i].Selected = true;
                }
                else
                {
                    nav.ClearSelection();
                    if (nav.RowCount > 0)
                        nav.Rows[nav.RowCount - 1].Selected = true;
                }
            }

        }

        private void nav_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void patent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                search_Click(null, null);
        }

        private void openFileLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nav.SelectedRows.Count == 0) return;
            var c = nav.SelectedRows[0];
            open((string) c.Cells[3].Value);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nav.SelectedRows.Count == 0) return;
            var c = nav.SelectedRows[0];
            var arguments = ((string) c.Cells[3].Value) + (string) c.Cells[1].Value;
            open(arguments);
        }

        private void addToFavoriteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nav.SelectedRows.Count == 0) return;
            var c = nav.SelectedRows[0];
            var arguments = ((string) c.Cells[3].Value) + (string) c.Cells[1].Value;
            Clipboard.SetFileDropList(new StringCollection {arguments});
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nav.SelectedRows.Count == 0) return;
            var c = nav.SelectedRows[0];
            var arguments = ((string) c.Cells[3].Value) + (string) c.Cells[1].Value;
            if (
                MessageBox.Show("Are you sure ,you want delete this file ?", "Confirmation", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                File.Delete(arguments);
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fd = new SaveFileDialog
            {
                DefaultExt = "jsr",
                AddExtension = false,
                SupportMultiDottedExtensions = false,
                Filter = "Joojle Searche Record|*.jsr"
            };
            var dialogResult = fd.ShowDialog();
            if (dialogResult == DialogResult.OK || dialogResult == DialogResult.Yes)
                finder.Save(fd.FileName);
        }

        private async void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog()
            {
                DefaultExt = "jsr",
                AddExtension = false,
                SupportMultiDottedExtensions = false,
                Filter = "Joojle Searche Record|*.jsr"
            };
            var dialogResult = fd.ShowDialog();
            if (dialogResult == DialogResult.OK || dialogResult == DialogResult.Yes)
            {
                var xr = FFinder.Open(fd.FileName);
                if (xr == null) return;
                finder.Dispose();
                finder = xr;
                end = false;
                await Task.Run(() => loadResults());
            }

        }
    }
}