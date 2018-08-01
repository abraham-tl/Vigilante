using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Weapon : MonoBehaviour {

    int amon;
    public float distance;
	// Use this for initialization
	void Start () {
        amon = 10;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1") && amon > 0)
        {
            RaycastHit disparo;//vARIABLE  RaycastHit

            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out disparo, distance);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distance, Color.black);
           
            if (disparo.collider != null && disparo.transform.tag == "Enemy")
            {
                
            }
        }
    }
}
