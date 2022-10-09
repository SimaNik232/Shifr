using System;
using System.Collections.Generic;
using System.Text;

namespace Caesarr
{

    public class Caesar
    {
        private List<Shifter> dictinary;
        public Caesar()
        {
            dictinary = new List<Shifter>
            {
                new Shifter("abcdefghijklmnopqrstuvwxyz"),
                new Shifter("ABCDEFGHIJKLMNOPQRSTUVWXYZ"),
                new Shifter("абвгдеёжзийклмнопрстуфхцчшщъыьэюя"),
                new Shifter("АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ"),
                new Shifter("0123456789"),
                //new Shifter("!\"\\#$%^&*()+=-_'?.,|/`~№:;@[]{}")
            };
        }
    
        public string Code(int key, string text)
        {
            StringBuilder res = new StringBuilder("", text.Length);
            char tmp = '\0';
            for (int i = 0; i < text.Length; i++)
            {
                foreach (Shifter lenta in dictinary)
                {
                    tmp = lenta.Repl(text[i], key);
                    if (tmp != '\0') //нужная лента найдена, замена символу определена
                    {
                        res.Append(tmp);
                        break; // прерывается foreach (перебор лент)
                    }
                }
                if (tmp == '\0') res.Append(text[i]); //незнакомый символ оставляю без изменений
            }
            return res.ToString();
        }
        public int? CalcKey(char ch1, char ch2)
        {
            int? razn = null;
            foreach (Shifter lenta in dictinary)
            {
                razn = lenta.CalcKey(ch1, ch2);
                if (razn.HasValue)
                    break;
            }
            return razn;
        }
    }
}
