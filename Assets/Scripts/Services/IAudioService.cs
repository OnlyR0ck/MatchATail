using Infrastructure.ServicesHub;

namespace Services
{
    public interface IAudioService : IService
    {
        void PlayMusic(string name);
        void PlayMusic(int id);
        void PlaySFX(string name);
        void PlaySFX(int id);
    }
}