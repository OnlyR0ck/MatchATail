using System;
using Type.Common;
using UnityEngine;

namespace ScriptableObjects.Menu
{
    [CreateAssetMenu(fileName = "Data_MenuItemObject", menuName = "Data/Menu/MenuObject")]
    [Serializable]
    public class MenuItemObject
    {
        [SerializeField] private AnimalType animalType;
        [SerializeField] private Sprite icon;

        
        
        public AnimalType AnimalType => animalType;

        
        public Sprite AnimalIcon => icon;
    }
}
