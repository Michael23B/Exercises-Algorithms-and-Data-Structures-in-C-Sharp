using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PracticeQuestionsSharp.Helper
{
    public static class CreateReadMe
    {
        //Generates a README.md file for this GitHub project.
        // Finds every ".cs" file, fetches a description from the comments and generates a relative link to that file.
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
                entries.Add(new FileFolderEntry(file, projectRoot.FullName, GetFileDesc(file)));
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
                result.Append($"[{fileName.CamelCaseToSpaces()}]({path})\n\n");
                result.Append($"`{entry.Desc}`\n\n");
            }

            result.Insert(0, readmeHeader);
            result.Append("*This file was created automatically. You can see the code for that [here](/PracticeQuestionsSharp/Helper/CreateReadMe.cs).*\n");

            return result.ToString();
        }

        private static string CamelCaseToSpaces(this string s)
        {
            StringBuilder result = new StringBuilder(s.Length);

            for (int i = 0; i < s.Length; ++i)
            {
                //If the next character is also uppercase, don't put the space in. eg. AVLTree should be "AVL Tree" not "A V L Tree"
                if ((char.IsUpper(s[i]) && i != 0) && (i != s.Length - 1 && char.IsLower(s[i + 1])))
                {
                    result.Append($" {s[i]}");
                }
                else result.Append(s[i]);
            }

            return result.ToString();
        }

        //The description is the first comment in the file, followed by any lines directly under it that are also comments
        private static string GetFileDesc(FileInfo file)
        {
            StringBuilder desc = new StringBuilder();
            using (var fStream = new StreamReader(file.FullName))
            {
                string line;
                bool startedDesc = false;

                while ((line = fStream.ReadLine()) != null)
                {
                    line = line.TrimStart();
                    if (line.StartsWith("//"))
                    {
                        desc.Append(line.TrimStart('/'));
                        startedDesc = true;
                        continue;
                    }

                    if (startedDesc) break;
                }
            }

            return desc.ToString();
        }

        private class FileFolderEntry
        {
            public FileFolderEntry(FileInfo file, string projectRootPath, string desc)
            {
                File = file.Name;
                Folder = GetFolderName(file.DirectoryName);
                Path = file.FullName.Replace(projectRootPath, "").Replace('\\', '/'); //Relative path from project root
                Desc = desc;
            }

            public string File { get; }
            public string Folder { get; }
            public string Path { get; }
            public string Desc { get; }
        }

        private static string readmeHeader =
            "# Exercises, Algorithms and Data Structures in C#\n" +
            "This project is a collection of my solutions to programming questions. " +
            "Most of the questions either came from [this book](http://www.crackingthecodinginterview.com/) " +
            "or from various programming websites. Since they're my own solutions, I can't guarantee every single one is correct. " +
            "I test them to make sure the solution works however there are surely plenty of mistakes that I've missed.\n\n" +
            "The following are the solutions categorized:\n\n";
    }
}
