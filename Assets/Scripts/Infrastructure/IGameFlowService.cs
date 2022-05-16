using System;
using Infrastructure.ServicesHub;
using Type.Common;

namespace Infrastructure
{
    public interface IGameFlowService : IService
    {
        AnimalType LastChosenAnimalType { get; set; }
        AnimalType LastChosenTail { get; set; }
        void TailWasChosen(AnimalType animalType);
        event Action<bool> OnTailChosen;
    }
}