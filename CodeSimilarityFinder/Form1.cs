using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CodeSimilarityFinder.Dto;

namespace CodeSimilarityFinder
{
    public partial class Form1 : Form
    {
        private readonly IDictionary<string, IEnumerable<string>> solutionComponents;

        public Form1()
        {
            InitializeComponent();
            result_grid.Columns.AddRange(
            new DataGridViewTextBoxColumn { Name = "Project", AutoSizeMode = DataGridViewAutoSizeColumnMode.None },
            new DataGridViewTextBoxColumn { Name = "File", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
            new DataGridViewTextBoxColumn { Name = "Line", AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells });

            this.solutionComponents = LoadSolutionConponents(Directory.GetParent(Environment.CurrentDirectory).FullName);

            this.components_cb.Items.Add("All Components");
            this.components_cb.Items.AddRange(this.solutionComponents.Keys.Select(GetNameByPath).ToArray());
            this.components_cb.SelectedIndex = 0;
        }

        private void solutions_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedComponent = this.components_cb.SelectedItem.ToString();

            this.projects_cb.Items.Clear();
            this.projects_cb.Items.Add("All Projects");

            this.projects_cb.Items.AddRange(this.solutionComponents.Keys.Contains(selectedComponent)
                ? this.solutionComponents[selectedComponent].ToArray()
                : this.solutionComponents.Values.SelectMany(solution => solution).ToArray());

            this.projects_cb.SelectedIndex = 0;
        }

        //TODO: Create a separate class to seach duplicates.
        private void find_btn_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            result_grid.Rows.Clear();

            string inputPattern = codeExample_txt.Text;

            if (!String.IsNullOrEmpty(inputPattern))
            {
                string[] workProjects;

                if (projects_cb.SelectedIndex == 0 && components_cb.SelectedIndex == 0)
                {
                    workProjects = solutionComponents.SelectMany(solution => solution.Value).ToArray();
                }
                else
                {
                    workProjects = projects_cb.SelectedIndex == 0
                        ? solutionComponents[components_cb.SelectedItem.ToString()].ToArray()
                        : new[] { projects_cb.SelectedItem.ToString() };
                }

                Dictionary<string, IEnumerable<FileMatches>> scanProjectResults = workProjects.ToDictionary(project => project, project => ScanProject(project, inputPattern));

                ShowResults(scanProjectResults);
            }

            UseWaitCursor = false;
        }

        private void ShowResults(IDictionary<string, IEnumerable<FileMatches>> projectFilesDictionary)
        {
            foreach (string project in projectFilesDictionary.Keys)
            {
                foreach (FileMatches file in projectFilesDictionary[project])
                {
                    foreach (int lineNumber in file.MatchLines)
                    {
                        result_grid.Rows.Add(GetNameByPath(project), file.FileName, lineNumber);
                    }
                }
            }
        }

        private static IEnumerable<FileMatches> ScanProject(string project, string inputPattern)
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

        private static IDictionary<string, IEnumerable<string>> LoadSolutionConponents(string rootPath)
        {
            return Directory.GetDirectories(rootPath)
                .Where(dir => !dir.Contains("jazz") && Directory.GetFiles(dir, "*.cs", SearchOption.AllDirectories).Any())
                .ToDictionary(GetNameByPath, LoadProjects);

        }

        private static IEnumerable<string> LoadProjects(string rootPath)
        {

            return Directory.GetFiles(rootPath, "*.csproj", SearchOption.AllDirectories)
                .Select(Directory.GetParent).Select(dir => dir.FullName).Where(x => !x.Contains("\\plugins\\")).Distinct();
        }

        private static string GetNameByPath(string path)
        {
            return path.Split('\\').Last();
        }

    }
}