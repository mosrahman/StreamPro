using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace StreamPro.Core.Common
{
    public abstract class StreamService
    {
        public StreamService()
        {

        }

        public abstract FileStream GetFileStream(string filename);

        internal async Task<MemoryStream> GetStream(FileStream fileStream)
        {
            MemoryStream memoryStream = new MemoryStream();

            await fileStream.CopyToAsync(memoryStream);

            memoryStream.Position = 0;

            return memoryStream;
        }

    }
}
