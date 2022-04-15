﻿using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject cam;
    private float length, startPos;
    public float parallaxEffect;
    public GameObject player;

    void Start()
    {
        //Instanciar valores fondo
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {

        //Loopear fondo
        transform.position = new Vector3(transform.position.x - parallaxEffect, transform.position.y, transform.position.z);
        if (transform.localPosition.x < -20)
        {
            transform.localPosition = new Vector3(20, transform.localPosition.y, transform.localPosition.z);
        }

        if (Controller_Hud.gameOver == true)
        {
            transform.localPosition = new Vector3(0, transform.localPosition.y, transform.localPosition.z);
        }
    }

}
