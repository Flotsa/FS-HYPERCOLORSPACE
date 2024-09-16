using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class HueShifter : MonoBehaviour
{
    public PostProcessVolume ppv;
    public ColorGrading cg;
    public float shiftSpeed = 1;
    float nextHue;
    
    // Start is called before the first frame update
    void Start()
    {
        ppv = GetComponent<PostProcessVolume>();
        ppv.profile.TryGetSettings(out cg);
    }

    // Update is called once per frame
    void Update()
    {
        nextHue += shiftSpeed;
        if (nextHue > 180)
        { 
            nextHue = -180;
        }

        
        cg.hueShift.value = nextHue;

        

    }
}
