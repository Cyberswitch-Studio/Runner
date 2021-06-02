using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    private int currentLane = 1; // 0 - left path, 1 - middle path, 2 - right path
    public float lineDistance = 4;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        direction.z = forwardSpeed;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentLane++;
            if (currentLane == 3)
                currentLane = 2;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentLane--;
            if (currentLane == -1)
                currentLane = 0;
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (currentLane == 0)
        {
            targetPosition += Vector3.left * lineDistance;

        }
        
        else if (currentLane == 2)

        {
            targetPosition += Vector3.right * lineDistance;
        }

        transform.position = targetPosition;
    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }
}