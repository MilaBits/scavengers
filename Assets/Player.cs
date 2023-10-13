using code;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Vehicle controlledVehicle;
    [SerializeField] private PlayerCamera playerCamera;

    private Vehicle _prevControlledVehicle;

    void Update()
    {
        if (controlledVehicle != _prevControlledVehicle)
        {
            playerCamera.SetTarget(controlledVehicle.transform);
        }   
    }
}
