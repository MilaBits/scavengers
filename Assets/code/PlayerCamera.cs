using System;
using Flask;
using Shapes;
using UnityEngine;

namespace code
{
    public class PlayerCamera : ImmediateModeShapeDrawer
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _omega = 1;
        [SerializeField] private bool lockCameraAngle = false;
        [Space]
        [SerializeField] private bool drawDebug = false;
        
        private CameraTarget _cameraTarget;
        private DTweenVector3 _position = new DTweenVector3(Vector3.zero, 1);
        
        private void Awake()
        {
            if (_target) _cameraTarget = _target.GetComponent<CameraTarget>();
        }

        void Update()
        {
            Vector3 targetPos = GetTargetPos();
            Vector3 viewPos = GetViewPos();
            
            _position.omega = _omega;
            _position.Step(targetPos);
            transform.position = _position;

            if (lockCameraAngle)
            {
                transform.LookAt(transform.position + (viewPos - targetPos));
            }
            else
            {
                transform.LookAt(viewPos);
            }
        }

        public override void DrawShapes(Camera cam)
        {
            if (!drawDebug) return;
            
            using (Draw.Command(cam))
            {
                Draw.Thickness = 2f;
                Draw.ThicknessSpace = ThicknessSpace.Pixels;
                Draw.LineGeometry = LineGeometry.Flat2D;
                
                Vector3 targetPos = GetTargetPos();
                Vector3 viewPos = GetViewPos();
                
                Draw.Color = Color.green;
                Draw.Line(targetPos, viewPos);
                
                Draw.Color = Color.magenta;
                Draw.Line(targetPos, transform.position + (viewPos - targetPos));
            }
        }

        private Vector3 GetTargetPos() => _cameraTarget ? _cameraTarget.GetTargetPos() : _target.position;
        private Vector3 GetViewPos() => _cameraTarget ? _cameraTarget.GetViewPos() : _target.position;

        public void SetTarget(Transform newTarget)
        {
            _target = newTarget;
            if (newTarget.TryGetComponent(out CameraTarget camTarget))
            {
                _cameraTarget = camTarget;
            }
        }
    }
}
