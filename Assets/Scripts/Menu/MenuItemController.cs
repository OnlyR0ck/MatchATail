using Infrastructure;
using Infrastructure.ServicesHub;
using ScriptableObjects.Menu;
using Type.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class MenuItemController : MonoBehaviour
    {
        [SerializeField] private Image animalIcon;
        [SerializeField] private Button animalButton;

        private IGameFlowService gameFlowService;
        private ISceneLoaderService sceneLoader;

        private AnimalType animalType;


        private void Awake()
        {
            sceneLoader = ServicesHub.Container.Single<ISceneLoaderService>();
        }

        private void OnEnable() => animalButton.onClick.AddListener(Button_OnClick);

        private void OnDisable() => animalButton.onClick.RemoveListener(Button_OnClick);


        public void Initialize(AnimalItemData animalItem, IGameFlowService gameFlowService)
        {
            this.gameFlowService = gameFlowService;
            
            animalIcon.sprite = animalItem.AnimalAnimalIcon;
            animalType = animalItem.AnimalType;
        }


        private void Button_OnClick()
        {
            gameFlowService.LastChosenAnimalType = animalType;
            sceneLoader.Load(Constants.Scenes.Game);
        }
    }
}
