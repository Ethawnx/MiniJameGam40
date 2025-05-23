using UnityEngine;
using MoreMountains.Tools;
public class BackGroundPoolableObject : MMPoolableObject
{
    private Camera mainCamera;
    public float XpositionAmout; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (IsOffscreenLeft(gameObject.transform.position))
        {
            Destroy();
        }
    }
    bool IsOffscreenLeft(Vector3 worldPosition)
    {
        // Convert the object's world position to viewport space
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(worldPosition);

        // Check if the object is beyond the left edge of the screen
        return viewportPosition.x < XpositionAmout;
    }
}
