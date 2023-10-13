using UnityEngine;

namespace code
{
    public abstract class VehicleMovementBase : MonoBehaviour
    {
        protected MovementSettings Settings;
        public void Update()
        {
            Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        }
        public abstract void Move(Vector2 directionalInput);
        public void Init(MovementSettings settings)
        {
            enabled = true;
            Settings = settings;
        }
    }
}