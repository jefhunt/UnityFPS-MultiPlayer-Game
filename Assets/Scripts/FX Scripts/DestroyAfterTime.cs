﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {

    // Use this for initialization
    public float timer = 1f;

	void Start () {
        Destroy(gameObject, timer);        
	}
	
	
}
