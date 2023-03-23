using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiation : MonoBehaviour
{
    public GameObject prefab;
    public int spawnNo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateLots() {
        for(int i = 0; i < spawnNo; i++){
            var position = new Vector3(Random.Range(-4.0f, 4.0f), 1, Random.Range(-4.0f, 4.0f));
            var rotation = Quaternion.Euler(0,Random.Range(0,360), 0);
            Instantiate(prefab, position, rotation);

        }
    }
}
