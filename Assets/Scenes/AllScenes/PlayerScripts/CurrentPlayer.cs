﻿using UnityEngine;
using System.Collections;

public class CurrentPlayer : MonoBehaviour {

    public static Player currentPlayer { get; set; }
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
	}
}