using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour {
    
    public float duration = 1.0F;
    public Light lt;
    public float lightRange= 30;
    public float lightIntensity = 1;
    public float lightRed=0.0f;
    public float lightGreen=255.0f;
    public float lightBlue=0f;
    Color color;

    void Start()
    {
        lt = GetComponent<Light>();
        color = new Color(lightRed, lightGreen, lightBlue,255);
    }
    void Update()
    {
        Debug.Log(Time.time);
        float phi = Time.time / duration * 2 * Mathf.PI;
        float amplitude = Mathf.Cos(phi) * 0.5F + 0.5F;
        lt.intensity = amplitude;
        lt.range = lightRange;
       // lt.intensity = lightIntensity;
        lt.color = color;
    }
}
