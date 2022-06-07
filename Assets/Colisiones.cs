using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colisiones : MonoBehaviour
{
    public AudioClip SonidoGol;
    public AudioSource fuenteaudio;
    public Text puntaje1;
    public Text puntaje2;
    public Text ganando;
    public Text gol;
    int golJug1;
    int golJug2;
    
    // Start is called before the first frame update
    void Start()
    {
        golJug1 = System.Convert.ToInt32(puntaje1);
        golJug2 = System.Convert.ToInt32(puntaje2);
    }

    // Update is called once per frame
    void Update()
    {
        while (golJug1 > golJug2)
        {
            ganando.text = "Jugador 1 está ganando";
        }
        while (golJug2 > golJug1)
        {
            ganando.text = "Jugador 2 está ganando";
        }
        while (golJug1 == golJug2)
        {
            ganando.text = "Están empatando";
        }

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Arco1")
        {
            golJug2++;
            puntaje2.text = golJug2.ToString();
            fuenteaudio.clip = SonidoGol;
            fuenteaudio.Play();
            transform.position = new Vector3(0, 0.85f, -0.55f);
         
            // gol jugador 2
        }
        if (col.gameObject.name == "Arco2")
        {
            golJug1++;
            puntaje1.text = golJug1.ToString();
            fuenteaudio.clip = SonidoGol;
            fuenteaudio.Play();
            transform.position = new Vector3(0, 0.85f, -0.55f);
            // gol jugador 1
        }
    }
}
