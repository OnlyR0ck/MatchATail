using Services;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private ServicesHub.ServicesHub container;

        private void Awake()
        {
            container = ServicesHub.ServicesHub.Container;
            
            RegisterServices();
            
            DontDestroyOnLoad(this);
        }

        private void RegisterServices()
        {
            container.RegisterSingle<IGameFlowService>(new GameFlowService());
            container.RegisterSingle<ISceneLoaderService>(new SceneLoaderService(this));
            container.RegisterSingle<IAudioService>(new AudioService(this, transform));
        }
    }
}