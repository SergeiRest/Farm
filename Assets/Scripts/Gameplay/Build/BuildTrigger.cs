using System;
using UnityEngine;

namespace Gameplay.Build
{
    public class BuildTrigger : MonoBehaviour
    {
        public Action Enter;
        public Action Exit;
        
        private void OnTriggerExit(Collider other)
        {
            if(other.TryGetComponent(out Player.Player player))
                    Exit?.Invoke();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Player.Player player))
                Enter?.Invoke();
        }
    }
}