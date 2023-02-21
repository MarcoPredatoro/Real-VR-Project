using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class colliderScriptPolo : MonoBehaviour
{

    private PhotonView photonView;
    public GameObject cubePrefab;



    private void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.name == "Marco")
        {
            cubePrefab.SetActive(false);   
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        cubePrefab.SetActive(true);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
