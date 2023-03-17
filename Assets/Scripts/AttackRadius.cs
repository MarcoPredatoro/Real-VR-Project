using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AttackRadius : MonoBehaviour
{

    // private AudioListener listener;
    private GameObject Marco;
   // private GameObject polo2;
    // public GameObject background;

    public List<Material> materials;

    public GameObject cube;

    public float[] threatRadius;


    // Start is called before the first frame update
    void Start()
    {
        cube.GetComponent<Renderer>().material = materials[0];

        Marco =  GameObject.Find("Marco");
        cube.GetComponent<Renderer>().material = materials[1];




        // cube.GetComponent<Renderer>().material = materials[1];

        // polo2 =  GameObject.Find("Polo2");
        // cube.GetComponent<Renderer>().material = materials[2];

        //listener = this.GetComponent<AudioListener>();
    }

    // Update is called once per frame
    void Update()
    {
        float dis1 = XZDistance(transform.position, Marco.transform.position);
        // float dis2 = XZDistance(transform.position, polo2.transform.position);

        if (dis1 > threatRadius[0] ) {
            // To far away so should play the background sound
            // SetMute(polo1, new bool[]{true, true, true});
            // SetMute(polo2, new bool[]{true, true, true});
             //background.GetComponent<AudioSource>().mute = false;
            // Debug.Log("Background Sound");
            //cube.GetComponent<Renderer>().material = materials[0];
            cube.GetComponent<Renderer>().material = materials[0];

        } else {
           // background.GetComponent<AudioSource>().mute = true;
            // if (dis1 < dis2 ) {
            //     SetMute(polo2, new bool[]{true, true, true});
            //     makeThreatRadiusSound(polo1, dis1);
            // } else if (dis1 >= dis2) {
            //     SetMute(polo1, new bool[]{true, true, true});
            cube.GetComponent<Renderer>().material = materials[0];
               makeThreatRadiusSound(Marco, dis1);

               
            // }
        }

        //makeThreatRadiusSound(Marco, dis1);
    }

    void makeThreatRadiusSound(GameObject polo, float distance) {
        
        if (distance < threatRadius[2]) {
            // Polo in the closest ring
            Debug.Log("polo in the 3 ring");
            //cube.SetActive(false);

             cube.GetComponent<Renderer>().material = materials[0];

            

            // SetMute(polo, new bool[]{false, false, false});
        } else if (distance < threatRadius[1]){
            // Polo in the second closest ring
            Debug.Log("polo in the 2 ring");
            //cube.SetActive(true);
            cube.GetComponent<Renderer>().material = materials[1];
            
            // SetMute(polo, new bool[]{false, false, true});

        } else {
            // Polo in the furthest ring
            Debug.Log("polo in the 1 ring");
            // cube.SetActive(false);
            cube.GetComponent<Renderer>().material = materials[2];
            //cube.SetActive(false);
            // SetMute(polo, new bool[]{false, true, true});

        }
    }

    // void SetMute(GameObject polo, bool[] isMuted) {
    //     // Sets whether the child of the polo's audio sources are muted or not based on the bool array
    //     for (int i = 0 ; i < isMuted.Length; i++){
    //         polo.transform.GetChild(i).GetComponent<AudioSource>().mute = isMuted[i];
    //     }
    // }

    float XZDistance(Vector3 v1, Vector3 v2) {
        return Mathf.Sqrt((v1.x - v2.x) * (v1.x - v2.x) + (v1.z - v2.z) * (v1.z - v2.z));
    }
}