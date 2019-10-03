using System;
using System.Collections.Generic;
using System.Linq;

namespace NotableParser
{
    public class TodoItem
    {
        private object str;

        public bool Completed { get; set; }
        public string Item { get; set; }
        public string FileCode { get; }

        public TodoItem(string str, string fileCode) : this(str)
        {
            this.FileCode = fileCode;
        }

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

            if (String.IsNullOrEmpty(FileCode)) return str;
            return $"{str} *({FileCode})*";
        }
    }
}