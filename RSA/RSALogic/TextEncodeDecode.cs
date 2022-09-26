using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSALogic
{
    //ASCII only
    public static class TextEncodeDecode
    {


        public static string DecodeMessage(int encodedText)
        {
            StringBuilder sb = new StringBuilder("", 20);
            string encodedTextStr = encodedText.ToString();
            for (int i = encodedTextStr.Length - 2; i >= 0; i-=2)
            {
                //Convert.ToChar(Int16.Parse(s));
                char c = (char)int.Parse(encodedTextStr.Substring(i, 2));
                sb.Append(c);
            }
            return sb.ToString();
        }
        public static int EncodeMessage(string rawText)
        {
            StringBuilder sb = new StringBuilder("", 10);
            for (int i = 0; i < rawText.Length; i++)
            {
                char c = rawText[i];
                int ascii = (int)c;

            sb.Append(ascii.ToString());
            }
            return int.Parse(sb.ToString());
        }

        public static int IntLength(int i)
        {
            if (i <= 0) throw new ArgumentOutOfRangeException();

            return (int)Math.Floor(Math.Log10(i)) + 1;
        }
    }
}
