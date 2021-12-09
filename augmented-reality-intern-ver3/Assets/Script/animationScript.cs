using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationScript : MonoBehaviour
{
    private Animator anim;
    private Animation animLogo;

    void Start(){
        anim = GetComponent<Animator>();
        animLogo = GetComponent<Animation>();
    }

    public void stopAnim(){
        anim.SetBool("onStart", false);
        }
}
