using Game.Animals;
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
            LockOrientation();
            
            DontDestroyOnLoad(this);
        }

        
        private void LockOrientation()
        {
            Screen.orientation = ScreenOrientation.Landscape;
            Screen.autorotateToPortrait = false;
            Screen.autorotateToPortraitUpsideDown = false;
        }

        
        private void RegisterServices()
        {
            container.RegisterSingle<ISceneLoaderService>(new SceneLoaderService(this));
            container.RegisterSingle<IAudioService>(new AudioService(this, transform));
            container.RegisterSingle<ITutorialService>(new TutorialService(container.Single<IAudioService>()));
            container.RegisterSingle<IGameFlowService>(new GameFlowService(
                container.Single<ISceneLoaderService>(),
                container.Single<ITutorialService>()));
            container.RegisterSingle<IAnimalCreatorService>(new AnimalCreator());
        }
    }
}