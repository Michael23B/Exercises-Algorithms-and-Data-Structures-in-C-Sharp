using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PracticeQuestionsSharp.Helper
{
    public static class CreateReadMe
    {
        public static void CreateReadMeFile()
        {
            //Execution path
            DirectoryInfo dirInfo = new DirectoryInfo(System.Environment.CurrentDirectory);
            dirInfo = dirInfo.Parent?.Parent?.Parent;

            if (dirInfo == null) throw new DirectoryNotFoundException();

            var files = dirInfo.GetFiles("*.cs", SearchOption.AllDirectories);
            var helperFolder = dirInfo.FullName + "\\Helper";

            if (files == null || files.Length == 0) throw new FileNotFoundException(); 

            var entries = new List<FileFolderEntry>();

            foreach (var file in files)
            {
                string folderName = GetFolderName(file.DirectoryName);
                entries.Add(new FileFolderEntry(file.Name, folderName));
            }

            File.WriteAllText(helperFolder + "\\README.md", "test");
        }

        private static string GetFolderName(string directory)
        {
            StringBuilder result = new StringBuilder();

            for (int i = directory.Length - 1; i >= 0; --i)
            {
                if (directory[i] == '\\') break;
                result.Insert(0, directory[i]);
            }

            return result.ToString();
        }

        //TODO: this
        private static string CreateReadmeText(FileFolderEntry entries)
        {
            throw new NotImplementedException();
        }

        private class FileFolderEntry
        {
            public FileFolderEntry(string file, string folder)
            {
                File = file;
                Folder = folder;
            }
            public string File { get; }
            public string Folder { get; }
        }
    }
}
