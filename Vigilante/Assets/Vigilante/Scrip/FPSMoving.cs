using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMoving : MonoBehaviour
{
    public  float speed = 3f;
    float spedd;
    Animator anim;
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = (spedd*2);
        }
        else
        {
            speed = spedd;
        }
        MovinPlayer();
    }
    private void Start()
    {        
        spedd = speed;
        anim = GetComponent<Animator>();
    }

    public void MovinPlayer()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetTrigger("walk");
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetTrigger("WalkBack");
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        else
        {
            anim.SetTrigger("idle");
      
        }
    }
}
