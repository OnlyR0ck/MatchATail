using System;
using Infrastructure;
using ScriptableObjects.Menu;
using Type.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Animals
{
    public class TailController : MonoBehaviour
    {
        public event Action<AnimalType> OnTailTouched;
    
        [SerializeField] private Image animalTail;
        [SerializeField] private Transform tutorialFingerRoot;

        private AnimalType animalType;
        private PulsationController pulseController;
        private IGameFlowService gameFlowService;
        private DragNDropController dragNDropController;
        private OutlineEffectController outlineEffectController;


        public AnimalType AnimalType => animalType;

        public OutlineEffectController OutlineEffectController => outlineEffectController;

        private void Awake()
        {
            pulseController = GetComponent<PulsationController>();
            dragNDropController = GetComponent<DragNDropController>();
        
            outlineEffectController = new OutlineEffectController(animalTail);
        }

        private void OnEnable() => dragNDropController.OnTailTouched += DragNDropController_OnTailTouched;

        private void OnDisable()
        {
            OutlineEffectController.SetActiveSpriteOutline(false);
            dragNDropController.OnTailTouched -= DragNDropController_OnTailTouched;
        }

        public void Initialize(AnimalItemData animalItemData, IGameFlowService gameFlowService)
        {
            this.gameFlowService = gameFlowService;
        
            animalTail.sprite = animalItemData.AnimalTailSprite;
            animalType = animalItemData.AnimalType;
        
            gameFlowService.OnTailChosen += GameFlowService_OnTailChosen;
        
            SetActiveTutorialFinger(isActive: false);
        }


        public void StartPulse() => pulseController.StartPulsation();


        public void StopPulse() => pulseController.StopPulsation();


        public void SetActiveTutorialFinger(bool isActive) => tutorialFingerRoot.gameObject.SetActive(isActive);


        private void DragNDropController_OnTailTouched() => OnTailTouched?.Invoke(animalType);

    
        private void GameFlowService_OnTailChosen(bool isCorrectTailChosen)
        {
            if (isCorrectTailChosen)
            {
            
            }
            else
            {
            }

            outlineEffectController.SetActiveSpriteOutline(gameFlowService.LastChosenTail == animalType);
        }
    }
}
