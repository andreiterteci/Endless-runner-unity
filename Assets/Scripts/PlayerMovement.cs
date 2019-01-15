using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private CharacterController controller;
    private float speed = 5.0f;
    private Vector3 moveVector;
    private float vericalVelocity;
    private float gravity = 14.0f;
    private float jumpForce = 5.5f;
    private float animationDuration = 2.0f;
    private float startTime;
    

    private bool hasLost = false;

    private void Start () {
        
        controller = GetComponent<CharacterController>();
        startTime = Time.time;
    }

    private void Update() {

        if (hasLost == true)
            return;

        if (Time.time - startTime < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

        controller.Move(moveVector * Time.deltaTime);

        if (controller.transform.position.x < -1)
        {
            Vector3 poz = controller.transform.position;
            poz.x = -1;
            controller.transform.position = poz;
        }

        if (controller.transform.position.x > 1)
        {
            Vector3 poz = controller.transform.position;
            poz.x = 1;
            controller.transform.position = poz;
        }

        if (controller.isGrounded)
        {
            vericalVelocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.UpArrow))
                vericalVelocity = jumpForce;
        }
        else
        {
            vericalVelocity -= gravity * Time.deltaTime;
        }

        moveVector = Vector3.zero;

        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;

        moveVector.y = vericalVelocity;

        moveVector.z = speed;
    }

    public void setSpeed(float modify)
    {
        speed += modify/2;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.point.z > transform.position.z + controller.radius)
           Lose();
    }

    private void Lose()
    {
       hasLost = true;
        GetComponent<Score>().onLose();
    }
}
