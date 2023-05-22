using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{

    [SerializeField] 
    private CharacterController controller;
    [SerializeField] 
    private float speed = 11f;
    [SerializeField] 
    private float gravity = -30f; // -9.81

    private Vector3 verticalVelocity = Vector3.zero;
    private Vector2 horizontalInput;

    private void Update()
    {
        Vector3 horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * speed;
        controller.Move(horizontalVelocity * Time.deltaTime);

        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
    }

    public void ReceiveInput(Vector2 _horizontalInput)
    {
        horizontalInput = _horizontalInput;
    }
}
