using System;
using Type.Common;
using UnityEngine;

namespace ScriptableObjects.Menu
{
    [CreateAssetMenu(fileName = "Data_MenuItemObject", menuName = "Data/Menu/MenuObject")]
    [Serializable]
    public class AnimalItemData
    {
        [SerializeField] private AnimalType animalType;
        [SerializeField] private Sprite animalIcon;



        public AnimalType AnimalType => animalType;

        
        public Sprite AnimalAnimalIcon => animalIcon;
    }
}
