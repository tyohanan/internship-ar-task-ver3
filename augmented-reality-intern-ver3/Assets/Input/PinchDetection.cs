using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchDetection : MonoBehaviour
{
    public float rotatingSpeed = 5f;
    public float scalingSpeed = 0.3f;

    private float currentScale;
    private float minSizeScale = 1f;

    private PinchAndroid controls;
    private Coroutine zoomCoroutine;
    private void Awake(){
        controls = new PinchAndroid();
    }

    private void OnEnable(){
        controls.Enable();
    }
    private void OnDisable(){
        controls.Disable();
    }

    void Start(){
        controls.Android.SecondTouchContact.started += _ => ZoomStart();
        controls.Android.SecondTouchContact.canceled += _ => ZoomEnd();
    }

    private void ZoomStart(){
        zoomCoroutine = StartCoroutine(ZoomDetection());
    }

    private void ZoomEnd(){
        StopCoroutine(zoomCoroutine);
    }

    private void Update(){
        currentScale = transform.localScale.x;
        print(currentScale);
    }

    IEnumerator ZoomDetection(){
        float previousDistance = 0f, distance = 0f;
        while(true){
            distance = Vector2.Distance(controls.Android.FirstFingerPosition.ReadValue<Vector2>(), controls.Android.SecondFingerPosition.ReadValue<Vector2>());

            //zoom out
            if (distance < previousDistance ){
                transform.localScale += Vector3.one*scalingSpeed;
            }

            //zoom in
            else if (distance > previousDistance  && currentScale > minSizeScale){
                transform.localScale -= Vector3.one*scalingSpeed;
            }
            previousDistance = distance;
            yield return null;
        }
    }

    
}
