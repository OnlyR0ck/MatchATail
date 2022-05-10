using ScriptableObjects.Menu;
using UnityEngine;

public class TailsSpawner : MonoBehaviour
{
    [SerializeField] private Transform rightRoot;
    [SerializeField] private Transform leftRoot;

    [SerializeField] private int leftTailsCount;
    [SerializeField] private int rightTailsCount;

    [SerializeField] private GameObject tailPrefab;
    
    private AnimalItemsSequence animalItems;


    private void Start()
    {
        animalItems = DataContainer.AnimalItemsSequence;
        for (int i = 0; i < animalItems.AnimalItems.Count; i++)
        {
            TailController tailController = Instantiate(tailPrefab, i < leftTailsCount ? leftRoot : rightRoot).GetComponent<TailController>();
            tailController.Initialize(animalItems.AnimalItems[i]);
        }
    }
}
