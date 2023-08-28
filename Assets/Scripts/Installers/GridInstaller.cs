using UnityEngine;
using Zenject;

public class GridInstaller : MonoInstaller
{
    [SerializeField] private GridInitializer gridInitializer;

    public override void InstallBindings()
    {
        Container.Bind<GridInitializer>().FromInstance(gridInitializer).AsSingle().NonLazy();
    }
}
