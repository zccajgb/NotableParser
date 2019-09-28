using System;
using System.IO;
using System.Linq;

namespace BoostnoteParser
{
    internal class DefinitionProcessor
    {
        private string notesFolderPath;
        private string defnNotePath;
        private DefnParser defnParser;
        private DefnParser noteParser;

        public DefinitionProcessor(string notesFolderPath, string defnNotePath)
        {
            this.notesFolderPath = notesFolderPath;
            this.defnNotePath = defnNotePath;
            this.defnParser = new DefnParser(defnNotePath);
            this.noteParser = new DefnParser();
        }

        public void ProcessDefinitions()
        {
            ReadDefinitions();

            foreach (var path in Directory.EnumerateFiles(notesFolderPath, "*.cson", SearchOption.AllDirectories))
            {
                if (path != defnNotePath) ReadNote(path);
            }

            CompareDefns();

            WriteList();
        }

        private void WriteList()
        {
            using (var streamWriter = defnParser.GetStreamWriter())
            {
                foreach (var line in defnParser.StringList.GetRange(0, 10))
                {
                    streamWriter.WriteLine(line.Replace("\n", "").Replace("\r", ""));
                }
                foreach (var line in defnParser.Definitions)
                {
                    streamWriter.WriteLine(line.Defintion);
                }
                foreach (var line in defnParser.StringList.Skip(defnParser.StringList.Count() - 6))
                {
                    streamWriter.WriteLine(line.Replace("\n", "").Replace("\r", ""));
                }
            }
        }

        private void CompareDefns()
        {
            foreach (var item in noteParser.Definitions)
            {
                var matchingItem = defnParser.Definitions.FirstOrDefault(x => x.Defintion == item.Defintion);
                defnParser.AddItem(item);
            }
            defnParser.OrderDefinitions();
        }

        private void ReadNote(string path)
        {
            using (var streamReader = noteParser.GetStreamReader(path))
            {
                noteParser.ReadStream(streamReader);
            }

            noteParser.ProcessString(noteParser.StringList);
        }

        private void ReadDefinitions()
        {
            using (var todoReader = defnParser.GetStreamReader())
            {
                defnParser.ReadStream(todoReader);
            }
            defnParser.ProcessString(defnParser.StringList);
        }
    }
}