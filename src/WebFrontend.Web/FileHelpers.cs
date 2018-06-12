using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebFrontend.Entities;

namespace WebFrontend.Web
{
    public class FileHelpers
    {
        public static async Task<IEnumerable<byte[]>> ProcessFormFiles(IFormFileCollection formFileCollection)
        {
            var streams = formFileCollection.Select(p => p.OpenReadStream());
            var memoryStreams = new List<MemoryStream>(streams.Count());
            var tasks = new List<Task>(streams.Count());
            for (int i = 0; i < streams.Count(); i++)
            {
                tasks[i] = streams.ElementAt(i).CopyToAsync(memoryStreams[i]);
            }

            await Task.WhenAll(tasks);
            return memoryStreams.Select(p => p.ToArray());
        }
    }
}
