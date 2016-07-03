using System.Collections.Generic;

namespace CodeSimilarityFinder.Dto
{
    public class FileMatches
    {
        public string FileName { get; set; }
        public IEnumerable<int> MatchLines { get; set; }
    }
}
