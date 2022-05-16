using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Game.Animals;
using Services;
using Type.Common;
using UnityEngine;

public class PulsationController : MonoBehaviour
{
    [SerializeField] private AnimationCurve pointerDownEase;
    [SerializeField] private Transform targetTransform;

    [SerializeField] private float scaleDuration = 0;
    [SerializeField] private Vector2 objectFinalScale = default;

    private void OnDisable() => targetTransform.DOKill();
    

    public void StartPulsation()
    {
        targetTransform.DOKill();
        targetTransform.DOScale(new Vector3(objectFinalScale.x, objectFinalScale.y, objectFinalScale.x), scaleDuration)
            .SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }


    public void StopPulsation() => targetTransform.DOKill();
}

public class TutorialService : ITutorialService
{
    private readonly IAudioService audioService;

    //TODO: refactor with CommandPattern
    private const float FirstPartTutorialTimer = 7.0f;
    private const float SecondPartTutorialTimer = 14.0f;

    private readonly List<TailController> tails = new List<TailController>();
    private static CustomTicker ticker;
    private AnimalType currentAnimal;
    private bool isFirstStepComplete;
    private bool isSecondStepComplete;
    private float passedTime;


    public TutorialService(IAudioService audioService)
    {
        this.audioService = audioService;
    }


    public void AddTail(TailController tailController)
    {
        tails.Add(tailController);
        tailController.OnTailTouched += TailController_OnTailTouched;
    }


    public void StartTutorial(AnimalType currentAnimal)
    {
        this.currentAnimal = currentAnimal;
        
        if (ticker == null)
        {
            ticker = CustomTicker.Create();
        }
        
        ticker.AddListener(OnTick);
    }


    public void DisposeTutorial()
    {
        ticker.RemoveListener(OnTick);
        RemoveTails();
    }


    private void OnTick(float timeSinceLastUpdate)
    {
        passedTime += timeSinceLastUpdate;
        if (passedTime >= FirstPartTutorialTimer && !isFirstStepComplete)
        {
            foreach (TailController tail in tails)
            {
                tail.StartPulse();
            }
            
            audioService.PlaySFX(Constants.Audio.WhereIsMyTail.GetClipByType(currentAnimal));
            isFirstStepComplete = true;
            passedTime = 0; //TODO: 14 seconds after previous question?
        }

        if (passedTime >= SecondPartTutorialTimer && !isSecondStepComplete)
        {
            foreach (TailController tailController in tails.Where(tailController => tailController.AnimalType == currentAnimal))
            {
                tailController.SetActiveTutorialFinger(isActive: true);
            }

            isSecondStepComplete = true;
        }
    }

    private void TailController_OnTailTouched(AnimalType animalType) => StopTutorial(animalType);

    private void StopTutorial(AnimalType animalType)
    {
        if (isSecondStepComplete)
        {
            if (currentAnimal == animalType)
            {
                foreach (TailController tail in tails)
                {
                    tail.StopPulse();
                    tail.SetActiveTutorialFinger(isActive: false);
                }

                ResetTutorial();
            }
            return;
        }

        if (isFirstStepComplete)
        {
            foreach (TailController tail in tails)
            {
                tail.StopPulse();
            }
        }

        ResetTutorial();
    }

    private void ResetTutorial()
    {
        passedTime = 0;
        isFirstStepComplete = false;
        isSecondStepComplete = false;
    }

    private void RemoveTails()
    {
        foreach (TailController tail in tails)
        {
            tail.OnTailTouched -= TailController_OnTailTouched;
        }
        
        tails.Clear();
    }
}