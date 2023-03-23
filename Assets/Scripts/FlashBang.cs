using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class FlashBang : MonoBehaviour
{
    public Image whiteScreen;
    //public AudioClip ringingSound;
    public float duration = 3f;

    private AudioSource audioSource;

    private void Start()
    {
        //audioSource = gameObject.AddComponent<AudioSource>();
        //audioSource.clip = ringingSound;
        //StartCoroutine(FlashWhiteScreen());
    }

    public void Flash()
    {
        StartCoroutine(FlashWhiteScreen());
    }



    IEnumerator<WaitForSeconds> FlashWhiteScreen()
    {
        whiteScreen.enabled = true;
        //audioSource.Play();
        yield return new WaitForSeconds(duration);
        whiteScreen.enabled = false;
    }
}