using System;
using Infrastructure.ServicesHub;

public interface ISceneLoader : IService
{
    void Load(string name, Action onLoaded = null);
}