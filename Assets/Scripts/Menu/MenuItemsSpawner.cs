using System;
using Infrastructure;
using Infrastructure.ServicesHub;
using Menu;
using ScriptableObjects.Menu;
using UnityEngine;

public class MenuItemsSpawner : MonoBehaviour
{
    private MenuIconsSequence menuItemsSequence;
    private GameObject menuItemPrefab;
    private IGameFlowService gameFlowService;

    private void Awake()
    {
        gameFlowService = ServicesHub.Container.Single<IGameFlowService>();
        
        menuItemsSequence = DataContainer.MenuIconsSequence;
        menuItemPrefab = menuItemsSequence.MenuItemPrefab;
    }

    private void Start()
    {
        foreach (AnimalItemData menuItemObject in menuItemsSequence.MenuItemObjects)
        {
            MenuItemController itemController = Instantiate(menuItemPrefab, transform).GetComponent<MenuItemController>();
            itemController.Initialize(menuItemObject, gameFlowService);
        }
    }
}
