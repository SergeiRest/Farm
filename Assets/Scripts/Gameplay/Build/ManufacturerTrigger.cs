using Gameplay.Player;
using UnityEngine;

public class ManufacturerTrigger : AbstractTrigger
{
    protected override void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out Player player))
            Exit?.Invoke();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
            Enter?.Invoke();
    }
}
