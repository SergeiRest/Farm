using System;
using UnityEngine;

namespace Gameplay.Build
{
    public class BuildTrigger : AbstractTrigger
    {
        protected override void OnTriggerExit(Collider other)
        {
            if(other.TryGetComponent(out Player.Player player))
                    Exit?.Invoke();
        }

        protected override void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Player.Player player))
                Enter?.Invoke();
        }
    }
}