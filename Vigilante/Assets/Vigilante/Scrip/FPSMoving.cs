using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMoving : MonoBehaviour
{
    public  float speed = 3f;
    float spedd;
    Animator anim;
    float rotate;
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
        if (Input.GetKey(KeyCode.A))
        {
            rotate -= 1;
            transform.eulerAngles = new Vector3(0, rotate, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rotate += 1;
            transform.eulerAngles = new Vector3(0, rotate, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
           anim.SetTrigger("walk");
           transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetTrigger("WalkBack");
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
       else
        {
           anim.SetTrigger("idle");     
        }
    }
}
