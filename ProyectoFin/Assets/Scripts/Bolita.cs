using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolita : MonoBehaviour
{
    [SerializeField] AudioClip[] sonidos;
    
    [SerializeField] float speedX = 8f;
    [SerializeField] float speedY= 5f;
    //estados
    private Boolean inicio = false;
    private Rigidbody2D rb;
    

    //Componentes guardados en referencias
    AudioSource miAudio;
   
    // Start is called before the first frame update
    void Start()
    {
        
        miAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.left*1, ForceMode2D.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        if (!inicio)//para verificar que la bolita se quede pegada a la platafor y no vuelva a pegarse en cada update
        {
            
            LanzarAlClick();
        }
        
    }

    private void LanzarAlClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            inicio = true;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(speedX,speedY); // accediendo a la velocidad del componente rigidbody
            
        }
        
    }

    
    //para hacer que se ejecute el sonido al rebotar la bola
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //PARA QUE SOLO SE ESCUCHE EL SONIDO CUANDO YA HAYA INICIADO EL JUEGO 
        if (inicio)
        {
            //elegir un sonido random cada vez que entre en colision
            AudioClip sonido = sonidos[UnityEngine.Random.Range(0, sonidos.Length)];
            miAudio.PlayOneShot(sonido);
        }
        
    }
}
