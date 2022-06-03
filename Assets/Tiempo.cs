using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tiempo : MonoBehaviour
{
    public Text txt_customTime;
    float customTime;
    // Start is called before the first frame update
    void Start()
    {
        customTime = 120;
    }

    // Update is called once per frame
    void Update()
    {
        if (customTime < 1)
        {
            customTime = 0;
            txt_customTime.text = customTime.ToString();
        }
        else 
        { 
        customTime -= Time.deltaTime;
        txt_customTime.text = Mathf.Floor(customTime).ToString(); 
        // como redondear hacia arriba
        }
    }
}
