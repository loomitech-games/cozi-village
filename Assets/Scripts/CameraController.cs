using UnityEngine;

public class CameraController : MonoBehaviour
{
    public enum ActivateWith { Any, RightMouseClick , LeftMouseClick };
    public ActivateWith activateWith;
    public Transform followTarget;
    public Quaternion targetRotation;
    public Vector2 framingOffset = new Vector2 (0, 1);
    public float distance = 5;
    public float minDistance = 2;
    public float maxDistance = 10;
    public float zoomSpeed = 1;
    public float minElevation = 45;
    public float maxElevation = 90;
    public float rotationSpeed = 2f;
    public bool invertX;
    public bool invertY;
    public float rotationX;
    public float rotationY;
    public bool rightMouseDown;
    public bool leftMouseDown;
    public bool active;

    private void Start()
    {
        targetRotation = Quaternion.Euler(rotationX, rotationY, 0);
        transform.position = followTarget.position - (targetRotation * new Vector3(0, 0, distance));
        transform.rotation = targetRotation;
    }

    private void Update()
    {
        rightMouseDown = Input.GetMouseButton(1);
        leftMouseDown = Input.GetMouseButton(0);


        bool allow = ((activateWith == ActivateWith.Any) || 
            ((activateWith == ActivateWith.RightMouseClick) && rightMouseDown) ||
            ((activateWith == ActivateWith.LeftMouseClick) && leftMouseDown)) ? true : false;

        active = allow;

        if(allow)
        {
            rotationY += Input.GetAxis("Mouse X") * rotationSpeed * (invertX ? -1 : 1);
            targetRotation = Quaternion.Euler(rotationX, rotationY, 0);

            rotationX += Input.GetAxis("Mouse Y") * rotationSpeed * (invertY ? -1 : 1);
            rotationX = Mathf.Clamp(rotationX, minElevation, maxElevation);

            distance -= (Input.mouseScrollDelta.y * zoomSpeed);
            distance = distance > maxDistance ? maxDistance : distance;
            distance = distance < minDistance ? minDistance : distance;

            var focusPosition = followTarget.position + new Vector3(framingOffset.x, framingOffset.y);
            transform.position = focusPosition - (targetRotation * new Vector3(0, 0, distance));
            transform.rotation = targetRotation;
        } 
        else
        {
            targetRotation = Quaternion.Euler(rotationX, rotationY, 0);
            var focusPosition = followTarget.position + new Vector3(framingOffset.x, framingOffset.y);
            transform.position = focusPosition - (targetRotation * new Vector3(0, 0, distance));
            transform.rotation = targetRotation;
        }
    }
}
