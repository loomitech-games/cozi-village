using UnityEngine;

public class CameraController : MonoBehaviour
{
    public enum ActivateWith { Any, RightMouseClick , LeftMouseClick };
    public ActivateWith activateWith;
    public Transform followTarget;
    public Quaternion targetRotation;
    public float distance = 5;
    public float minDistance = 2;
    public float maxDistance = 10;
    public float zoomSpeed = 1;
    public float minElevation = 45;
    public float maxElevation = 90;
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
            rotationY += Input.GetAxis("Mouse X");
            targetRotation = Quaternion.Euler(rotationX, rotationY, 0);

            rotationX += Input.GetAxis("Mouse Y");
            rotationX = rotationX < minElevation ? minElevation : rotationX;
            rotationX = rotationX > maxElevation ? maxElevation : rotationX;

            distance -= (Input.mouseScrollDelta.y * zoomSpeed);
            distance = distance > maxDistance ? maxDistance : distance;
            distance = distance < minDistance ? minDistance : distance;

            transform.position = followTarget.position - (targetRotation * new Vector3(0, 0, distance));
            transform.rotation = targetRotation;
        }
    }
}
