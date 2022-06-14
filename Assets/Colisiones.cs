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
    float timetime;
    public Text txt_timetime;
    public GameObject prefab;
    public GameObject prefab2;
    // Start is called before the first frame update

    int prefabs = 0;
    void Start()
    {
        timetime = 120;
        golJug1 = 0;
        golJug2 = 0;
        puntaje2.text = golJug2.ToString();
        puntaje1.text = golJug1.ToString();

        panelDeGol.SetActive(false);

        customTime = 3;
        isCounting = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timetime < 1)
        {
            timetime = 0;
            txt_timetime.text = customTime.ToString();
        }
        else
        {
            timetime -= Time.deltaTime;
            txt_timetime.text = Mathf.Floor(timetime).ToString();
        }
            if (customTime < 3)
        {
            customTime -= Time.deltaTime;
        }
        if (customTime < 0)
        {
            panelDeGol.SetActive(false);
            customTime = 3;
            //La pelota vuelve a la posición inicial
            
        }
        if (timetime == 0)
        {

            Destroy(gameObject);
            if (golJug1 > golJug2)
            {
                panelDeGol.SetActive(true);
                gol.text = "Ganador: Jugador 1";
            }
            else if (golJug2 > golJug1)
            {
                panelDeGol.SetActive(true);
                gol.text = "Ganador: Jugador 2";
            }
            while (prefabs < 5)
            {
                Instantiate(prefab);
                Instantiate(prefab2);
                prefabs++;
            }
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
            transform.position = new Vector3(0, 5f, -0.55f);



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
            transform.position = new Vector3(0, 5f, -0.55f);

        }
       

    }
    

}
