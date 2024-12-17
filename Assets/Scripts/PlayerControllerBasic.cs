using UnityEngine;

public class PlayerControllerBasic : MonoBehaviour
{
    public Transform sourceOrientation;
    public Quaternion targetRotation;
    public Vector3 rotationAngles;
    public float direction = 90;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool shouldOrientate = false;

        if (Input.GetKey(KeyCode.W))
        {
            direction = 0;
            shouldOrientate = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction = 90;
            shouldOrientate = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction = 180;
            shouldOrientate = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction = 270;
            shouldOrientate = true;
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            direction = 45;
            shouldOrientate = true;
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            direction = 135;
            shouldOrientate = true;
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            direction = 225;
            shouldOrientate = true;
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            direction = 315;
            shouldOrientate = true;
        }


        if(shouldOrientate)
        {
            rotationAngles = sourceOrientation.eulerAngles;
            targetRotation = Quaternion.Euler(0, rotationAngles.y + direction, 0);
            transform.rotation = targetRotation;
            transform.Translate(0,0,0.1f);
        }

    }
}
