using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector3 moveInput;
    public float horizontal = 0f;
    public float vertical = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        moveInput = (new Vector3(horizontal, 0, vertical)).normalized;

        transform.Translate(moveSpeed * Time.deltaTime * moveInput); 
    }
}
