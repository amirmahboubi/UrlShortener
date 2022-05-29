using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Core.Application.Helpers
{
    internal class UrlShortenerHelperMethods
    {
        //proof against offensive words (removed 'a', 'e', 'i', 'o' and 'u')
        private const string Alphabet = "0123456789bcdfghijklmnpqrstvwxyzBCDFGHIJKLMNPQRSTVWXYZ-_";
        private static readonly int Base = Alphabet.Length;

        /// <summary>
        /// takes an ID and turns it into a short string
        /// </summary>
        /// <param name="Id">ID number</param>
        /// <returns>short string</returns>
        public static string Encode(long Id)
        {
            StringBuilder stringBuilder = new StringBuilder();
            while (Id > 0)
            {
                stringBuilder.Insert(0, Alphabet.ElementAt((Index)(Id % Base)));
                Id = Id / Base;
            }
            return stringBuilder.ToString();
        }
    }
}
