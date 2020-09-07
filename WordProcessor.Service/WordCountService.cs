using System;
using System.Collections.Generic;
using System.Linq;
using WordProcessor.Models;
using WordProcessor.Service.Contracts;

namespace WordProcessor.Service
{
    public class WordCountService : IWordCountService
    {
        public WordCountResult Process(WordCountInput input)
        {
            var result = new WordCountResult();

            var words = input.Text.Split(' ', '\n')
                        .Where(p => !string.IsNullOrWhiteSpace(p))
                        .Select(p => p.Replace(",", "").Replace(".", "").Replace("\n", ""))
                        .Select(p => new { Hash = p.GetHashCode(), Word = p })
                        .ToList();

            result.WordCounts = (from word in words
                                 group word by word.Hash into grpWord
                                 select new WordCount
                                 {
                                     Word = words.FirstOrDefault(p => p.Hash == grpWord.Key).Word,
                                     Count = grpWord.Count()
                                 }).ToList();



            return result;
        }
    }
}
