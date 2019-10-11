using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSquareMovement : MonoBehaviour
{
    public float speed;
    public float turn_speed;

    public float slow_ratio = 0.5f;

    void Start()
    {
        speed = 0.2f;
        turn_speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float turnHorizontal = Input.GetAxis("Turn");

        Vector3 moveDirection = new Vector3(moveHorizontal, 0, moveVertical);
        Vector3 turnDirection = new Vector3(0, turnHorizontal, 0);

        transform.Translate(moveDirection * speed);
        transform.Rotate(turnDirection * turn_speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BallObstacle") {
            print("Enter Trigger " + other.tag);

            speed *= slow_ratio;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "BallObstacle") {
            print("Exit Trigger " + other.tag);

            speed /= slow_ratio;
        }
    }
}
