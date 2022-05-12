namespace Services
{
    public interface IAudioService
    {
        void PlayMusic(string _name);
        void PlayMusic(int _id);
        void PlaySFX(string _name);
        void PlaySFX(int _id);
    }
}