using System;

namespace FastFinder
{
    class srch
    {
        public crt crt;
        public readonly string val;
        public crtlg addition;
        public sv addition_aux;
        public srch next_srch;

        public srch(string val)
        {
            this.val = val;
        }

        public bool match(string s, int si=0)
        {
            var and = (addition & crtlg.and) == crtlg.and;
            var not = (addition & crtlg.not) == crtlg.not;
            var l = false;
            switch (crt)
            {
                case crt.startwith:
                    l = s.StartsWith(val, StringComparison.OrdinalIgnoreCase);
                    break;
                case crt.contain:
                    l = s.IndexOf(val, StringComparison.OrdinalIgnoreCase) != -1;
                    break;
                case crt.endwith:
                    l = s.EndsWith(val, StringComparison.OrdinalIgnoreCase);
                    break;
            }
            if (next_srch == null) return l;
            if (and)
                if (!l) return false;
                else {}
            else if (l)
                return true;            
            var b = next_srch.match(s, si);
            return not ? !b : b;
        }
    }
}