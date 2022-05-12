using System;
using Type.Common;
using UnityEngine;

namespace Infrastructure
{
    public class GameFlowService : IGameFlowService
    {
        private AnimalType lastChosenAnimalType;
        public event Action<bool> OnTailChosen;


        public AnimalType LastChosenAnimalType
        {
            get => lastChosenAnimalType;
            set => lastChosenAnimalType = value;
        }

        public void TailWasChosen(AnimalType animalType)
        {
            bool isCorrectTailChosen = lastChosenAnimalType == animalType;
            OnTailChosen?.Invoke(isCorrectTailChosen);
            
            Debug.Log($"Was correct tail chosen: {isCorrectTailChosen.ToString()}");
        }
    }
}