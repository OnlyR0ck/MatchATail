using System;
using UnityEngine;

public class CustomTicker : MonoBehaviour
{
    private Action<float> action = timePassed => { };
    
    private static float intervalSeconds = 0.1f;
    private float timeSinceLastUpdate;


    private void Update()
    {
        timeSinceLastUpdate += Time.deltaTime;
        if (timeSinceLastUpdate >= intervalSeconds)
        {
            action?.Invoke(timeSinceLastUpdate);
            timeSinceLastUpdate = 0;
        }
    }


    public static CustomTicker Create(float precision = 0.1f)
    {
        GameObject gameObject = new GameObject("CustomTicker");
        CustomTicker ticker = gameObject.AddComponent<CustomTicker>();
        intervalSeconds = precision;
        return ticker;
    }


    public void AddListener(Action<float> callback) => action += callback;


    public void RemoveListener(Action<float> callback) => action -= callback;
}