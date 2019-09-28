using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BoostnoteParser
{
    internal class DefnParser
    {
        private string defnNotePath;
        public List<DefnItem> Definitions { get; private set; }
        public List<string> StringList { get; private set; }

        public DefnParser()
        {
            this.Definitions = new List<DefnItem>();
        }

        public DefnParser(string defnNotePath)
        {
            this.defnNotePath = defnNotePath;
            this.Definitions = new List<DefnItem>();
        }

        internal StreamWriter GetStreamWriter()
        {
            return new StreamWriter(defnNotePath);
        }

        internal void OrderDefinitions()
        {
            this.Definitions.OrderBy(x => x.Defintion);
        }

        internal StreamReader GetStreamReader(string path)
        {
            return new StreamReader(path);
        }

        internal void ReadStream(StreamReader sr)
        {
            var read = sr.ReadToEnd();
            this.StringList = read.Split("\n").ToList();
        }

        internal void ProcessString(List<string> stringList)
        {
            var defn = "> **D";
            var defn2 = "> ** D";
            var defn3 = ">** D";
            var defn4 = ">**D";

            var defItems = stringList.Where(l => l.Contains(defn) || l.Contains(defn2) || l.Contains(defn3) || l.Contains(defn4));
            if (defItems != null && defItems.Count() > 0)
            {
                this.Definitions.AddRange(defItems.Select(x => new DefnItem(x)));
            }
        }

        internal StreamReader GetStreamReader()
        {
            return new StreamReader(defnNotePath);
        }

        internal void AddItem(DefnItem item)
        {
            this.Definitions.Add(item);
        }
    }
}