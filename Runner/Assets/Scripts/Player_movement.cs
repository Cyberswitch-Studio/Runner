using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    private int currentPath = 1; // 0 - left path, 1 - middle path, 2 - right path
    public float lineDistance = 3.33f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        direction.z = forwardSpeed;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentPath++;
            if (currentPath == 3)
                currentPath = 2;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentPath--;
            if (currentPath == -1)
                currentPath = 0;
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (currentPath == 0)
        {
            targetPosition += Vector3.left * lineDistance;

        }
        
        else if (currentPath == 2)

        {
            targetPosition += Vector3.right * lineDistance;
        }

        //transform.position = targetPosition;
        if (transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
        {
            controller.Move(moveDir);
        }
        else
        {
            controller.Move(diff);
        }
    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }
}