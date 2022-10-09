using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;

namespace Caesarr
{
    public class FrequencyAnalysis
    {
        private readonly Dictionary<char, float> statistics;
        private float letters;
        public FrequencyAnalysis()
        {
            statistics = new Dictionary<char, float>();
        }
        public void CalcStat(string text)
        {
            statistics.Clear();
            text = text.ToLower();
            for (int i = 0; i < text.Length; i++)
            {
                if (!char.IsLetter(text[i]))
                    continue;
                if (statistics.ContainsKey(text[i]))
                {
                    statistics[text[i]] += 1;
                }
                else
                {
                    statistics[text[i]] = 1;
                }
            }
            letters = statistics.Sum(a => a.Value);
        }

        public float GetStatByChar(char sq)
        {
            if (!statistics.ContainsKey(Char.ToLower(sq))) 
                return -1;
            return statistics[Char.ToLower(sq)]/letters;
        }

        public char GetCharByStat(float x)
        {
            float min = 99999;
            char back = '\0';
            foreach (var element in statistics)
            {
                if (Math.Abs(element.Value / letters - x) < min) 
                {
                    min = Math.Abs(element.Value / letters - x);
                    back = element.Key;
                }
            }
            return back;

        }
    }
}
