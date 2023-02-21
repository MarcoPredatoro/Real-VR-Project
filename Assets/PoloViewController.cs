using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoloViewController : MonoBehaviour
{



IEnumerator<WaitForSeconds> makePoloAppear() {
    
        while(true) {
            GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(7);
            GetComponent<MeshRenderer>().enabled = true;
            yield return new WaitForSeconds(2);

        }

    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(makePoloAppear());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}