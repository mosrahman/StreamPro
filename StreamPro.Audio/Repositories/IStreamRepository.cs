namespace StreamPro.Audio.Repositories
{
    public interface IStreamRepository
    {
        Task<MemoryStream> GetStream(string id);
    }
}
