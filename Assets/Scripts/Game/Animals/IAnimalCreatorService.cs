using Infrastructure.ServicesHub;
using Type.Common;

namespace Game.Animals
{
    public interface IAnimalCreatorService : IService
    {
        IAnimalAnimationHandler GetAnimalByType(AnimalType animalType);
    }
}