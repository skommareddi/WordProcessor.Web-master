using System;
using System.Collections;
using System.Collections.Generic;

namespace WordProcessor.Models
{
    public class WordCountResult
    {
        public IEnumerable<WordCount> WordCounts { get; set; }

    }

    public class WordCount
    {
        public string Word { get; set; }
        public int Count { get; set; }
    }
}
