using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementObject : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 TorqueObject = new Vector3 (0,0,0);
    public float rotatingSpeed = 5f;
    public float scalingSpeed = 0.01f;

    private float currentScale;
    private float minSizeScale;

    void Start(){
        rb = GetComponent<Rigidbody>();
        minSizeScale = 0.5f;
    }

    void Update(){
        if (Input.GetKey(KeyCode.Space)){
            // rb.AddTorque(TorqueObject, ForceMode.Impulse);
            transform.Rotate(0,rotatingSpeed,0);
        }

        currentScale = transform.localScale.x;

        if (Input.GetKey(KeyCode.Z)){
            transform.localScale += Vector3.one*scalingSpeed;
        }
        else if (Input.GetKey(KeyCode.X) && currentScale > minSizeScale){
            transform.localScale -= Vector3.one*scalingSpeed;
        }
        // print(rb.angularVelocity);
        print (Vector3.one*scalingSpeed);
    }
}
