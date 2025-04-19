using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_4 : Blue
    {
        /*
        Текст содержит слова и целые числа произвольного порядка. Найти сумму включенных в текст чисел. 
        Свойство Output должно возвращать целое число, а метод ToString() должен возвращать это число в качество строки. 
        Запрещено использовать методы конвертации (например: TryParse).
         */

        private int _output;
        public int Output => _output;


        public Blue_4(string input) : base(input)
        {
            _output = 0;
        }

        private int FindSum(string str)
        {
            if (str == null || str.Length == 0) return 0;
            string[] text = str.Split(' ');
            int sum = 0;
            int num = 0;
            bool wasDigit = true;
            foreach (char word in str)
            {
                 
                if (char.IsDigit(word))
                {
                    num = num * 10 + (word - '0'); 
                    wasDigit = true;
                }
                else 
                {
                    sum += num;
                    num = 0;
                    wasDigit = false;
                }
            }
            if (wasDigit) sum += num;
            return sum;
           
        }
       

        public override void Review()
        {
            string text = Input;
            _output = FindSum(text);
        }

        public override string ToString()
        {
            // string message = $"Мой возраст: {age}"; 
            string result = $"{_output}";
            return result;
            
        }
    }
}
