using System;
using System.Text.RegularExpressions;

namespace BoostnoteParser
{
    public class DefnItem
    {
        public string Defintion { get; private set; }
        public string Word { get; private set; }

        public DefnItem(string str)
        {
            this.Defintion = str;

        }
    }
}