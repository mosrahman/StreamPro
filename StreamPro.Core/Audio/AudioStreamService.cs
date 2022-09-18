using StreamPro.Core.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamPro.Core.Audio
{
    public class AudioStreamService : StreamService
    {
        public AudioStreamService()
        {

        }

        public async Task<MemoryStream> GetAudioStream(string filePath)
        {
            var fileStream = GetFileStream(filePath);

            var memoryStream = await GetStream(fileStream);

            return memoryStream;
        }

        public override FileStream GetFileStream(string filePath)
        {
            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 1024, FileOptions.Asynchronous | FileOptions.SequentialScan);

            return stream;
        }


    }
}
