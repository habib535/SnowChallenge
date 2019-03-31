using BarGraph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;

namespace BarGraph.Application.Services
{
    public class FileHandler : IFileHandler
    {
        Random random = new Random();
        public async Task<IEnumerable<DataFile>> ProcessFile(HttpContent content)
        {
            try
            {
                if (!content.IsMimeMultipartContent())
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

                var provider = new MultipartMemoryStreamProvider();
                await content.ReadAsMultipartAsync(provider);
                var uploadedFile = provider.Contents.FirstOrDefault();
                if (uploadedFile == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NoContent);
                }
                var filename = uploadedFile.Headers.ContentDisposition.FileName.Trim('\"');
                var fileContents = await uploadedFile.ReadAsStringAsync();
                return ParseRawString(fileContents);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        public IEnumerable<DataFile> ParseRawString(string fileContents)
        {
            foreach (var line in fileContents.Split(new string[] { "\r\n" }, StringSplitOptions.None))
            {
                yield return ParseLine(line.Trim());
            }
        }

        private DataFile ParseLine(string line)
        {
            var tokens = line.Trim('#').Split(':');
            if (tokens.Length != 3)
            {
                throw new Exception("Invalid data format, not all three properties were found");
            }
            else
            {
                Regex letterOrDigitRegex = new Regex(@"^[a-zA-Z0-9]+$");

                if (letterOrDigitRegex.IsMatch(tokens[0]))
                {
                    return new DataFile
                    {
                        Name = tokens[0],
                        Color = tokens[1],
                        Size = GetRandomSizeValue()
                    };
                }
                else
                {
                    throw new Exception("Invalid name format, only letters and digits are allowed");
                }
            }
        }

        private int GetRandomSizeValue()
        {
            return random.Next(1, 100);
        }
    }
}