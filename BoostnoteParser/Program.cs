using System;
using System.Linq;

namespace BoostnoteParser
{
    class Program
    {
        static void Main(string[] args)
        {
            //var path = @"C:\Users\josep\Boostnote\notes\1887b24c-fca2-4d57-8fa1-8d7796ed5870.cson";
            var notesFolderPath = @"C:\Users\josep\Dropbox\PhD\Notes\notes";
            var todoNotePath = @"C:\Users\josep\Dropbox\PhD\Notes\notes\Todo.md";

            var defnNotePath = @"C:\Users\josep\Dropbox\PhD\Notes\notes\Definitions.md";

            var todoProcessor = new TodoProcessor(notesFolderPath, todoNotePath);
            todoProcessor.ProcessTodos();

            var defnProcessor = new DefinitionProcessor(notesFolderPath, defnNotePath);
            defnProcessor.ProcessDefinitions();
        }


    }
}
