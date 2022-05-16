using Game.Animals;
using Infrastructure;
using Infrastructure.ServicesHub;
using Services;
using Type.Common;
using UnityEngine;

namespace Game.Level
{
    public class LevelInitializer : MonoBehaviour
    {
        [SerializeField] private GameObject animalPrefab;
        [SerializeField] private Transform animalRoot;
        
        private AnimalType animalType;
        private IGameFlowService gameFlowService;
        private IAudioService audioService;
        private ITutorialService tutorialService;
        private IAnimalCreatorService animalCreatorService;

        private void Awake()
        {
            gameFlowService = ServicesHub.Container.Single<IGameFlowService>();
            audioService = ServicesHub.Container.Single<IAudioService>();
            tutorialService = ServicesHub.Container.Single<ITutorialService>();
            animalCreatorService = ServicesHub.Container.Single<IAnimalCreatorService>();
            
            animalType = gameFlowService.LastChosenAnimalType;
            tutorialService.StartTutorial(animalType);
        }

        private void Start()
        {
            AnimalController animalController = Instantiate(animalPrefab, animalRoot).GetComponent<AnimalController>();
            animalController.Initialize(animalType, gameFlowService, audioService, animalCreatorService);

            gameObject.AddComponent<VirtualMother>();
            
        }
    }
}