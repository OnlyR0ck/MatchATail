using Infrastructure.ServicesHub;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    [SerializeField] private Button backButton;
    
    private ISceneLoaderService sceneLoader;
    private ITutorialService tutorialService;

    private void Awake()
    {
        sceneLoader = ServicesHub.Container.Single<ISceneLoaderService>();
        tutorialService = ServicesHub.Container.Single<ITutorialService>();
    }

    private void OnEnable() => backButton.onClick.AddListener(BackButton_OnClick);

    private void BackButton_OnClick()
    {
        tutorialService.DisposeTutorial();
        sceneLoader.Load(Constants.Scenes.Menu);
    }

    private void OnDisable() => backButton.onClick.RemoveListener(BackButton_OnClick);
}
