using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum Estados { Esperando, Patrullando, Persiguiendo };
public class Enemy : MonoBehaviour {

    public float timer;
    public float timer2;
    Vector3[] positions;
    int pos;
    public Estados estado;

    public NavMeshAgent nav;
    Vector3 uiltima_posicion;
    
    public GameObject hero;
    public float distancia = 5;


	// Use this for initialization
	void Start () {
        timer = 0;
        timer2 = 1.5f;
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
        
        switch (estado)
        {
            case Estados.Patrullando:
                Patrullar();
                break;
            case Estados.Esperando:
               
                Esperar(5f);
                break;
            case Estados.Persiguiendo:
                Perseguir();
                break;
        }
	}

    void Patrullar()
    {
       if( Perimetro())
        {
            Apuntar();
        }
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
            timer = 0f;
            nav.speed = 0f;
            estado = Estados.Esperando;          
        }     
    }
    
    void Esperar(float tiempo)
    { 
        timer = timer + Time.deltaTime;
        if (timer >= tiempo)
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
        if (Apuntar())
        {
            timer2 -= Time.deltaTime;
            if (timer2 <0)
            {
                disparar();
            }
            
        }
        else
        {           
            if ((uiltima_posicion - transform.position).magnitude < 1)
            {
                estado = Estados.Patrullando;
            }
        }
    }

    public bool Perimetro()
    {
        if ((hero.transform.position - transform.position).magnitude <= 10)
        {
            return true;       
        }
        else
        {
               return false; 
        }      
   }

    public void disparar()
    {
       
        RaycastHit disparo;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out disparo, distancia);
        timer2 = timer2 + Time.deltaTime;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distancia, Color.black);
            timer2 = 1.5f;
 
        if (disparo.collider != null && disparo.transform.tag == "Hero")
        {
            FindObjectOfType<Hero>().Quitar_Vida(1);
           // disparo.collider.gameObject.GetComponent<Hero>().Quitar_Vida(1);
        }
       
    }

    public  bool Apuntar()
    {
        transform.LookAt(hero.transform);
        RaycastHit perimetro;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out perimetro, 10f);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10f, Color.red);
        
        if (perimetro.collider != null && perimetro.transform.tag == "Hero")
        {
            uiltima_posicion = hero.transform.position;
            estado = Estados.Persiguiendo;
            return true;
        }
        else
        {
            return false;
        }
    }
 }
