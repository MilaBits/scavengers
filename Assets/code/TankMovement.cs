using UnityEngine;

namespace code
{
    public class TankMovement : VehicleMovementBase
    {
        public override void Move(Vector2 directionalInput)
        {
            float forwardMovement = directionalInput.y * Settings.moveSpeed * Time.deltaTime;
            float rotation = directionalInput.x * Settings.turnSpeed * Time.deltaTime;

            Transform t;
            (t = transform).Rotate(Vector3.up, rotation);
            t.position += t.forward * forwardMovement;
        }
    }
}