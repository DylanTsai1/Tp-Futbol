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
    public GameObject panelDeGol;
    int golJug1 = 0;
    int golJug2 = 0; 
    string GolDeQuien;
    float customTime;
    bool isCounting; 
    // Start is called before the first frame update
    void Start()
    {
        golJug1 = System.Convert.ToInt32(puntaje1);
        golJug2 = System.Convert.ToInt32(puntaje2);

        panelDeGol.SetActive(false);

        customTime = 5;
        isCounting = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (customTime < 5)
        {
            customTime -= Time.deltaTime;
        }
        if (customTime < 0)
        {
            panelDeGol.SetActive(false);
            customTime = 5;
            //La pelota vuelve a la posición inicial
            transform.position = new Vector3(0, 5f, -0.55f);
        }
        // while (golJug1 > golJug2)
        //  {
        //    ganando.text = "Jugador 1 está ganando";
        // }
        // while (golJug2 > golJug1)
        // {
        //     ganando.text = "Jugador 2 está ganando";
        //}
        // while (golJug1 == golJug2)
        // {
        //     ganando.text = "Están empatando";
        //  }

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Arco1")
        {
            // Suma puntaje del marcador del jugador2
            golJug2++; 
            puntaje2.text = golJug2.ToString();
            // Se escucha el sonido de gol
            fuenteaudio.clip = SonidoGol;
            fuenteaudio.Play();
            // Aparece el panel de gol diciendo que el jugador 1 hizo gol
            panelDeGol.SetActive(true);
            customTime -= Time.deltaTime;
            gol.text = "Gol de jugador 2";
        
          
          
        }
        
        if (col.gameObject.name == "Arco2")
        {
            // Suma puntaje del marcador del jugador 1
            golJug1++;
            puntaje1.text = golJug1.ToString();
            // Se escucha el sonido de gol
            fuenteaudio.clip = SonidoGol;
            fuenteaudio.Play();
            // Aparece el panel de gol diciendo que el jugador 1 hizo gol
            panelDeGol.SetActive(true);
            customTime -= Time.deltaTime;
            gol.text = "Gol de jugador 1";

             

        }
       

    }
    

}
