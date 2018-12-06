using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {
    public float rotateSpeed = 1f;
    public Transform forward;
    public Transform phone;

	void Start () {
        transform.LookAt(phone);
    }
	void Update () {
        if (Input.GetKeyDown("space")){
            LookUp();  
        }
	}

    void LookUp(){
        transform.LookAt(forward);
        print("looking up");
        StartCoroutine(Wait());
        
        print("looking down");
    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(5);
        transform.LookAt(phone);
    }
}
