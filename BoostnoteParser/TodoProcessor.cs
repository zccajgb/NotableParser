using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BoostnoteParser
{
    public class TodoProcessor
    {
        private TodoParser todoParser;
        private string notePath;
        private string todoPath;
        private TodoParser noteParser;

        public TodoProcessor(string notePath, string todoPath)
        {
            this.notePath = notePath;
            this.todoPath = todoPath;
            this.todoParser = new TodoParser(todoPath);
            this.noteParser = new TodoParser();
        }

        public void ProcessTodos()
        {
            ReadTodos();

            foreach (var path in Directory.EnumerateFiles(notePath, "*.cson", SearchOption.AllDirectories))
            {
                if (path != todoPath) ReadNote(path);
            }

            //ReadNote(notePath);

            CompareTodos();

            WriteList();

        }
        private void WriteList()
        {
            using (var streamWriter = todoParser.GetStreamWriter())
            {
                foreach (var line in todoParser.StringList.GetRange(0, 10))
                {
                    streamWriter.WriteLine(line.Replace("\n","").Replace("\r", ""));
                }
                foreach (var line in todoParser.TodoList.Where(x => !x.Completed))
                {
                    streamWriter.WriteLine(line.ToString());
                }
                foreach (var line in todoParser.TodoList.Where(x => x.Completed))
                {
                    streamWriter.WriteLine(line.ToString());
                }
                foreach (var line in todoParser.StringList.Skip(todoParser.StringList.Count() - 6))
                {
                    streamWriter.WriteLine(line.Replace("\n", "").Replace("\r", ""));
                }
            }
        }


        private void CompareTodos()
        {
            foreach (var item in noteParser.TodoList)
            {
                var matchingItem = todoParser.TodoList.FirstOrDefault(x => x.Item == item.Item);
                if (matchingItem != null)
                {
                    item.Completed = matchingItem.Completed;
                }
                else
                {
                    todoParser.AddItem(item);
                }
            }
        }

        private void ReadNote(string path)
        {
            using (var streamReader = noteParser.GetStreamReader(path))
            {
                noteParser.ReadStream(streamReader);
            }

            noteParser.ProcessString(noteParser.StringList);
        }

        private void ReadTodos()
        {
            using (var todoReader = todoParser.GetStreamReader())
            {
                todoParser.ReadStream(todoReader);
            }
            todoParser.ProcessString(todoParser.StringList);
        }
    }
}
