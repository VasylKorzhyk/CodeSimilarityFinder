using System.Collections.Generic;
using CodeSimilarityFinder.Dto;

namespace CodeSimilarityFinder.Services
{
    public interface IProjectScanner
    {
         IEnumerable<FileMatches> ScanProject(string project, string inputPattern);
    }
}