using System;
using Menu;
using ScriptableObjects.Menu;
using UnityEngine;

public class MenuItemsSpawner : MonoBehaviour
{
    private MenuIconsSequence menuItemsSequence;
    private GameObject menuItemPrefab;

    private void Awake()
    {
        menuItemsSequence = DataContainer.MenuIconsSequence;
        menuItemPrefab = menuItemsSequence.MenuItemPrefab;
    }

    private void Start()
    {
        foreach (MenuItemObject menuItemObject in menuItemsSequence.MenuItemObjects)
        {
            MenuItemController itemController = Instantiate(menuItemPrefab, transform).GetComponent<MenuItemController>();
            itemController.Initialize(menuItemObject);
        }
    }
}
