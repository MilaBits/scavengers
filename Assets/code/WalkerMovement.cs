using UnityEngine;

namespace code
{
    public class WalkerMovement : VehicleMovementBase
    {
        public override void Move(Vector2 directionalInput)
        {
            Vector2 movement = directionalInput * (Settings.moveSpeed * Time.deltaTime);
            transform.Translate(movement.x, 0, movement.y);
        }
    }
}