using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum Estados { Esperando, Patrullando, Persiguiendo };
public class Enemy : MonoBehaviour {

    public float timer;
    Vector3[] positions;
    int pos;
    public Estados estado;

    public NavMeshAgent nav;
    Vector3 uiltima_posicion;
    bool visto;
    public GameObject hero;


	// Use this for initialization
	void Start () {
        timer = 0;
        pos = 0;
        positions = new Vector3[5];
        positions[0] = new Vector3(22,1,22);
        positions[1] = new Vector3(-22,1,22);
        positions[2] = new Vector3(-22,1,-22);
        positions[3] = new Vector3(22,1,-22);

        estado = Estados.Patrullando;
    

	}

    public void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update () {
        Perimetro();
        switch (estado)
        {
            case Estados.Patrullando:
                Patrullar();
                break;
            case Estados.Esperando:
                Esperar();
                break;
            case Estados.Persiguiendo:
                Perseguir();
                break;

        }

        //patrullar();
	}

    void Patrullar()
    {
       
        if (pos <4)
        {
            if ((positions[pos] - transform.position).magnitude <= 1)
            {
                pos += 1;
            }
            nav.SetDestination(positions[pos]);
        }
        else
        {
            //timer = 0f;
            nav.speed = 0f;
            estado = Estados.Esperando;
        }

        
       
    }

    void Esperar()
    {
        timer = timer + Time.deltaTime;
        if (timer  >= 5)
        {
            nav.speed = 10;
            pos = 0;
            estado = Estados.Patrullando;
            timer = 0;
        }
    }

    void Perseguir()
    {
        nav.SetDestination(uiltima_posicion);
        //if ((hero.transform.position-transform.position).magnitude <= 10)
        //{
           
        //}
        //else
        //{
        //    estado = Estados.Patrullando;
        //}
    }

    public void Perimetro()
    {

        

        if ((hero.transform.position - transform.position).magnitude <= 10)
        {
            transform.LookAt(hero.transform);
            RaycastHit perimetro;
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out perimetro, 10f);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10f, Color.red);
            
            if (perimetro.collider != null && perimetro.transform.tag == "Hero")
            {
                uiltima_posicion = hero.transform.position;
                estado = Estados.Persiguiendo;
            }           
        }
        else
        {
            estado = Estados.Patrullando;
        }
    }
 }
