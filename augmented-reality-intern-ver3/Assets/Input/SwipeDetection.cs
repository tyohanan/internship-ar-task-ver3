using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    private float rotateSpeed = 10f;
    private SwipeAndroid swipeControls;
    private Coroutine swipeCoroutine;
    private void Awake(){
            swipeControls = new SwipeAndroid();
    }

    private void OnEnable(){
        swipeControls.Enable();
    }

    private void OnDisable(){
        swipeControls.Disable();
    }

    void Start(){
        swipeControls.Android.PrimaryContact.started += _ => SwipeStart();
        swipeControls.Android.PrimaryContact.canceled += _ => SwipeEnd();
    }

    private void SwipeStart(){
        swipeCoroutine = StartCoroutine(MoveDetection());
    }

    private void SwipeEnd(){
        StopCoroutine(swipeCoroutine);
    }

    private void Update(){

    }

    IEnumerator MoveDetection(){
        float XpreviousDistance = 0f, YpreviousDistance = 0f, Xdistance = 0f, Ydistance = 0f;
        while (true){
            Xdistance = swipeControls.Android.PrimaryPosition.ReadValue<Vector2>().x;
            Ydistance = swipeControls.Android.PrimaryPosition.ReadValue<Vector2>().y; 
        
        //swipe right
            if (Xdistance - XpreviousDistance > 0){
                print(Xdistance +"  "+ XpreviousDistance);
                // print(swipeControls.Android.PrimaryPosition.ReadValue<Vector2>());
                transform.Rotate (0, rotateSpeed, 0);
            }
            else if (Xdistance - XpreviousDistance < 0){
                transform.Rotate (0, -rotateSpeed, 0);
            }

            else if (Ydistance - YpreviousDistance > 0){
                transform.Rotate (0, rotateSpeed, 0);
            }
            else if (Ydistance - YpreviousDistance < 0){
                transform.Rotate (0, -rotateSpeed, 0);
            }


            XpreviousDistance = Xdistance;
            YpreviousDistance = Ydistance;
            yield return null;
        }
    }

}
    // #region Events
    // public delegate void StartTouch(Vector2 position, float time);
    // public event StartTouch OnStartEvent;
    // public delegate void EndTouch (Vector2 position, float time);
    // public event EndTouch OnEndTouch;
    // #endregion

    // private SwipeAndroid swipeControls;
    // void Awake(){
    //     swipeControls = new SwipeAndroid();
    // }

    // private void OnEnable(){
    //     swipeControls.Enable();
    // }

    // private void OnDisable(){
    //     swipeControls.Disable();
    // }

    // private void Start(){
    //     swipeControls.Android.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
    //     swipeControls.Android.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
    // }

    // private void StartTouchPrimary(InputAction.CallbackContext context){

    // }

    // private void EndTouchPrimary(InputAction.CallbackContext context){

    // }

