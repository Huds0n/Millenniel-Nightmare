using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using UnityEngine.SceneManagement;

public class MainCamera : MonoBehaviour {
    public float rotateSpeed = 0.1f;
    public Transform forwardTarget;
    public Transform phone;
    private float lookUpCD = 8.0f;
    private float nextLookUp = 0;
    private bool isLookingUp = false;
    //CooldownBar
    private Text lookupText;
    public Image LoadingBar;
    //StoppingTimeBar
    private Text StoppingText;
    public Image StoppingBar;
    //player
    Character player;


	void Start () {
        lookupText = GameObject.Find("LookUpCD").GetComponent<Text>();
        LoadingBar = GameObject.Find("CooldownBar").GetComponent<Image>();

        StoppingText = GameObject.Find("StoppingCD").GetComponent<Text>();
        StoppingBar = GameObject.Find("StoppingCooldownBar").GetComponent<Image>();

        player = GameObject.Find("Character").GetComponent<Character>();
    }

	void Update () {

        //Prints the current cooldown of lookup on screen
        if (Time.time > nextLookUp)
        {
            lookupText.text = "READY";
        }
        else {
            lookupText.text = (nextLookUp - Time.time).ToString("00.00");
            LoadingBar.fillAmount = 1 - ((nextLookUp - Time.time) / lookUpCD);
        }
        //Prints the time left on the character stopping this level
        if (player.stoppingTime <= 0)
        {
            StoppingText.text = "No More Stopping!!";
        }
        else {
            StoppingText.text = player.stoppingTime.ToString("00.00");
            StoppingBar.fillAmount = 1 - ((player.levelStoppingTime - player.stoppingTime) / player.levelStoppingTime);
        }
        

        //If W is pressed, start the lookup animation
        if (Input.GetKeyDown("w")){
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
            Time.timeScale = 1;
        }
    }

    void LookUp(){
        //Sets the target direction and pans the camera to it
        Vector3 targetDir = forwardTarget.position - transform.position;
        Vector3 newDir = Vector3.Lerp(transform.forward, targetDir, rotateSpeed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(newDir);
        //Waits 3 seconds and then pans the camera back to original position
        StartCoroutine(Wait());
    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(3);
        Vector3 targetDir = phone.position - transform.position;
        Vector3 newDir = Vector3.Lerp(transform.forward, targetDir, rotateSpeed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(newDir);
        //Stop the looking up animation
        isLookingUp = false;
    }
}
