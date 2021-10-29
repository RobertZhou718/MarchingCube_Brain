using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opacity : MonoBehaviour
{
    public Material material;
    public Slider alphaslider;
    float alpha = 1f;
    // Start is called before the first frame update
    void Start()
    {
        alphaslider.value = alpha;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (alphaslider.value != 1f)
        {
            material = new Material(Shader.Find("Transparent/Diffuse"));
            material.color = new Color(0.4f, 0.2f, 0.2f, alphaslider.value);
            GetComponent<Renderer>().material = material;
        }
        else {
            material = new Material(Shader.Find("Diffuse"));
            material.color = new Color(0.4f, 0.2f, 0.2f);
            GetComponent<Renderer>().material = material;
        }
      
    }
}
