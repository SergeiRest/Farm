using UnityEngine;
using Zenject;
using Gameplay.Player;

namespace Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Player player; 
        
        public override void InstallBindings()
        {
            Player playerInstance = Container.InstantiatePrefabForComponent<Player>(player, new Vector3(0, 2, 0),
                Quaternion.identity, null);

            Container.Bind<Player>().FromInstance(playerInstance).AsSingle().NonLazy();
            
            Camera.main.transform.SetParent(playerInstance.transform);
        }
    }
}