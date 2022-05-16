using System;
using DG.Tweening;
using Type.Common;
using UnityEngine;

namespace Infrastructure
{
    public class GameFlowService : IGameFlowService
    {
        private const float DelayBeforeSceneSwitch = 5;

        private AnimalType lastChosenAnimalType;
        private AnimalType lastChosenTail;
        private readonly ISceneLoaderService sceneLoaderService;
        private readonly ITutorialService tutorialService;


        public GameFlowService(ISceneLoaderService sceneLoaderService, ITutorialService tutorialService)
        {
            this.sceneLoaderService = sceneLoaderService;
            this.tutorialService = tutorialService;
        }

        public event Action<bool> OnTailChosen;


        public AnimalType LastChosenAnimalType
        {
            get => lastChosenAnimalType;
            set => lastChosenAnimalType = value;
        }

        public AnimalType LastChosenTail
        {
            get => lastChosenTail;
            set => lastChosenTail = value;
        }

        
        public void TailWasChosen(AnimalType animalType)
        {
            lastChosenTail = animalType;

            bool isCorrectTailChosen = lastChosenAnimalType == animalType;
            
            OnTailChosen?.Invoke(isCorrectTailChosen);

            if (isCorrectTailChosen)
            {
                DOVirtual.DelayedCall(DelayBeforeSceneSwitch, () =>
                {
                    tutorialService.DisposeTutorial();
                    sceneLoaderService.Load(Constants.Scenes.Menu);
                });
            }

            Debug.Log($"Was correct tail chosen: {isCorrectTailChosen.ToString()}");
        }
    }
}