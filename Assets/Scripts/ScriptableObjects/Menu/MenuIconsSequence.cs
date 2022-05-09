using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ScriptableObjects.Menu
{
    [CreateAssetMenu(fileName = "Data_MenuIconsSequence", menuName = "Data/Menu/Icons Sequence")]
    public class MenuIconsSequence : SerializedScriptableObject
    {
        [SerializeField] private List<AnimalItemData> menuItemObjects;
        [SerializeField] private GameObject menuItemPrefab;


        public List<AnimalItemData> MenuItemObjects => menuItemObjects;

        public GameObject MenuItemPrefab => menuItemPrefab;
    }
}
