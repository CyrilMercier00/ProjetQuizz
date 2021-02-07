using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//using System.Windows.Forms;

namespace Quizz_Models.Utils
{
    class GenerateUrl
    {
        public GenerateUrl()
        {
        }

        /// <summary>
        /// Genere un code Alphanuerique unique 
        /// </summary>
        /// <returns></returns>
        public static string GenerateGuid() 
        {
            Guid guid = Guid.NewGuid();
            string rString = Convert.ToBase64String(guid.ToByteArray());
            rString = rString.Replace("=", ""); //remove '='
          //  MessageBox.Show(rString);
            return rString;
         
        }
        /// <summary>
        /// supprime les caractere spéciaux 
        /// </summary>
        /// <param name="input"> chaine de characters avec characters speciaux</param>
        /// <returns>chaine de characters sans characters speciaux</returns>
        public static string RemoveSpecialCharacters(string input)
        {
            Regex r = new Regex( "(?:[^a-zA-Z0-9 ]|(?<=['\"])s)", RegexOptions.IgnoreCase| RegexOptions.CultureInvariant | RegexOptions.Compiled);
            return r.Replace(input, String.Empty);
        }

        /// <summary>
        /// Genere url 
        /// </summary>
        /// <returns>retourne un code unique pour Url du Quizz</returns>
        public static string GenerateCodeUrl()
        {
            string UrlCode = GenerateGuid();
            UrlCode = RemoveSpecialCharacters(UrlCode);
            RemoveSpecialCharacters(UrlCode);
            return UrlCode;
         
        }
       
    }
}
