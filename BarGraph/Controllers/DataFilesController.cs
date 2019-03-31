using BarGraph.Application.Services;
using BarGraph.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace BarGraph.Controllers
{
    public class DataFilesController : ApiController
    {
        [HttpPost]
        public async Task<IEnumerable<DataFile>> Upload()
        {
            IFileHandler fileHandler = new FileHandler();
            return await fileHandler.ProcessFile(Request.Content);
        }
    }
}
