using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Unity.XR.CoreUtils;

public class RightHandPresencePhysics : MonoBehaviour
{
    public Transform rTarget;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        XROrigin xrOrigin = FindObjectOfType<XROrigin>();
        rTarget = xrOrigin.transform.Find("Camera Offset/RightHand Controller");
        
    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = (rTarget.position - transform.position) / Time.fixedDeltaTime;
    }
}
