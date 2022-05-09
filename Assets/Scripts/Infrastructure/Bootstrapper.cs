using System;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        private void Awake() => RegisterServices();

        private void RegisterServices() => ServicesHub.ServicesHub.Container.RegisterSingle(new GameFlowService());
    }
}