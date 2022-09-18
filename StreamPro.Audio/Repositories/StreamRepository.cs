using StreamPro.Core.Audio;
using StreamPro.Core.Common;

namespace StreamPro.Audio.Repositories
{
    public class StreamRepository : IStreamRepository
    {
        AudioStreamService audioStreamService;
        public StreamRepository()
        {
            this.audioStreamService = new AudioStreamService();
        }

        public async Task<MemoryStream> GetStream(string id)
        {
            var file = GetFilePath(id);

            var memoryStream = await audioStreamService.GetAudioStream(file);

            return memoryStream;
        }

        private string GetFilePath(string id)
        {
            // write your own code here
            string path = "Media/" + id + ".mp3";

            return path;
        }
    }
}
