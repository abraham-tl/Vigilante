using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Array : MonoBehaviour {
    public int[] num;
    int aux;
    int cont;
	// Use this for initialization
	void Start () {
		num = new int[9];
        cont = 0;
        while (cont < 9)
        {
            aux = Random.Range(1, 11);
            if (cont == 0)
            {
                num[cont] = aux;
                cont ++;
            }
            else if(!Validar_Repetido(aux,cont))
            {
                num[cont] = aux;
                cont ++; 
            }            
        }
        Encontrar_Faltante();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    bool Validar_Repetido(int aux,int tam)
    {
        bool encontrado = false;
        for (int i = 0;i <=tam;i++)
        {
            if(num[i] == aux)
            {
                encontrado = true;              
                return encontrado;               
            }
        }
        return encontrado;
    }

    void Encontrar_Faltante()
    {
        int sumatoria_a = 0;
        int sumatoria_b = 0;
        for (int i = 0;i <9;i++)
        {
            sumatoria_a += num[i];
            sumatoria_b += (i+1);
        }
        sumatoria_b += 10;
        print("FALTA EL" + (sumatoria_b-sumatoria_a));
    }

}
