using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesarr
{
    public class Decrypter
    {
        FrequencyAnalysis LearnAnalysis;
        FrequencyAnalysis WorkAnalysis;
        public Decrypter()
        {
            LearnAnalysis = new FrequencyAnalysis();
            WorkAnalysis = new FrequencyAnalysis();
        }

        public void Learn(string text)
        {
            LearnAnalysis.CalcStat(text);
        }
        public string DecryptWork(string text, Caesar c)
        {
            var key = DecryptKey(text, c);
            return c.Code(key, text);

            /*StringBuilder res = new StringBuilder(text);
            for (int i = 0; i < text.Length; i++)
            {
                if (!char.IsLetter(res[i]))
                    continue;
                float work = WorkAnalysis.GetStatByChar(res[i]);
                char str = LearnAnalysis.GetCharByStat(work);
                res[i] = str;
            }
            return res.ToString();*/
        }

        public int DecryptKey(string text, Caesar c)
        {
            var keys = new List<int?>();
            WorkAnalysis.CalcStat(text);
            float work;
            char str;
            for (int i = 0; i < text.Length; i++)
            {
                if (!char.IsLetter(text[i]))
                    continue;
                work = WorkAnalysis.GetStatByChar(text[i]);
                str = LearnAnalysis.GetCharByStat(work);
                keys.Add(c.CalcKey(char.ToLower(text[i]), char.ToLower(str)));
            }
            
            var gr = keys.GroupBy(x=>x).OrderByDescending(y=>y.Count()).First();
            return gr.Key.GetValueOrDefault(0);

        }
    }
}
