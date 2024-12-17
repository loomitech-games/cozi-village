using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 500f;
    public Vector3 moveInput;
    public float horizontal = 0f;
    public float vertical = 0f;

    public CameraController cameraController;
    public Animator animatorController;
    public Quaternion targetRotation;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        float moveAmount = Mathf.Abs(horizontal) + Mathf.Abs(vertical);

        moveInput = (new Vector3(horizontal, 0, vertical)).normalized;

        var moveDir = cameraController.planarRotation * moveInput;
        

        if(moveAmount > 0)
        {
            transform.position += moveSpeed * Time.deltaTime * moveDir;
            targetRotation = Quaternion.LookRotation(moveDir);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        animatorController.SetFloat("moveAmount", moveAmount);
    }
}
