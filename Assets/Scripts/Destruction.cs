using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    public int timer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyThis());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator<WaitForSeconds> destroyThis() {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
