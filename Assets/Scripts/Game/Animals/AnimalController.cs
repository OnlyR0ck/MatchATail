using System.Collections.Generic;
using Game.Animals;
using Infrastructure;
using ScriptableObjects.Menu;
using Services;
using Spine;
using Spine.Unity;
using Type.Common;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    [SerializeField] private SkeletonAnimation animalAnimation;
    
    private List<AnimalItemData> animals;

    private IAudioService audioService;
    private IGameFlowService gameFlowService;
    private IAnimalCreatorService animalCreator;
    
    private IAnimalAnimationHandler animalAnimationHandler;
    
    private int incorrectChoicesInARow = 0;


    private void Awake()
    {
        animals = DataContainer.AnimalItemsSequence.AnimalItems;
    }

    private void OnDisable()
    {
        gameFlowService.OnTailChosen -= GameFlowService_OnTailChosen;
    }

    public void Initialize(AnimalType animalType,
        IGameFlowService gameFlowService,
        IAudioService audioService,
        IAnimalCreatorService animalCreatorService)
    {
        this.gameFlowService = gameFlowService;
        this.audioService = audioService;
        animalCreator = animalCreatorService;
        
        gameFlowService.OnTailChosen += GameFlowService_OnTailChosen; 
        
        InitializeAnimation(animalType);

        this.audioService.PlaySFX(Constants.Audio.WhereIsMyTail.GetClipByType(animalType));
    }

    private void GameFlowService_OnTailChosen(bool isCorrectTailChosen)
    {
        AnimalType lastChosenTail = gameFlowService.LastChosenTail;
        SkeletonData chosenAnimalSkeletonData = GetAnimationAsset(lastChosenTail).GetSkeletonData(false);
        Attachment chosenTail = animalCreator.GetAnimalByType(lastChosenTail).GetTailAttachment(chosenAnimalSkeletonData);
        animalAnimationHandler.SetTailAttachment(chosenTail);
        
        if (isCorrectTailChosen)
        {
            animalAnimationHandler.PlayHappyAnimation();
            gameFlowService.OnTailChosen -= GameFlowService_OnTailChosen;
        }
        else
        {
            
            incorrectChoicesInARow++;
            if (incorrectChoicesInARow >= 2)
            {
                animalAnimationHandler.PlaySadAnimation();
            }
        }
    }
    

    private void InitializeAnimation(AnimalType animalType)
    {
        SkeletonDataAsset animalAnimationSkeletonDataAsset = GetAnimationAsset(animalType);
        animalAnimationHandler = animalCreator.GetAnimalByType(animalType);
        animalAnimationHandler.SetUpAnimation(animalAnimation, animalAnimationSkeletonDataAsset);
        animalAnimationHandler.PlayIdleAnimation();
    }

    
    private SkeletonDataAsset GetAnimationAsset(AnimalType animalType)
    {
        foreach (AnimalItemData animalData in animals)
        {
            if (animalData.AnimalType == animalType)
            {
                return animalData.AnimalAnimation;
            }
        }

        return null;
    }
}