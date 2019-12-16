using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaBloque : MonoBehaviour
{
    [SerializeField] Transform destino;
    [SerializeField] float velocidadCaida;

    //variables a guardar
    private Vector3 inicioBloque, finBloque; 
    // Start is called before the first frame update
    void Start()
    {
        if(destino != null)
        {
            destino.parent = null;
            inicioBloque = transform.position;
            finBloque = destino.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(destino != null)
        {
            float deltaVelocidad = velocidadCaida * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, destino.position, deltaVelocidad);
        }
        if(transform.position == destino.position)
        {
            destino.position = (destino.position == inicioBloque) ? finBloque : inicioBloque;
        }
    }
}
