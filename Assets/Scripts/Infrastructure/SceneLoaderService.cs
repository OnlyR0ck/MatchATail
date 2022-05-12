using System;
using System.Collections;
using Infrastructure;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderService : ISceneLoaderService
{
    private readonly ICoroutineRunner coroutineRunner;

    
    public SceneLoaderService(ICoroutineRunner coroutineRunner) => 
        this.coroutineRunner = coroutineRunner;

    
    public void Load(string name, Action onLoaded = null) =>
        coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));

    
    private IEnumerator LoadScene(string nextScene, Action onLoaded = null)
    {
        if (SceneManager.GetActiveScene().name == nextScene)
        {
            onLoaded?.Invoke();
            yield break;
        }
      
        AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

        while (!waitNextScene.isDone)
        {
            yield return null;
        }

        onLoaded?.Invoke();
    }
}