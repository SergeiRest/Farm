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

        [Inject]
        public void Init()
        {
            playerMovement = new PlayerMovement(transform);
            inputService.Move += playerMovement.MoveTo;
        }
    }
}