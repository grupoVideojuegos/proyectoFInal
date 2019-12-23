using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolita : MonoBehaviour
{
    [SerializeField] float velocidad;
    private Transform jugador;
    private Vector2 target;

    private void Start()
    {
        jugador = GameObject.FindObjectOfType<Jugador>().transform;
        target = new Vector2(jugador.position.x, jugador.position.y);
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,target,velocidad*Time.deltaTime);
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestruirBala();
        } 
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
    void DestruirBala()
    {
        Destroy(gameObject);
    }
}
