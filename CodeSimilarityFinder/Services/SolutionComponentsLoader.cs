using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeSimilarityFinder.Services
{
    public class SolutionComponentsLoader : ISolutionComponentsLoader
    {
        public IDictionary<string, IEnumerable<string>> LoadSolutionConponents(string rootPath)
        {
            return Directory.GetDirectories(rootPath)
                .Where(dir => !dir.Contains("jazz") && Directory.GetFiles(dir, "*.cs", SearchOption.AllDirectories).Any())
                .ToDictionary<string, string, IEnumerable<string>>(GetNameByPath, LoadProjects);

        }
        
        public string GetNameByPath(string path)
        {
            return path.Split('\\').Last();
        }

        private static IEnumerable<string> LoadProjects(string rootPath)
        {

            return Directory.GetFiles(rootPath, "*.csproj", SearchOption.AllDirectories)
                .Select(Directory.GetParent).Select(dir => dir.FullName).Where(x => !x.Contains("\\plugins\\")).Distinct();
        }
    }
}
