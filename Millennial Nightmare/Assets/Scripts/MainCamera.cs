using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using UnityEngine.SceneManagement;

public class MainCamera : MonoBehaviour {
    public float rotateSpeed = 10f;
    public Transform forwardTarget;
    public Transform phone;
    private float lookUpCD = 8.0f;
    private float nextLookUp = 0;
    private bool isLookingUp = false;
    private Text lookupText;

	void Start () {
        lookupText = GameObject.Find("LookUpText").GetComponent<Text>();
    }

	void Update () {

        //Prints the current cooldown of lookup on screen
        if (Time.time > nextLookUp)
        {
            lookupText.text = "READY";
        }
        else {
            lookupText.text = (nextLookUp - Time.time).ToString("00");
        }
        

        //If Space is pressed, start the lookup animation
        if (Input.GetKeyDown("space")){
            //Checks if lookUp is on cooldown
            if (Time.time > nextLookUp)
            {
                isLookingUp = true;
                nextLookUp = Time.time + lookUpCD;
            }
            else {
                print("on Cooldown");
            }
            
        }
        if (isLookingUp) {
            LookUp();
        }
        //Restart button
        if (Input.GetKeyDown("r")){
            SceneManager.LoadScene("Prototype");
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
