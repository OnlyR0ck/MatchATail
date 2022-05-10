using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ScriptableObjects.Menu
{
    [CreateAssetMenu(fileName = "Data_AnimalItemsSequence", menuName = "Data/Menu/Items Sequence")]
    public class AnimalItemsSequence : SerializedScriptableObject
    {
        [SerializeField] private List<AnimalItemData> animalItems;
        [SerializeField] private GameObject menuItemPrefab;


        public List<AnimalItemData> AnimalItems => animalItems;

        public GameObject MenuItemPrefab => menuItemPrefab;
    }
}
