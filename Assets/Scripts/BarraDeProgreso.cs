using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeProgreso : MonoBehaviour
{
    Slider Barra;

    public float max;
    public float act;
    public Text valorString;
    public static int cont = 100;
    public GameObject gasolina;
    public GameObject player;

    void Awake()
    {
        Barra = GetComponent<Slider>();

    }

    private void Start()
    {
        funcionPrueba();
    }


    void Update()
    {
        //ActualizarBarraDeProgreso(max, act);
    }

    void ActualizarBarraDeProgreso(float valorMax, float valorAct)
    {
        float porcentaje;
        porcentaje = valorAct / valorMax;
        Barra.value = porcentaje;
        valorString.text = porcentaje*100 + "%";
    }
    
    void funcionPrueba()
    {
        if (cont <= 100)
        {
            ActualizarBarraDeProgreso(100, cont);
            cont--;           
        }
        else
        {
            cont = 0;
        }
            Invoke("funcionPrueba", 1f);
        
    }

}
