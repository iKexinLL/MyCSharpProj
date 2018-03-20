using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App1
{
    public class ContentOfArticle
    {
        private static List<char> GetChars
        {
            get
            {
                List<char> lt = new List<char>();
                int cStart = 97;
                int cEnd = 122;

                while (cStart <= cEnd)
                {
                    lt.Add((char)cStart);
                    cStart++;
                }

                lt.Add(',');
                lt.Add('.');
                lt.Add('!');
                lt.Add('?');
                lt.Add(' ');

                return lt;
            }
        }

        public static string GetArticle()
        {
            StringBuilder sb = new StringBuilder();
            Random random = new Random();

            List<char> lt = GetChars;
            
            for (int i = 0; i < 600; i++)
            {
                int index = random.Next(0, lt.Count());
                sb.Append(lt[index]);
            }

            return sb.ToString();
        }
    }
}
