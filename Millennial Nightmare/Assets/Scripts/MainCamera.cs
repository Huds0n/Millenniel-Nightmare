using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {
    public float rotateSpeed = 10f;
    public Transform forwardTarget;
    public Transform phone;
    private bool isLookingUp = false;

	void Start () {
    }
	void Update () {
        //If Space is pressed, start the lookup animation
        if (Input.GetKeyDown("space")){
            //TODO: Add Cooldown and check that it's off cooldown
            isLookingUp = true; 
        }
        if (isLookingUp) {
            LookUp();
        }
	}

    void LookUp(){
        //Sets the target direction and pans the camera to it
        Vector3 targetDir = forwardTarget.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, rotateSpeed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(newDir);
        //Waits 3 seconds and then pans the camera back to original position
        StartCoroutine(Wait());
    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(3);
        Vector3 targetDir = phone.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, rotateSpeed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(newDir);
        //Stop the looking up animation
        isLookingUp = false;
    }
}
