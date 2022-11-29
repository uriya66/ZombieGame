using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitvity = 100f;
    public Transform playerBody;
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Making sure the mouse doesn't leave the game window
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the access input of the mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitvity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitvity * Time.deltaTime;

        xRotation -= mouseY;
        // Making sure we can onle look 90 up and 90 down
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        // Change the postion of the character
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        // Rotate the player body
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
