using System;
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

        private void Awake()
        {
            gameFlowService = ServicesHub.Container.Single<IGameFlowService>();
            audioService = ServicesHub.Container.Single<IAudioService>();
            
            animalType = gameFlowService.LastChosenAnimalType;
        }

        private void Start()
        {
            AnimalController animalController = Instantiate(animalPrefab, animalRoot).GetComponent<AnimalController>();
            animalController.Initialize(animalType, gameFlowService);
            
            audioService.PlaySFX(Constants.Audio.WhereIsMyTail.GetClipByType(animalType));
        }
    }
}


public static class Constants
{
    public class Audio
    {
        public class WhereIsMyTail
        {
            public const string Cat     = "CAT_09";
            public const string Cow     = "COW_09";
            public const string Dog     = "DOG_09";
            public const string Horse   = "HORSE_09";
            public const string Mouse   = "MOUSE_09";
            public const string Pig     = "PIG_09";
            
            
            public static string GetClipByType(AnimalType animalType)
            {
                switch (animalType)
                {
                    case AnimalType.Cat:
                        return Cat;
                    case AnimalType.Cow:
                        return Cow;
                    case AnimalType.Dog:
                        return Dog;
                    case AnimalType.Horse:
                        return Horse;
                    case AnimalType.Mouse:
                        return Mouse;
                    case AnimalType.Pig:
                        return Pig;
                    default:
                        throw new ArgumentException($"There is no sound with type: {animalType}");
                }
            }
        }
    }
}