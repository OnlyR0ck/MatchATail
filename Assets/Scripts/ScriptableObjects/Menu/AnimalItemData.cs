using System;
using Spine.Unity;
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
        [SerializeField] private Sprite animalTailSprite;
        [SerializeField] private SkeletonDataAsset animalAnimationData;


        public AnimalType AnimalType => animalType;

        
        public Sprite AnimalAnimalIcon => animalIcon;

        
        public SkeletonDataAsset AnimalAnimation => animalAnimationData;

        
        public Sprite AnimalTailSprite => animalTailSprite;
    }
}
