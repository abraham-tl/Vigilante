using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {
    public int Vida;
    Vector3 posicion_inicial;
	// Use this for initialization
	void Start () {
        Vida = 3;
        posicion_inicial = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Quitar_Vida(int dano)
    {
        if (Vida > 0)
        {
            Vida = Vida - dano;
           
        }
        else
        {
            Vida = 3;
            transform.position = posicion_inicial;
        }
        
    }
}
