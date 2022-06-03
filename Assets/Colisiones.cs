using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisiones : MonoBehaviour
{
    public AudioClip gol;
    AudioSource fuenteaudio;
    // Start is called before the first frame update
    void Start()
    {
        fuenteaudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Arco1")
        {
            fuenteaudio.clip = gol;
            fuenteaudio.Play();
            // gol jugador 2
        }
        if (col.gameObject.name == "Arco2")
        {
            fuenteaudio.clip = gol;
            fuenteaudio.Play();
            // gol jugador 1
        }
    }
}
