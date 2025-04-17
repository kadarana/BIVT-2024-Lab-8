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
        public Blue_1(string input) : base(input) 
        {
            _output = null;
        }
        public string[] Output => _output;

        
        private void AddArrayOutput(string s)
        {
            if (_output == null) _output = new string[1];
            else
            {
                Array.Resize(ref _output, _output.Length + 1);
            }
            _output[_output.Length - 1] = s;
        }

        private string ConvertString(string s)
        {
            if (s == null || s.Length == 0) return null;
            if (s.Length < 50)
            {
                AddArrayOutput(s);
                return null;
            }

            int cnt = 50;
            while (!Char.IsWhiteSpace(s[cnt]) == false) cnt--;


            char[] resArr = new char[cnt];
            char[] strArr = s.ToCharArray();
            Array.Copy(strArr, resArr, cnt);

            string res = new string(resArr);

            AddArrayOutput(res);
            s = s.Remove(0, cnt + 1);
            return s;

        }



        public override void Review()
        {
            string var = Input;
            while (!String.IsNullOrEmpty(var))
                var = ConvertString(var);

        }

        public override string ToString()
        {
            if (_output == null) return null;
            string s = "";
            for (int k = 0; k < _output.Length; k++)
                s += $"{_output[k]}\n";
            s = s.Remove(s.Length - 1, 1);
            return s;
        }


     


       
    }
}
