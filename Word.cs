using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    internal class Word
    {
        public string lan1 { get; set; }
        public List<string> lan2 { get; set; }
        public Word()
        {
            lan2 = new List<string>();
        }

        public void ShowTranslates()
        {
            for(int i = 0; i < lan2.Count; i++)
            {
                Console.WriteLine($"{i} - {lan2[i]}");
            }
        }
    }
}
