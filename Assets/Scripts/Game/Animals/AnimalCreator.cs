using System;
using Type.Common;

namespace Game.Animals
{
    public class AnimalCreator : IAnimalCreatorService
    {
        public IAnimalAnimationHandler GetAnimalByType(AnimalType animalType)
        {
            switch (animalType)
            {
                case AnimalType.Cat:
                    return new CatAnimationHandler();
                case AnimalType.Cow:
                    return new CowAnimationHandler();
                case AnimalType.Dog:
                    return new DogAnimationHandler();
                case AnimalType.Horse:
                    return new HorseAnimationHandler();
                case AnimalType.Mouse:
                    return new MouseAnimationHandler();
                case AnimalType.Pig:
                    return new PigAnimationHandler();
                default:
                    throw new ArgumentException($"There is no animal with type: {animalType}");
            }
        }
    }
}