using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_3 : Blue
    {
    
        // Определить долю (в процентах) слов, начинающихся на различные буквы. Выписать эти буквы и доли начинающихся на них слов.
        //Свойство Output должно возвращать массив кортежей (символ в нижнем регистре, вещественное число), отсортированный по убыванию доли слов.
        //При равенстве долей сортировать по буквы по алфавиту. Метод ToString() должен возвращать построчно пары символа и вещественного числа, разделенных “-”.
         
        private (char, double)[] _output;
        public (char, double)[] Output => _output;

        public Blue_3(string input) : base(input)
        {
            _output = null;
        }
       

        
        private (char, double)[] Alpha(string str)
        {
            //string alph = "яюэьыъщшчцхфутсрпонмлкйизжёедгвбаzyxwvutsrqponmlkjihgfedcba";
            //string text = str.ToLower();
            //char[] punctuation = { ' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };
            //string[] words = str.Split(punctuation, StringSplitOptions.RemoveEmptyEntries);

            //(char, double)[] array = new (char, double)[0];
            //int totalWords = words.Length;

            //foreach (char i in alph)
            //{
            //    int c = 0;
            //    foreach (string word in words)
            //    {

            //        if (word.Length > 0 && word[0] == i)
            //        {
            //            c += 1;
            //        }

            //    }
            //    if (c > 0)
            //    {
            //        double pers = Math.Round((double)c / totalWords * 100, 4);
            //        Array.Resize(ref array, array.Length + 1);
            //        array[array.Length - 1] = (i, pers);
            //    }
            //}
            //return array;
            char[] punctuation = { ' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };
            string[] words = str.Split(punctuation, StringSplitOptions.RemoveEmptyEntries);

            int[] letters = new int[1104];
            bool[] used = new bool[1104];
            int totalWords = 0;

            foreach (string word in words)
            {
                string w = word.ToLower();
                if (string.IsNullOrWhiteSpace(w)) continue;

                char firstChar = w[0];
                if (char.IsLetter(firstChar))
                {
                    int index = (int)firstChar;
                    letters[index]++;
                    used[index] = true;
                    totalWords++;
                }
            }

            (char, double)[] result = new (char, double)[totalWords];
            int count = 0;

            for (int i = 0; i < letters.Length; i++)
            {
                if (used[i])
                {
                    char letter = (char)i;
                    double percent = Math.Round(letters[i] * 100.0 / totalWords, 4);
                    result[count++] = (letter, percent);
                }
            }

            Array.Resize(ref result, count);
            return result;
        }

        private void Sort(ref (char, double)[] array)
        {
            if (array == null || array.Length == 0) return;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j].Item2 < array[j+1].Item2 || (array[j].Item2 == array[j + 1].Item2 && array[j].Item1 > array[j+1].Item1))
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }

                }
            }
        }
        public override void Review()
        {
            string str = Input;
            _output = Alpha(str);
            Sort(ref _output);
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0) return "";

            var sb = new System.Text.StringBuilder();

            foreach (var (alph, cnt) in _output)
            {
                sb.AppendLine($"{alph} - {cnt:0.0000}");
            }

            return sb.ToString().TrimEnd(); 
        }
    }
}
