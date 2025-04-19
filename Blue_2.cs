using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_2 : Blue
    {

        private string _output;
        private string _del;    
        public Blue_2(string input, string del) : base(input)
        {
            _del = del;
            _output = null;
        }
        public string Output => _output;


        private static void ToDelete(ref string str, string del)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(del)) return;
            string[] text = str.Split(' ');

            int newSize = 0;
            for (int i = 0; i < text.Length; i++)
            {
                string s = text[i];
                if (!s.Contains(del))
                {
                    newSize++;
                }
                else
                {
                    if (s.Contains("\""))
                        newSize++;
                }
            }

            string[] newText = new string[newSize];
            int k = 0; 
            // заполнение нового массива удовлетворяющими условие элементами 
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Contains(del))
                {
                    string s = text[i];

                    if (s.Contains("\"") && !s.Contains('.') && !s.Contains(','))
                    {
                        newText[k++] = "\"\"";
                    }
                    else if (s.Contains("\"") && s.Contains('.'))
                    {
                        newText[k++] = "\"\".";
                    }
                    else if (s.Contains("\"") && s.Contains(','))
                    {
                        newText[k++] = "\"\",";
                    }

                    else if (s.Contains('.') && k != 0)
                    {
                        newText[k - 1] += ".";
                    }

                    else if (s.Contains(",") && k != 0)
                    {
                        newText[k - 1] += ",";
                    }


                }
                else newText[k++] = text[i];


            }
            text = newText;  
            str = string.Join(" ", text);

        }


        public override void Review()
        {
            string var = Input;
            ToDelete(ref var, _del);
            _output = var;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(_output))
                return string.Empty;
            return _output;

        }


    }
}
