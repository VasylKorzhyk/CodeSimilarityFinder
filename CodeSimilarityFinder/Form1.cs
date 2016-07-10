using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CodeSimilarityFinder.Dto;
using CodeSimilarityFinder.Services;

namespace CodeSimilarityFinder
{
    public partial class Form1 : Form
    {
        private readonly IDictionary<string, IEnumerable<string>> solutionComponents;
        private readonly IProjectScanner projectScanner;
        private readonly ISolutionComponentsLoader solutionComponentsLoader;

        public Form1(IProjectScanner projectScanner, ISolutionComponentsLoader solutionComponentsLoader)
        {
            InitializeComponent();
            this.projectScanner = projectScanner;
            this.solutionComponentsLoader = solutionComponentsLoader;
            this.solutionComponents = solutionComponentsLoader.LoadSolutionConponents(Directory.GetParent(Environment.CurrentDirectory).FullName);

            FillForm();
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

                Dictionary<string, IEnumerable<FileMatches>> scanProjectResults = workProjects.ToDictionary(project => project, project => projectScanner.ScanProject(project, inputPattern));

                ShowResults(scanProjectResults);
            }

            UseWaitCursor = false;
        }

        private void FillForm()
        {
            result_grid.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "Project", AutoSizeMode = DataGridViewAutoSizeColumnMode.None },
                new DataGridViewTextBoxColumn { Name = "File", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
                new DataGridViewTextBoxColumn { Name = "Line", AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells });

            this.components_cb.Items.Add("All Components");
            this.components_cb.Items.AddRange(this.solutionComponents.Keys.Select(solutionComponentsLoader.GetNameByPath).ToArray());
            this.components_cb.SelectedIndex = 0;
        }

        private void ShowResults(IDictionary<string, IEnumerable<FileMatches>> projectFilesDictionary)
        {
            foreach (string project in projectFilesDictionary.Keys)
            {
                foreach (FileMatches file in projectFilesDictionary[project])
                {
                    foreach (int lineNumber in file.MatchLines)
                    {
                        result_grid.Rows.Add(solutionComponentsLoader.GetNameByPath(project), file.FileName, lineNumber);
                    }
                }
            }
        }
    }
}