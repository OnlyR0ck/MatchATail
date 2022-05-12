using Infrastructure.ServicesHub;
using Type.Common;

namespace Infrastructure
{
    public interface IGameFlowService : IService
    {
        AnimalType LastChosenAnimalType { get; set; }
        void TailWasChosen(AnimalType animalType);
    }
}