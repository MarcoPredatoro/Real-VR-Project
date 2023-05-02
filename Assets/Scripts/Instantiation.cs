using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiation : MonoBehaviour
{
    public GameObject prefab;
    public int spawnNo;
    public float destructionTimer = 6.0f;
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
            var position = new Vector3(Random.Range(-2.0f, 2.0f), 1.7f, Random.Range(-2.0f, 2.0f));
            var rotation = Quaternion.Euler(0,Random.Range(0,360), 0);
            GameObject instance = Instantiate(prefab, position, rotation);
            StartCoroutine(destroyThis(instance, destructionTimer));

        }
    }

    IEnumerator destroyThis(GameObject gameObject, float timer) {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
