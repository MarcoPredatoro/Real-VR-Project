using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Unity.XR.CoreUtils;

public class LeftHandPresencePhysics : MonoBehaviour
{
    public Transform lTarget;
    private Rigidbody lb;

    // Start is called before the first frame update
    void Start()
    {
        lb = GetComponent<Rigidbody>();
        XROrigin xrOrigin = FindObjectOfType<XROrigin>();
        lTarget = xrOrigin.transform.Find("Camera Offset/LeftHand Controller");
        
    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lb.velocity = (lTarget.position - transform.position) / Time.fixedDeltaTime;
    }
}
