using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustBrightness : MonoBehaviour
{
    // Start is called before the first frame update

    public float GammaCorrection;
    public Slider sliderval;


    void Start()
    {

    }

    
    void Update()
    {
        GammaCorrection = sliderval.value;

        RenderSettings.ambientLight = new Color(GammaCorrection, GammaCorrection, GammaCorrection);
        //Screen.brightness = GammaCorrection;
        
    }
  

}
