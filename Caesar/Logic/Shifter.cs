using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesarr
{
    public class Shifter
    {
        readonly string le;

        public Shifter(string m)
        {
            le = m;
        }

        public char Repl(char m, int key) //замена символа m на символ со смещением
        {
            int pos = le.IndexOf(m);
            if (pos == -1) return '\0'; //символ в этой ленте не найден
            pos = (pos + key) % le.Length; //если смещение больше одного круга
            if (pos < 0) pos += le.Length;
            return le[pos];
        }

        public int? CalcKey(char ch1, char ch2)
        {
            int? res = null;
            var p1 = le.IndexOf(ch1);
            var p2 = le.IndexOf(ch2);
            if (p1 >= 0 && p2 >= 0)
            {
                res = ((p2 - p1) + le.Length) % le.Length;
            }
            return res;
        }
    }
}
