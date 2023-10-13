using Shapes;
using UnityEngine;
using UnityEngine.Serialization;

[ExecuteAlways]
public class CameraTarget : ImmediateModeShapeDrawer
{
    [SerializeField] private Vector3 cameraOffset;
    [SerializeField] private Vector3 viewOffset;
    [SerializeField] private bool rotateOffset;
    [Space]
    [SerializeField] private bool drawDebug = false;

    public override void DrawShapes(Camera cam)
    {
        if (!drawDebug) return;

        using (Draw.Command(cam))
        {
            Draw.Sphere(GetTargetPos(), .1f, Color.red);
            Draw.Sphere(GetViewPos(), .1f, Color.blue);
        }
    }

    public Vector3 GetTargetPos()
    {
        Vector3 resultOffset = cameraOffset;
        
        if (rotateOffset) resultOffset = transform.rotation * cameraOffset;
        
        return transform.position + resultOffset;
    }

    public Vector3 GetViewPos()
    {
        Vector3 resultOffset = viewOffset;
        
        if (rotateOffset) resultOffset = transform.rotation * viewOffset;
        
        return transform.position + resultOffset;
    }

    public Vector3 GetStaticCameraDir()
    {
        return viewOffset - cameraOffset;
    }
}
