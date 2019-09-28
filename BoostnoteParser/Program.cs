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
            var todoNotePath = @"C:\Users\josep\Dropbox\PhD\Notes\notes\bd3e51c5-e31f-4b0a-a5c2-b4b445ce94b1.cson";

            var defnNotePath = @"C:\Users\josep\Dropbox\PhD\Notes\notes\053e64c0-29b9-4338-b2d5-f1f60e19cbf0.cson";

            var todoProcessor = new TodoProcessor(notesFolderPath, todoNotePath);
            todoProcessor.ProcessTodos();

            var defnProcessor = new DefinitionProcessor(notesFolderPath, defnNotePath);
            defnProcessor.ProcessDefinitions();
        }


    }
}
