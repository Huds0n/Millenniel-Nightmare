using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {
    public float rotateSpeed = 1f;
    public Transform target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space")){
            transform.LookAt(target);
            print("looking up");
        }
	}
}
