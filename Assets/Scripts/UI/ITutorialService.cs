using Game.Animals;
using Infrastructure.ServicesHub;
using Type.Common;

public interface ITutorialService : IService
{
    void AddTail(TailController tailController);
    void StartTutorial(AnimalType currentAnimal);
    void DisposeTutorial();
}