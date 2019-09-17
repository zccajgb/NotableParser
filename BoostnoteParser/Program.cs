using System;
using System.Linq;

namespace BoostnoteParser
{
    class Program
    {
        static void Main(string[] args)
        {
            //var path = @"C:\Users\josep\Boostnote\notes\1887b24c-fca2-4d57-8fa1-8d7796ed5870.cson";
            var path = @"C:\Users\josep\Boostnote\notes\";
            var path2 = @"C:\Users\josep\Boostnote\notes\c9191acd-99d4-4863-a535-5a35556a5902.cson";

            var todoProcessor = new TodoProcessor(path, path2);
            todoProcessor.ProcessTodos();
        }


    }
}
