using MoreMountains.CorgiEngine;
using Unity.VisualScripting;
using UnityEngine;

public class Scroll : ParallaxElement
{
    public float speed = 0.5f;

    private float offset;
    private Material mat;

    protected override void OnEnable()
    {
        if (Camera.main == null)
            return;

        _camera = Camera.main;
        if (_camera != null)
        {
            _parallaxCamera = _camera.GetComponent<ParallaxCamera>();
            _cameraTransform = _camera.transform;
            _previousCameraPosition = _cameraTransform.position;

            mat = GetComponent<Renderer>().sharedMaterial;
        }
    }


    protected override void ProcessParallax()
    {
        if (_parallaxCamera == null)
        {
            return;
        }

        if (!Application.isPlaying && !_parallaxCamera.MoveParallax)
        {
            return;
        }
        if (Application.isPlaying)
        {
            offset += (Time.deltaTime * speed) / 10f;
            mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }

        if (_parallaxCamera.MoveParallax && !_previousMoveParallax)
        {
            _previousCameraPosition = _cameraTransform.position;
        }

        _previousMoveParallax = _parallaxCamera.MoveParallax;

        _speed.x = HorizontalSpeed;
        _speed.y = VerticalSpeed;
        _speed.z = 0f;

        _difference = _cameraTransform.position - _previousCameraPosition;
        float direction = (MoveInOppositeDirection) ? -1f : 1f;
        transform.position += Vector3.Scale(_difference, _speed) * direction;

        _previousCameraPosition = _cameraTransform.position;

       
    } 
}