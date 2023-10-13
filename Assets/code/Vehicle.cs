using UnityEngine;

namespace code
{
    public class Vehicle : MonoBehaviour
    {
        [SerializeField] private MovementSettings movementSettings;
        
        private VehicleMovementBase _movement;

        private void Awake()
        {
            _movement = GetComponent(movementSettings.GetMovementType) as VehicleMovementBase;
            if (!_movement)
            {
                Debug.Log("No movement type active!");
                return;
            }
            _movement.Init(movementSettings);
        }
    }
}
