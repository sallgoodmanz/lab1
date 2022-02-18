using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public static class MyRegEx
    {

        public static readonly Regex Name = new Regex("^[а-яА-ЯіїйЇІЙ]{0,20}$");

        public static readonly Regex Surname = new Regex("^[а-яА-ЯіїйЇІЙ]{0,20}$");

        public static readonly Regex EditionNumber = new Regex("[0-9]{3}");
    }
}
