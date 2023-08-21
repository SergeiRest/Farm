using Input;
using UnityEngine;
using Zenject;

public sealed class InputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<InputService>().FromNew().AsSingle().NonLazy();
    }
}
