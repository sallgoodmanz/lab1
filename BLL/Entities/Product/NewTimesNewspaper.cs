using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;

namespace BLL.Entities
{
    public class NewTimesNewspaper : INewspaper
    {
        public string Name { get; set; }
        public string EditionNumber { get; set; }
        public NewTimesNewspaper(string name, string editionNumber)
        {
            Name = name;
            EditionNumber = editionNumber;
        }
    }
}
