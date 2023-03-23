using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AttackRadius : MonoBehaviour
{

     private AudioListener listener;
    //private GameObject Marco;
    private GameObject polo2;
    private GameObject polo1;
    public GameObject background;

    public List<Material> materials;

    public Text test;



    public float[] threatRadius;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayInstantiation());
        background = GameObject.Find("scene2");
        // polo1 =  GameObject.Find("Polo/Audio");
        // polo2 =  GameObject.Find("Polo2/Audio");
        test = GameObject.Find("Text2").GetComponent<Text>();
        // background = GameObject.Find("scene2");
        

        // GameObject cube = GameObject.Find("Cube");
        // GameObject cube2 = GameObject.Find("Cube2");
        
        // //cube.GetComponent<Renderer>().material = materials[0];
        // if (polo1 == null) {
        //     cube.GetComponent<Renderer>().material = materials[0];
        // } else {
        //     cube.GetComponent<Renderer>().material = materials[1];
        // }

        // if (polo2 == null) {
        //     cube2.GetComponent<Renderer>().material = materials[0];
        // } else {
        //     cube2.GetComponent<Renderer>().material = materials[1];
        // }
        // //cube.GetComponent<Renderer>().material = materials[1];

        // // polo2 =  GameObject.Find("Polo2");
        // // cube.GetComponent<Renderer>().material = materials[2];

        listener = this.GetComponent<AudioListener>();
    }

    // Update is called once per frame
    void Update()
    {
        if (polo1 != null && polo2 != null){
            float dis1 = XZDistance(transform.position, polo1.transform.position);
            float dis2 = XZDistance(transform.position, polo2.transform.position);


            if (dis1 > threatRadius[0] && dis2 > threatRadius[0] ) {
                // To far away so should play the background sound
                SetMute(polo1, new bool[]{true, true, true});
                SetMute(polo2, new bool[]{true, true, true});
                background.GetComponent<AudioSource>().mute = false;
                Debug.Log("Background Sound");
                test.text = "Background Sound";
                
                
            // cube.GetComponent<Renderer>().material = materials[0];

            } else {
                
                background.GetComponent<AudioSource>().mute = true;
                if (dis1 <= dis2 ) {
                    test.text = polo1.name + "   :   " + dis1;
                    SetMute(polo2, new bool[]{true, true, true});
                    makeThreatRadiusSound(polo1, dis1);
                } else if (dis1 >= dis2) {
                    test.text = polo2.name + "   :   " + dis2;
                    SetMute(polo1, new bool[]{true, true, true});
                    makeThreatRadiusSound(polo2, dis2);
                //cube.GetComponent<Renderer>().material = materials[0];

                
                //makeThreatRadiusSound(polo, dis1);
                }
            }
        }


        //makeThreatRadiusSound(Marco, dis1);
    }

    void makeThreatRadiusSound(GameObject polo, float distance) {
        
        if (distance < threatRadius[2]) {
            // Polo in the closest ring
            Debug.Log("polo in the 3 ring");
            SetMute(polo, new bool[]{false, false, false});
            test.text = "Closest Ring";
        } else if (distance < threatRadius[1]){
            // Polo in the second closest ring
            Debug.Log("polo in the 2 ring");
            SetMute(polo, new bool[]{false, false, true});
            test.text = "Second Closest Ring";

        } else {
            // Polo in the furthest ring
            Debug.Log("polo in the 1 ring");
            SetMute(polo, new bool[]{false, true, true});
            test.text = "Furthest Ring";

        }
    }

    IEnumerator<WaitForSeconds> DelayInstantiation() {
        while(polo1 == null || polo2 == null) {
            polo1 =  GameObject.Find("Polo(Clone)/Audio");
            polo2 =  GameObject.Find("Polo2(Clone)/Audio");

            yield return new WaitForSeconds(1);
        }

        // SetMute(polo1, new bool[]{true, true, true});
        // SetMute(polo2, new bool[]{true, true, true});
        test.text = "polo1: " + polo1.name + " polo2: " + polo2.name;
    }

    void SetMute(GameObject polo, bool[] isMuted) {
        // Sets whether the child of the polo's audio sources are muted or not based on the bool array
        for (int i = 0 ; i < isMuted.Length; i++){
            polo.transform.GetChild(i).GetComponent<AudioSource>().mute = isMuted[i];
        }
    }

    float XZDistance(Vector3 v1, Vector3 v2) {
        return Mathf.Sqrt((v1.x - v2.x) * (v1.x - v2.x) + (v1.z - v2.z) * (v1.z - v2.z));
    }
}
