using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using CodeSimilarityFinder.Dto;

namespace CodeSimilarityFinder.Services
{
    public class ProjectScanner : IProjectScanner
    {
        public IEnumerable<FileMatches> ScanProject(string project, string inputPattern)
        {
            string[] filePaths = Directory.GetFiles(project, "*.cs", SearchOption.AllDirectories);

            return filePaths.Select(filePath => ScanFile(filePath, inputPattern)).Where(result => result != null);
        }

        private static FileMatches ScanFile(string filePath, string inputPattern)
        {
            string file = File.ReadAllText(filePath);
            string[] inputPatternLines = inputPattern.Split('\n');

            MatchCollection matches = Regex.Matches(file, ProcessSearchLine(inputPatternLines[0]));

            if (matches.Count == 0)
            {
                return null;
            }

            var positions = new List<int>();
            string[] fileLines = file.Split('\n');

            foreach (Match match in matches)
            {
                int firstLine = GetLineNumber(file, match.Index);

                if (CheckCodeBlock(inputPatternLines, fileLines, firstLine))
                {
                    positions.Add(firstLine + 1);
                }
            }

            return new FileMatches
            {
                FileName = filePath,
                MatchLines = positions
            };
        }

        private static bool CheckCodeBlock(string[] inputLines, string[] fileLines, int firstLine)
        {
            for (int i = 1; i < inputLines.Length; i++)
            {
                if (!Regex.Match(fileLines[firstLine + i], ProcessSearchLine(inputLines[i])).Success)
                {
                    return false;
                }
            }

            return true;
        }

        private static string ProcessSearchLine(string line)
        {
            return String.Format(".*{0}.*", Regex.Escape(line.Trim()).Replace("{any}", "w+"));
        }

        private static int GetLineNumber(string file, int matchIndex)
        {
            return file.Take(matchIndex).Count(x => x == '\n');
        }
    }
}
