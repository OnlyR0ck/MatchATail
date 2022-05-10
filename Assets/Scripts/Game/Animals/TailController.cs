using System.Collections;
using System.Collections.Generic;
using ScriptableObjects.Menu;
using Type.Common;
using UnityEngine;
using UnityEngine.UI;

public class TailController : MonoBehaviour
{
    [SerializeField] private Image animalTail;
    
    private AnimalType animalType;


    public void Initialize(AnimalItemData animalItemData)
    {
        animalTail.sprite = animalItemData.AnimalTailSprite;
        animalType = animalItemData.AnimalType;
    }
}
