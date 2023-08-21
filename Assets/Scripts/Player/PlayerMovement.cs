using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerMovement
    {
        private Transform transform;

        public PlayerMovement(Transform transform)
        {
            this.transform = transform;
        }

        public void MoveTo(Vector2 moveVector)
        {
            Vector3 pos = transform.position + new Vector3(moveVector.x, 0, moveVector.y);
            transform.position = pos;
        }
    }
}