using Microsoft.AspNetCore.DataProtection.KeyManagement;
using static System.Net.Mime.MediaTypeNames;

namespace SzyfrCezaraASP.NET.Models
{
    public class SzyfrCezara
    {
        public SzyfrCezara()
        { 
        
        }

        public string Szyfruj(string tekst, int klucz)
        {
            tekst = RemoveWhitespaceAndPunctuation(tekst);

            char[] alfabetPolski = { 'a', 'ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'ł', 'm', 'n', 'ń', 'o', 'ó', 'p', 'q', 'r', 's', 'ś', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'ź', 'ż' };

            char[] result = new char[tekst.Length];
            for (int i = 0; i < tekst.Length; i++)
            {
                char c = tekst[i];
                if (char.IsLetter(c))
                {
                    int index = Array.IndexOf(alfabetPolski, c);
                    int newIndex = (index + klucz) % alfabetPolski.Length;
                    result[i] = alfabetPolski[newIndex];
                }
                else
                {
                    result[i] = c;
                }
            }
            return new string(result);
        }

        public string DeSzyfruj(string tekst, int klucz)
        {
            tekst=RemoveWhitespaceAndPunctuation(tekst);
                char[] alfabetPolski = { 'a', 'ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'ł', 'm', 'n', 'ń', 'o', 'ó', 'p', 'q', 'r', 's', 'ś', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'ź', 'ż' };

                char[] result = new char[tekst.Length];
                for (int i = 0; i < tekst.Length; i++)
                {
                    char c = tekst[i];
                    if (char.IsLetter(c))
                    {
                        int index = Array.IndexOf(alfabetPolski, c);
                        int newIndex = (index - klucz + alfabetPolski.Length) % alfabetPolski.Length; // Zmniejsz indeks litery (lewo)
                        result[i] = alfabetPolski[newIndex];
                    }
                    else
                    {
                        result[i] = c;
                    }
                }
                return new string(result);
            
        }

        private string RemoveWhitespaceAndPunctuation(string input)
        {
            input = input.ToLower();
            string result = string.Join("", input.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
            return new string(result.ToCharArray().Where(c => !char.IsPunctuation(c)).ToArray());
        }
    }
}
