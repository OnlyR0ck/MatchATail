using System;
using Infrastructure;
using Infrastructure.ServicesHub;
using Menu;
using ScriptableObjects.Menu;
using UnityEngine;

public class MenuItemsSpawner : MonoBehaviour
{
    private AnimalItemsSequence menuItemsSequence;
    private GameObject menuItemPrefab;
    private IGameFlowService gameFlowService;

    private void Awake()
    {
        gameFlowService = ServicesHub.Container.Single<IGameFlowService>();
        
        menuItemsSequence = DataContainer.AnimalItemsSequence;
        menuItemPrefab = menuItemsSequence.MenuItemPrefab;
    }

    private void Start()
    {
        foreach (AnimalItemData menuItemObject in menuItemsSequence.AnimalItems)
        {
            MenuItemController itemController = Instantiate(menuItemPrefab, transform).GetComponent<MenuItemController>();
            itemController.Initialize(menuItemObject, gameFlowService);
        }
    }
}
