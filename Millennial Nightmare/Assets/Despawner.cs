﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "EnemyCar" || other.gameObject.tag == "Enemy")
        {
            Destroy(other.collider.gameObject);
            Destroy(other.gameObject);
        }
    }

}