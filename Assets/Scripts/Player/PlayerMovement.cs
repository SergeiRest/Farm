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
            Vector2 normalized = moveVector.normalized;
            Vector3 pos = transform.position + new Vector3(normalized.x, 0, normalized.y);
            transform.position = pos;
        }
    }
}