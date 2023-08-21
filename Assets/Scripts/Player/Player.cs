using System;
using Input;
using UnityEngine;
using Zenject;

namespace Gameplay.Player
{
    public class Player : MonoBehaviour
    {
        [Inject] private InputService inputService;
     
        private PlayerMovement playerMovement;

        private void Start()
        {
            playerMovement = new PlayerMovement(transform);
            inputService.Move += playerMovement.MoveTo;
        }
    }
}