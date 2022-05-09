using Type.Common;

namespace Infrastructure
{
    public class GameFlowService : IGameFlowService
    {
        private AnimalType lastChosenAnimalType;

        
        public AnimalType LastChosenAnimalType
        {
            get => lastChosenAnimalType;
            set => lastChosenAnimalType = value;
        }
    }
}