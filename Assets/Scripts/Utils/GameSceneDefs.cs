using System;
using UnityEngine;

public class GameSceneDefs : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    public static Canvas Canvas { get; private set; }

    private void Awake() => Initialize();

    
    private Canvas Initialize()
    {
        return Canvas = canvas;
    }
}
