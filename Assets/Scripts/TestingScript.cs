using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestingScript : MonoBehaviour
{
    public string textName;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find(textName).GetComponent<Text>().text = this.name;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
