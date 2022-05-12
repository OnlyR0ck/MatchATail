using System;
using Infrastructure.ServicesHub;

public interface ISceneLoaderService : IService
{
    void Load(string name, Action onLoaded = null);
}