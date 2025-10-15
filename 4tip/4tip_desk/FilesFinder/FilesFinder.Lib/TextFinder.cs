using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesFinder.Lib
{
    public class TextFinder
    {
        private string _filePath;
        public List<string> Lines { get; set; }
        public TextFinder(string filePath)
        {
            _filePath = filePath;
            Lines = File.ReadAllLines(_filePath).ToList();
        }
    }
}
