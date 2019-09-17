using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BoostnoteParser
{
    public class TodoParser
    {
        private string path;
        public List<TodoItem> TodoList { get; private set; }
        public List<string> StringList { get; private set; }

        public TodoParser()
        {
            this.TodoList = new List<TodoItem>();
        }
        public TodoParser(string path)
        {
            this.path = path;
            this.TodoList = new List<TodoItem>();
        }

        public StreamReader GetStreamReader()
        {
            return new StreamReader(path);
        }

        public StreamReader GetStreamReader(string path)
        {
            return new StreamReader(path);
        }

        public void ReadStream(StreamReader sr)
        {
            var read = sr.ReadToEnd();
            this.StringList = read.Split("\n").ToList();
        }

        public StreamWriter GetStreamWriter()
        {
            return new StreamWriter(path);
        }

        public void OrderTodos()
        {
            this.TodoList.OrderBy(x => x.Completed ? 1 : 0); 
        }

        public void ProcessString(List<string> lst)
        {
            var newTodoItem = "- [ ]";
            var completedItem = "- [x]";

            var todoItems = lst.Where(l => l.Contains(newTodoItem) || l.Contains(completedItem));
            this.TodoList.AddRange(todoItems.Select(str => new TodoItem(str)));
        }

        public StreamWriter GetStreamWriter(string path2)
        {
            return new StreamWriter(path2);
        }

        public void AddItem(TodoItem item)
        {
            this.TodoList.Add(item);
        }
    }
}
