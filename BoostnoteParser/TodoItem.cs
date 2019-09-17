using System;
using System.Collections.Generic;
using System.Linq;

namespace BoostnoteParser
{
    public class TodoItem
    {
        public bool Completed { get; set; }
        public string Item { get; set; }

        public TodoItem(string str)
        {
            this.Completed = str.Contains("[x]");
            this.Item = str.Substring(str.IndexOf("]") + 1).Trim();
        }

        public override string ToString()
        {
            var str = Completed ? "- [x]" : "- [ ]";
            str = str + $" {Item}";
            str = str.Replace("\r", "").Replace("\n", "");
            return str;
        }
    }
}