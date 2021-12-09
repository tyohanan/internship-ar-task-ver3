using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ObjectEvent : MonoBehaviour
{
    public GameObject arutalaLogo;
    public GameObject particleObject;
    public GameObject particlePosition;
    public AudioSource bgmGame;

    public Vector3 TorqueObject = new Vector3 (0,0,0);
    private Rigidbody rbArutalaLogo;
    private Animator animLogo;
    private bool imageDetected;

    void Start(){
        rbArutalaLogo = arutalaLogo.GetComponent<Rigidbody>();
        animLogo = arutalaLogo.GetComponent<Animator>();

    }

    void Update(){
        // print(transform.position);
        print (arutalaLogo.transform.rotation);
        if (imageDetected || Input.GetKeyDown(KeyCode.C)){
            Instantiate(particleObject, transform.position, particlePosition.transform.rotation);
            // particleObject.transform.position = transform.position;
            // particleObject.transform.rotation = particlePosition.transform.rotation;
            imageDetected = false;
        }

    }

    public void targetDetected(){
        imageDetected = true;
        bgmGame.Play();
        animLogo.SetBool("onStart", true);
        arutalaLogo.transform.Rotate(0,360,0);
    }

    public void targetNotDetected(){
        imageDetected = false;
        bgmGame.Stop();
        animLogo.SetBool("onStart", false);
    }
}
