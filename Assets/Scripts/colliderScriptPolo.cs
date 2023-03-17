using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class colliderScriptPolo : MonoBehaviour
{

    private PhotonView photonView;
    //public UnityEngine.UI.Image pointsImage;
    //public GameObject Sphere;

   
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        //Sphere = GameObject.Find("Sphere");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // private bool stab = false;
    // public void marcoCollision()
    // {
    //     if (!stab)
    //     {
    //         stab = true;
    //         pointsImage.color = new Color(255, 0, 0);
    //         Sphere.SetActive(false);
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

    //  private void OnCollisionEnter(Collision collision)
    //  {
    //      if (collision.gameObject.name == "Marco/LeftHand" || collision.gameObject.name == "Marco/RightHand")
    //     {
    //         marcoCollision();
    //         GameObject.Find("tree").SetActive(false);
              
    //     }
    // }

}
