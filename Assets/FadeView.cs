using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeView : MonoBehaviour
{
    
    public float fadeSpeed;
    public float interval;
    //private float lastTimeCalled;
    private bool fadingOut = false;
    public Renderer objectRenderer;
    private Color objectColour;

// IEnumerator<WaitForSeconds> makePoloAppear() {
    
//         while(true) {

//             //GetComponent<MeshRenderer>().enabled = false;
//             Color objectColour = GetComponent<Renderer>().material.color;
//             float fadeAmount = objectColour.a - (fadeSpeed * Time.deltaTime);
//             objectColour = new Color(objectColour.r, objectColour.g, objectColour.b, fadeAmount);
//             GetComponent<Renderer>().material.color = objectColour;
//             yield return new WaitForSeconds(4);


//             //GetComponent<MeshRenderer>().enabled = true;
//             Color objectColourIn = GetComponent<Renderer>().material.color;
//             float fadeAmountIn = objectColourIn.a + (fadeSpeed * Time.deltaTime);
//             objectColourIn = new Color(objectColourIn.r, objectColourIn.g, objectColourIn.b, fadeAmountIn);
//             GetComponent<Renderer>().material.color = objectColourIn;
//             yield return new WaitForSeconds(4);

//         }
//     }
    // Start is called before the first frame update
    void Start()
    {
        objectColour = this.GetComponent<Renderer>().material.color;
        InvokeRepeating("Fade", 0, 4);
        
    }

    void Fade()
    {
        if (fadingOut)
    {
        StartCoroutine(FadeInObject());
    }
    else
    {
        StartCoroutine(FadeOutObject());
    }
    fadingOut = !fadingOut;
    }

    // Update is called once per frame
    void Update()
    {
        // if (Time.time - lastTimeCalled > interval)
        // {
        //     StartCoroutine(FadeOutObject());
        //     lastTimeCalled = Time.time;
        // }
        // else
        // {
        //     StartCoroutine(FadeInObject());
        // }
        
    }

    IEnumerator FadeOutObject()
{
    while (objectColour.a > 0)
    {
        objectColour.a -= fadeSpeed * Time.deltaTime;
        this.GetComponent<Renderer>().material.color = objectColour;
        yield return null;
    }
}

IEnumerator FadeInObject()
{
    while (objectColour.a < 1)
    {
        objectColour.a += fadeSpeed * Time.deltaTime;
        this.GetComponent<Renderer>().material.color = objectColour;
        yield return null;
    }
}

    // public IEnumerator FadeOutObject()
    // {
    //     while (this.GetComponent<Renderer>().material.color.a > 0)
    //     {
    //         Color objectColour = this.GetComponent<Renderer>().material.color;
    //         float fadeAmount = objectColour.a - (fadeSpeed * Time.deltaTime);
    //         objectColour = new Color(objectColour.r, objectColour.g, objectColour.b, fadeAmount);
    //         this.GetComponent<Renderer>().material.color = objectColour;
    //         yield return null;
    //     }
    // }

    // public IEnumerator FadeInObject()
    // {
    //     while (this.GetComponent<Renderer>().material.color.a < 1)
    //     {
    //         Color objectColour = this.GetComponent<Renderer>().material.color;
    //         float fadeAmount = objectColour.a + (fadeSpeed * Time.deltaTime);
    //         objectColour = new Color(objectColour.r, objectColour.g, objectColour.b, fadeAmount);
    //         this.GetComponent<Renderer>().material.color = objectColour;
    //         yield return null;
    //     }
    // }

    


}