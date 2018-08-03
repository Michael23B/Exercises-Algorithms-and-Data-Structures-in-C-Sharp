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
            //Execution path is ".../bin/debug/netcoreapp2.0/something.exe", so we go up a few levels for the project root
            DirectoryInfo projectRoot = new DirectoryInfo(Environment.CurrentDirectory).Parent?.Parent?.Parent?.Parent;
            //If this doesn't work we end up with null because of the .? operators
            if (projectRoot == null) throw new DirectoryNotFoundException();

            //Get all files ending in .cs
            var files = projectRoot.GetFiles("*.cs", SearchOption.AllDirectories);

            if (files == null || files.Length == 0) throw new FileNotFoundException(); 

            var entries = new List<FileFolderEntry>();

            foreach (var file in files)
            {
                string folderName = GetFolderName(file.DirectoryName);
                entries.Add(new FileFolderEntry(file.Name, folderName));
            }

            File.WriteAllText(projectRoot.FullName + "\\README.md", CreateReadmeString(entries));
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

        private static string CreateReadmeString(List<FileFolderEntry> entries)
        {
            var result = new StringBuilder();

            foreach (var entry in entries)
            {
                if (entry.Folder == "netcoreapp2.0") continue;  //Skip build files
                result.Append($"{entry.Folder}/{entry.File}\n");
            }

            return result.ToString();
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
