using Game.Resources.View;
using UnityEngine;
using Zenject;

public class ResourcesInstaller : MonoInstaller
{
    [SerializeField] private ResourcesViewContainer resourcesViewContainer;
    public override void InstallBindings()
    {
        Container.Bind<ResourcesViewContainer>().FromInstance(resourcesViewContainer).AsSingle().NonLazy();
    }
}
