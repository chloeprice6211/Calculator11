using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork
{ // класс для римских чисел
    public class Rumnumber
    {
        // Одержання числа з рядкового запису
        public static int Parse(String str)
        {

            if (str.Contains('N') && str.Length > 1)
            {
                throw new ArgumentException("Only 1 N is allowed!");
            }

            char[] digits = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
            int[] digitValues = { 1, 5, 10, 50, 100, 500, 1000 };
            // Якщо наступна цифра числа більша за поточну, то
            // вона віднімається від результату, інакше додається
            // IX : -1 + 10;  XC : -10 + 100;  XX : +10+10; CX : +100+10
            // XIV : +10-1+5; XIIII : 10+1+1+1+1

            int pos = str.Length - 1;  // позиція останньої цифри числа
            char digit = str[pos];     // символ цифри
            int ind = Array.IndexOf(digits, digit);  // позиція цифри у масиві
            if (ind == -1)
            {
                throw new ArgumentException($"Invalid char {digit}");
            }
            int val = digitValues[ind];  // величина цифри
            int res = val;
            int nextDigitVal = val;
            while (pos > 0)
            {
                pos -= 1;  // передостання цифра у числі
                           // Визначаємо величину цифри
                           // порівнюємо з наступною (останньою) цифрою (одержана вище)
                           // додаємо або віднімаємо в залежності від рез. порівняння
                           // продовжуємо доки pos не дійде до 0
                digit = str[pos];     // символ цифри
                ind = Array.IndexOf(digits, digit);  // позиція цифри у масиві
                if (ind == -1)
                {
                    throw new ArgumentException($"Invalid char {digit}");
                }
                val = digitValues[ind];  // величина цифри
                res += (val < nextDigitVal)
                        ? -val
                        : val;
                nextDigitVal = val;
            }
            return res;
        }
    }
}
