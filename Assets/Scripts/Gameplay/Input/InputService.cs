using System;
using UnityEngine;

namespace Input
{
    public class InputService
    {
        public Action<Vector2> Move;
        
        public void SendMessage(Vector2 cords)
        {
            bool zero = cords == Vector2.zero;
            if(zero)
                return;
            Move?.Invoke(cords);
        }
    }
}