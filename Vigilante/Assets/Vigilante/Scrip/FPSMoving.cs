using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMoving : MonoBehaviour
{
    private float speed = 15f;
    private float speedd = 30f;

    void Update()
    {
        MovinPlayer();
    }

    public void MovinPlayer()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += transform.forward * speedd * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position -= transform.forward * speedd * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position -= transform.right * speedd * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += transform.right * speedd * Time.deltaTime;
            }
        }


    }
}
