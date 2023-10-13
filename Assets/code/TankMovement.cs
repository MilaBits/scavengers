using UnityEngine;

namespace code
{
    public class TankMovement : VehicleMovementBase
    {
        private Vector2 _directionalInput;
        
        protected override void ProcessInput()
        {
            _directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        public override void Move()
        {
            float movement = _directionalInput.y * Settings.moveSpeed.y;
            Quaternion deltaRotation = Quaternion.Euler(0, _directionalInput.x * Settings.turnSpeed * Time.deltaTime, 0);

            Transform t = transform;
            Rb.MoveRotation(Rb.rotation * deltaRotation);
            Rb.velocity = t.forward * movement;
        }
    }
}