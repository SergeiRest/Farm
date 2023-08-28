using Game.Resources.View;
using UnityEngine;
using Zenject;

public class ResourcesInstaller : MonoInstaller
{
    [SerializeField] private ResourcesViewModel resourcesViewContainer;
    public override void InstallBindings()
    {
        Container.Bind<ResourcesViewModel>().FromInstance(resourcesViewContainer).AsSingle().NonLazy();
    }
}
