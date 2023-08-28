using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Player;
using UnityEngine;
using Zenject;

public class NewGridTrigger : MonoBehaviour
{
    [Inject] private GridInitializer gridInitializer;

    [SerializeField] private string gridName;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            gridInitializer.Save(gridName);
        }
    }
}
