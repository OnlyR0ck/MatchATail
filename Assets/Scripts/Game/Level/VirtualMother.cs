using System;
using System.Collections.Generic;
using Infrastructure;
using Infrastructure.ServicesHub;
using Services;
using UnityEngine;

public class VirtualMother : MonoBehaviour
{
    private IGameFlowService gameFlowService;
    private IAudioService audioService;

    private readonly List<string> motherIncorrectActionVoiceKeys = new List<string>();
    private readonly List<string> motherCorrectActionVoiceKeys = new List<string>();

    private void Awake()
    {
        gameFlowService = ServicesHub.Container.Single<IGameFlowService>();
        audioService = ServicesHub.Container.Single<IAudioService>();

        foreach (AudioData audioData in DataContainer.MotherIncorrectActionData.AudioDatas)
        {
            motherIncorrectActionVoiceKeys.Add(audioData.m_name);
        }
        
        foreach (AudioData audioData in DataContainer.MotherCorrectActionData.AudioDatas)
        {
            motherCorrectActionVoiceKeys.Add(audioData.m_name);
        }
    }

    private void OnEnable() => gameFlowService.OnTailChosen += GameFlowService_OnTailChosen;

    private void OnDisable() => gameFlowService.OnTailChosen -= GameFlowService_OnTailChosen;

    
    private void GameFlowService_OnTailChosen(bool isCorrectTail)
    {
        audioService.PlaySFX(isCorrectTail ? 
            motherCorrectActionVoiceKeys.RandomValue() : motherIncorrectActionVoiceKeys.RandomValue());
    }
}