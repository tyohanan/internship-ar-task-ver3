using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Vuforia;

public class FocusCamera : MonoBehaviour
{

    private void OnSingleTapped(){
        TriggerAutoFocus();
    }

    public void TriggerAutoFocus(){
        StartCoroutine(TriggerAutoFocusAndEnableContinousFocusIfSet());
    }

    private IEnumerator TriggerAutoFocusAndEnableContinousFocusIfSet(){
        yield return new WaitForSeconds(0.5f);
        //CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode);
    }
}
