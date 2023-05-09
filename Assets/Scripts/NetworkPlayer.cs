using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Unity.XR.CoreUtils;
using Photon.Pun;
using UnityEngine.UI;

public class NetworkPlayer : MonoBehaviour
{
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    private Transform headRig;
    private Transform leftHandRig;
    private Transform rightHandRig;
    private PhotonView photonView;

    //public UnityEngine.UI.Image pointsImage;
    //public Text test;
    
    


    // Start is called before the first frame update
    void Start()
    {
        XROrigin xrOrigin = FindObjectOfType<XROrigin>();
        headRig = xrOrigin.transform.Find("Camera Offset/Main Camera");
        leftHandRig = xrOrigin.transform.Find("Camera Offset/LeftHand Controller");
        rightHandRig = xrOrigin.transform.Find("Camera Offset/RightHand Controller");
        photonView = GetComponent<PhotonView>();
        
    
    }


    // Update is called once per frame
    void Update()
    {
        
        MapPosition(head, headRig); 
        MapPosition(leftHand, leftHandRig); 
        MapPosition(rightHand, rightHandRig); 
        
    }
    

    void MapPosition(Transform target, Transform rigTransform)
    {
        
        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;
    }

    // private bool stab = false;
    // public void marcoCollision()
    // {
    //     if (!stab)
    //     {
    //         stab = true;
    //         pointsImage.color = new Color(255, 0, 0);
    //         GameObject.Find("sphere").SetActive(false);
    //         // pointsImage.material = pointsMaterial;
    //         GameObject.Find("Canvas/Image/Points").GetComponent<EventManager>().SendMarcoCollision();
    //         //GameObject.Find("Canvas/Image/Text1").GetComponent<EventManager>().SendMarcoCollision();
    //         StartCoroutine(turnBacktoWhite());
    //     }
    // }

    // IEnumerator<WaitForSeconds> turnBacktoWhite() {
    //     yield return new WaitForSeconds(5);
    //     // pointsImage.material = reset;
    //     pointsImage.color = new Color(255,255,255);
    //     stab = false;
    // }

   

    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.name == "Polo" || collision.gameObject.name == "Polo2")
    //     {
    //         marcoCollision();
    //         GameObject.Find("tree").SetActive(false);
    //         //test.text = "Marco Collision";
         
    //     }
    // }

}

