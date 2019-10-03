using System;
using System.IO;
using System.Linq;

namespace NotableParser
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

            foreach (var path in Directory.EnumerateFiles(notesFolderPath, "*.md", SearchOption.AllDirectories))
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
                    streamWriter.WriteLine(line.ToString());
                }
            }
        }

        private void CompareDefns()
        {
            foreach (var item in noteParser.Definitions)
            {
                var matchingItem = defnParser.Definitions.FirstOrDefault(x => x.ToString() == item.ToString());
                if (matchingItem == null) defnParser.AddItem(item);
            }

            defnParser.OrderDefintions();
        }

        private void ReadNote(string path)
        {
            using (var streamReader = noteParser.GetStreamReader(path))
            {
                noteParser.ReadStream(streamReader);
            }

            var fileCode = path.Substring(39, 6);

            noteParser.ProcessString(noteParser.StringList, fileCode);
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