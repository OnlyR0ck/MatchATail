using System;
using Infrastructure.ServicesHub;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    [SerializeField] private Button backButton;
    
    private ISceneLoaderService sceneLoader;
    private const string MenuSceneName = "Menu";

    private void Awake()
    {
        sceneLoader = ServicesHub.Container.Single<ISceneLoaderService>();
    }

    private void OnEnable()
    {
        backButton.onClick.AddListener(BackButton_OnClick);
    }

    private void BackButton_OnClick() => sceneLoader.Load(MenuSceneName);

    private void OnDisable()
    {
        backButton.onClick.RemoveListener(BackButton_OnClick);
    }
}
