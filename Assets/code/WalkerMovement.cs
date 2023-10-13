using UnityEngine;

namespace code
{
    public class WalkerMovement : VehicleMovementBase
    {
        private Vector2 _movement;
        private float _rotation;
        protected override void ProcessInput()
        {
            _movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * Settings.moveSpeed;
            _rotation = Input.GetAxisRaw("Rotational");
        }

        public override void Move()
        {
            Vector2 movement = _movement.normalized * Settings.moveSpeed;
            Quaternion deltaRotation = Quaternion.Euler(0, _rotation * Settings.turnSpeed * Time.deltaTime, 0);
            
            Rb.MoveRotation(Rb.rotation * deltaRotation);
            Rb.velocity = Rb.rotation * new Vector3(movement.x, 0, movement.y);
        }
    }
}