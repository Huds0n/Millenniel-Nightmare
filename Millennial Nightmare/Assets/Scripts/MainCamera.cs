using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {
    public float rotateSpeed = 1f;
    public Transform forwardTarget;
    public Transform phone;

	void Start () {
        //transform.LookAt(phone);
    }
	void Update () {
        if (Input.GetKeyDown("space")){
            LookUp();  
        }
	}

    void LookUp(){
        //transform.LookAt(forward);
        Vector3 targetDir = forwardTarget.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, rotateSpeed, 0f);
        transform.rotation = Quaternion.LookRotation(newDir);
        print("looking up");
        StartCoroutine(Wait());
        
        print("looking down");
    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(3);
        Vector3 targetDir = phone.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, rotateSpeed, 0f);
        transform.rotation = Quaternion.LookRotation(newDir);
        //transform.LookAt(phone);
    }
}
