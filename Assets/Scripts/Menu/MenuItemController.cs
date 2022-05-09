using System;
using ScriptableObjects.Menu;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Menu
{
    public class MenuItemController : MonoBehaviour
    {
        [SerializeField] private Image animalIcon;
        [SerializeField] private Button animalButton;

        private void OnEnable() => animalButton.onClick.AddListener(Button_OnClick);

        private void OnDisable() => animalButton.onClick.RemoveListener(Button_OnClick);

        
        public void Initialize(MenuItemObject animalItem) => 
            animalIcon.sprite = animalItem.AnimalIcon;

        
        private void Button_OnClick()
        {
        }
    }
}
