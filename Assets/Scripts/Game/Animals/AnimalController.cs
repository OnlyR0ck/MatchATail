using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Infrastructure;
using ScriptableObjects.Menu;
using Spine;
using Spine.Unity;
using Type.Common;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    [SerializeField] private SkeletonAnimation animalAnimation;
    
    private List<AnimalItemData> animals;
    private AnimalType currentAnimalType;


    private void Awake()
    {
        animals = DataContainer.AnimalItemsSequence.AnimalItems;
    }

    public void Initialize(AnimalType animalType, IGameFlowService gameFlowService)
    {
        currentAnimalType = animalType;
        SkeletonDataAsset animalAnimationSkeletonDataAsset = GetAnimationAsset(animalType);
        animalAnimation.skeletonDataAsset = animalAnimationSkeletonDataAsset;
        animalAnimation.Initialize(true);
    }

    private SkeletonDataAsset GetAnimationAsset(AnimalType animalType)
    {
        foreach (AnimalItemData animal in animals)
        {
            if (animal.AnimalType == animalType)
            {
                return animal.AnimalAnimation;
            }
        }

        return null;
    }
}
