using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PracticeQuestionsSharp.Helper
{
    public static class CreateReadMe
    {
        //Generates a README.md file for the GitHub project. Gets every ".cs" file and generates a relative link to that file
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
                entries.Add(new FileFolderEntry(file, projectRoot.FullName));
            }

            File.WriteAllText(projectRoot.FullName + "\\README.md", CreateReadmeString(entries));
        }

        //Gets the folder name where height = number of '\' after the folder
        private static string GetFolderName(string directory, int height = 0)
        {
            StringBuilder result = new StringBuilder();

            for (int i = directory.Length - 1; i >= 0; --i)
            {
                if (directory[i] == '\\')
                {
                    height--;
                    if (height < 0) break;
                    continue;
                }
                if (height == 0) result.Insert(0, directory[i]);
            }

            return result.ToString();
        }

        private static string CreateReadmeString(List<FileFolderEntry> entries)
        {
            var result = new StringBuilder();
            string currHeader = "";

            entries.Sort((a,b) => a.Folder.CompareTo(b.Folder));

            foreach (var entry in entries)
            {
                if (entry.Folder == "netcoreapp2.0") continue;  //Skip build files

                if (currHeader != entry.Folder)
                {
                    currHeader = entry.Folder;
                    //Generates a header with the folder name and the relative path to that folder
                    result.Append($"\n## [{currHeader}]({entry.Path.Replace(entry.File, "").Replace(" ", "%20")})\n");
                }

                //GitHub relative link markdown - [filename (without ".cs")](relative path to file (spaces replaced for valid urls))
                string fileName = entry.File.Replace(".cs", "");
                string path = entry.Path.Replace(" ", "%20");
                result.Append($"[{fileName}]({path})\n\n");
            }

            result.Insert(0, GetReadmeHeader());
            result.Append("*This file was created automatically. You can see the code for that [here](/PracticeQuestionsSharp/Helper/CreateReadMe.cs).*\n");

            return result.ToString();
        }

        private static string GetReadmeHeader()
        {
            return
                "# Exercises, Algorithms and Data Structures in C#\n" +
                "This project is a collection of my solutions to programming questions. " +
                "Most of the questions either came from [this book](http://www.crackingthecodinginterview.com/) " +
                "or from various programming websites. Since they're my own solutions, I can't guarantee every single one is correct. " +
                "I test them to make sure the solution works however there are surely plenty of mistakes that I've missed.\n\n" +
                "The following are the solutions categorized:\n\n";
        }

        private class FileFolderEntry
        {
            public FileFolderEntry(FileInfo file, string projectRootPath)
            {
                File = file.Name;
                Folder = GetFolderName(file.DirectoryName);
                Path = file.FullName.Replace(projectRootPath, "").Replace('\\', '/'); //Relative path from project root
            }

            public string File { get; }
            public string Folder { get; }
            public string Path { get; }
        }
    }
}
