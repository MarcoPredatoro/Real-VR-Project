using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class HapticInteractable : MonoBehaviour
{
    public float hapticIntensity;
    public float hapticDuration;
    public InputDeviceCharacteristics controllerCharacteristics;    
    private InputDevice targetDevice;
    //public GameObject Sphere;
    //public UnityEngine.UI.Image pointsImage;
    public float collisionCooldown = 2f;
    private bool canSendCollision = true;

    public GameObject bloodSplatterPrefab;
    public float collisionForceThreshold = 1f;
    // Start is called before the first frame update
    void Start()
    {
    
        TryInitialize();
        
    }

    void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnCollisionEnter(Collision collision)
     {
         if ((collision.gameObject.name == "polo-with-bones" || collision.gameObject.name == "Polo2" || collision.gameObject.name == "Polo") && canSendCollision)
        {
        //     if (collision.relativeVelocity.magnitude >= collisionForceThreshold)
        // {
            GameObject bloodSplatter = Instantiate(bloodSplatterPrefab, collision.contacts[0].point, Quaternion.identity);
            bloodSplatter.transform.forward = collision.contacts[0].normal;
            Destroy(bloodSplatter, 1.5f); // Optional: Destroy blood splatter after 5 seconds
        // }
            targetDevice.SendHapticImpulse(0, hapticIntensity, hapticDuration);
            SendCollisionEvent();
            StartCoroutine(CollisionCooldown());
        }
    }


    private void SendCollisionEvent()
    {
        GameObject.Find("Network Manager").GetComponent<EventManager>().SendMarcoCollision();
    }

    private IEnumerator CollisionCooldown()
    {
        canSendCollision = false;
        yield return new WaitForSeconds(collisionCooldown);
        canSendCollision = true;
    }


}
