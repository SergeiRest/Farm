using System;
using UnityEngine;

namespace Input
{
    public class InputService
    {
        public Action<Vector2> Move;
        
        public void SendMessage(Vector2 cords)
        {
            Debug.Log(cords);
            Move?.Invoke(cords);
        }
    }
}