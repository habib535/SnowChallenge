using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BarGraph.Models;

namespace BarGraph.Application.Services
{
    public interface IFileHandler
    {
        Task<IEnumerable<DataFile>> ProcessFile(HttpContent content);
        IEnumerable<DataFile> ParseRawString(string fileContents);
    }
}