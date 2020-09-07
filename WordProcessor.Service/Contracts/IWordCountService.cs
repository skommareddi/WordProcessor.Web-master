using System;
using System.Collections.Generic;
using System.Text;
using WordProcessor.Models;

namespace WordProcessor.Service.Contracts
{
    public interface IWordCountService
    {
        WordCountResult Process(WordCountInput input);
    }
}
