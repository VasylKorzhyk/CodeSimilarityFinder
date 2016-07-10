using System.Collections.Generic;

namespace CodeSimilarityFinder.Services
{
    public interface ISolutionComponentsLoader
    {
        IDictionary<string, IEnumerable<string>> LoadSolutionConponents(string rootPath);

        string GetNameByPath(string path);
    }
}