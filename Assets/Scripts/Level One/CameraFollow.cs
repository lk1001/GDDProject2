using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Object to follow")]
    public Transform target;

    //Bound camera to limits
    public bool limitBounds;
    public float left = -5f;
    public float right = 5f;
    public float bottom = -5f;
    public float top = 5f;

    private Vector3 lerpedPosition;
    private Camera _camera;

    #region Initialization
    private void Awake() {
        _camera = GetComponent<Camera>();
    }
    #endregion

    #region Updates
    void FixedUpdate()
    {
        if(target != null)
        {
            // Find the right position between the camera and the object
            lerpedPosition = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 100f);
            lerpedPosition.z = -10f;
        }
    }

    void LateUpdate ()
    {
        if(target != null)
        {
            // Move the camera in the position found previously
            transform.position = lerpedPosition;

            // Bounds the camera to the limits (if enabled)
            if(limitBounds) {
                Vector3 bottomLeft = _camera.ScreenToWorldPoint(Vector3.zero);
                Vector3 topRight = _camera.ScreenToWorldPoint(new Vector3(_camera.pixelWidth, _camera.pixelHeight));
                Vector2 screenSize = new Vector2(topRight.x - bottomLeft.x, topRight.y - bottomLeft.y);

                Vector3 boundPosition = transform.position;
                if (boundPosition.x > right - (screenSize.x / 2f)) {
                    boundPosition.x = right - (screenSize.x / 2f);
                }
                if (boundPosition.x < left + (screenSize.x / 2f)) {
                    boundPosition.x = left + (screenSize.x / 2f);
                }

                if (boundPosition.y > top - (screenSize.y / 2f)) {
                    boundPosition.y = top - (screenSize.y / 2f);
                }
                if (boundPosition.y < bottom + (screenSize.y / 2f)) {
                    boundPosition.y = bottom + (screenSize.y / 2f);
                }
                transform.position = boundPosition;
            }
        }
    }
    #endregion
}
