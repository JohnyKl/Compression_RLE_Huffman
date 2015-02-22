using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZI_lab_1
{
    class RLE
    {
        public static string encode(string text)
        {
            string str1 = text, str = "", ch = "";

            int i, k, j;
            for (i = 0; i < str1.Length; )
            { // от 0 до длины строки
                ch = str1.Substring(i, 1); // получаем текущий символ из строки str1
                k = 0; //счетчик количества повторяющихся символов
                if (i == str1.Length - 1)
                { // если последний символ
                    str += Convert.ToString(ch);
                    break; //выходим из цикла
                }

                if (str1.Substring(i + 1, 1) == ch)
                {
                    for (j = i; j < str1.Length; j++)
                    {
                        if (str1.Substring(j, 1) == ch) //если текущий символ равен символу из строки ch
                            k++; //увеличиваем счетчик
                        else
                            break; //выходим из цикла
                    }
                    i = j;
                }
                else
                    i++;

                if (k != 0)
                    str += Convert.ToString(k) + Convert.ToString(ch);
                else
                    str += Convert.ToString(ch);
            }

            return str;
        }

        public static string decode(string text)
        {
            string str1 = text, str = "", ch = "", s = "", symb = "";
            int i, k = 0, j;
            for (i = 0; i < str1.Length; )
            {
                ch = str1.Substring(i, 1); // текущий символ i
                k = 0;
                s = "";
                if ("0123456789".Contains(ch))
                { // если символ ch является цифрой
                    for (j = i; j < str1.Length; j++)
                    {
                        if ("0123456789".Contains(str1.Substring(j, 1)))
                        { // если текущий символ j является цифрой
                            s += str1.Substring(j, 1);
                        }
                        else
                            break;
                    }
                    symb = str1.Substring(j, 1); // получаем букву
                    i = j + 1;
                }
                else
                    i++;

                if (s.Length != 0)
                {
                    for (j = 0; j < Convert.ToInt32(s); j++) // декодирование буквы
                        str += symb;
                }
                else
                    str += Convert.ToString(ch);
            }
            return str;
        }
    }
}
