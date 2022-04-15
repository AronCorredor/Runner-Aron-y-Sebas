using System.Collections.Generic;
using UnityEngine;

public class Instantiator_Nafta : MonoBehaviour
{
    public List<GameObject> Gasolina;
    public GameObject instantiatePos;
    public float respawningTimer;
    private float time = 0;

    void Start()
    {
        Controller_Nafta.naftaVelocity = 2;
    }

    void Update()
    {
        SpawnNafta();
        ChangeVelocity();
    }

    private void ChangeVelocity() //Cambia la velocidad 
    {
        time += Time.deltaTime;
        Controller_Nafta.naftaVelocity = Mathf.SmoothStep(1f, 15f, time / 45f);
    }

    private void SpawnNafta()
    {
        respawningTimer -= Time.deltaTime;

        if (respawningTimer <= 0)
        {
            Instantiate(Gasolina[UnityEngine.Random.Range(0, Gasolina.Count)], instantiatePos.transform); // Spawnea la nafta
            respawningTimer = UnityEngine.Random.Range(2, 6); //Le da un valor random a cada cuanto se va a spawnear nafta
        }
    }
}