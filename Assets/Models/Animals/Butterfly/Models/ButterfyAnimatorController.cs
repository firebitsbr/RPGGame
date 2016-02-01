﻿using UnityEngine;
using System.Collections;

public class ButterfyAnimatorController : MonoBehaviour {

    Random r;
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        StartCoroutine(StartStopFlying());
	}

    private IEnumerator StartStopFlying()
    {
        if (Random.value > 0.5)
        {
            anim.SetBool("Flying", true);
        }
        else
        {
            anim.SetBool("Flying", false);
        }
        yield return new WaitForSeconds(5);
        new WaitForEndOfFrame();
        StartCoroutine(StartStopFlying());
    }
}
