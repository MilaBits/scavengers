using System;
using System.Collections.Generic;
using UnityEngine;

namespace code
{
    [Serializable]
    public class MovementSettings
    {
        public enum MovementType
        {
            Walker,
            Tank
        }
        
        public static Dictionary<MovementType, Type> MovementTypeToComponent = new() {
            { MovementType.Walker, typeof(WalkerMovement) },
            { MovementType.Tank, typeof(TankMovement) },
        };
        
        public Type GetMovementType => MovementTypeToComponent[movementType];
        
        public MovementType movementType;
        [Space]
        public Vector2 moveSpeed = new Vector2(2f,5f);
        public float turnSpeed = 100f;
        [Space]
        public bool mouseRelative = false;
    }
}