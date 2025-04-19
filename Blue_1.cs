using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    // наследник класса Blue 
    public class Blue_1 : Blue
    {
        private string[] _output;
        public string[] Output => _output;

        public Blue_1(string input) : base(input)
        {
            _output = null;
        }

        // Статический вспомогательный метод для добавления строки в массив строк
        private static void Add(ref string[] strings, string str)
        {
            if (strings == null || string.IsNullOrEmpty(str)) return;
            // Создаётся новый массив на один элемент больше
            string[] newStrings = new string[strings.Length + 1]; // Копируются старые значения
            Array.Copy(strings, newStrings, strings.Length);
            newStrings[strings.Length] = str;
            strings = newStrings;
        }


        // Метод разбивает исходную строку на подстроки длиной не более 50 символов, не разрывая слова
        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = null;
                return;
            }

            _output = Input.Split(' '); // Разбиваем входную строку на слова
            string[] res = new string[0]; // Результирующий массив строк
            int counter = 0;
            for (int i = 0; i < _output.Length;)
            {
                string p = "";
                counter = _output[i].Length;
                // Пока общая длина слов в строке не превышает 50 символов
                while (counter <= 50)
                {
                    p += _output[i++] + " "; // Добавляем слово с пробелом
                    if (i != _output.Length)
                        counter += _output[i].Length + 1; // Учитываем длину следующего слова и пробел
                    else break;
                }

                Add(ref res, p.Substring(0, p.Length - 1));
                
            }
            _output = res;

        }


        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
                return string.Empty;
            return string.Join(Environment.NewLine, _output); // Объединяем строки с переводом строки между ними
        }

    }
}
