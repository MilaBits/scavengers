using System;
using UnityEngine;

namespace code
{
    public abstract class VehicleMovementBase : MonoBehaviour
    {
        protected Rigidbody Rb;
        protected MovementSettings Settings;

        private void Update()
        {
            ProcessInput();
            Move();
        }

        protected abstract void ProcessInput();

        public void FixedUpdate()
        {
        }
        
        public abstract void Move();
        public void Init(MovementSettings settings)
        {
            enabled = true;
            Settings = settings;
        }

        private void OnEnable()
        {
            Rb = GetComponentInChildren<Rigidbody>();
        }
    }
}