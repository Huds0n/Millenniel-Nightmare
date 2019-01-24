using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

    public float moveSpeed = 2f;
    public float jumpSpeed = 3f;
    public int force = 40;
    private Text winText;
    private Text loseText;
    private bool stopping;
    public bool canJump;
    public bool isGrounded;
    private Rigidbody rigidCharacter;
    //public LayerMask jumpMask;
    //Stopping Variables
    public float levelStoppingTime = 5.0f;
    public float stoppingTime = 5.0f;
    //Look Up Varibles
    public MainCamera mainCamera;
    private bool isLookingUp = false;
    private float nextLookUp = 0;

    void Start () {
        winText = GameObject.Find("Win").GetComponent<Text>();
        loseText = GameObject.Find("Lose").GetComponent<Text>();
        rigidCharacter = GetComponent<Rigidbody>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<MainCamera>();
    }

    void Update() {
        //Forward movement
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        //Left and right movement
        transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * moveSpeed);
        //Stopping by changing movement speed
        if (Input.GetKey("s")){
            if (stoppingTime <= 0) {
                stoppingTime = 0;
                print("No More Stopping Allowed");
                moveSpeed = 2f;
                return;
            }
            stopping = true;
            moveSpeed = 0f;
            //Subtract time left stopping this level
            stoppingTime -= Time.deltaTime;
        }
        else{
            stopping = false;
        }
        if (!stopping){
            moveSpeed = 2f;
        }
        //Look Up Animation
        if (Input.GetKeyDown("w"))
        {
            //Checks if lookUp is on cooldown
            if (Time.time > nextLookUp)
            {
                isLookingUp = true;
                nextLookUp = Time.time + Globals.LOOK_UP_CD;
            }
            else
            {
                print("on Cooldown");
            }

        }
        if (isLookingUp)
        {
            mainCamera.LookUp();
        }
    }

        void FixedUpdate() {
        //TODO: Try to make jump less clunky with raycasting, its back to backis jump due to infinite jump
        //Checking to see if touching the ground
        /*RaycastHit hit;
        isGrounded = Physics.BoxCast(transform.position, transform.localScale, -transform.up, out hit, transform.rotation);
        Debug.DrawRay(transform.position, -transform.up, Color.red);*/
        if (canJump && isGrounded){
            canJump = false;
            rigidCharacter.AddForce(0, force, 0, ForceMode.Impulse);
        }
        // Jump
        if (Input.GetKeyDown(KeyCode.Space)){
            canJump = true;
        }
    }
    //Basic jump from objects tagged ground
    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        //Checking Collision with invisible Win Wall
        if (col.gameObject.name == "Win") {
            winText.text = "wow...you win";
            Time.timeScale = 0;
        }
        //Checking Collision with Enemy or Car to lose
        if (col.gameObject.tag == "Enemy"){
            loseText.text = "Git Gud";
            Time.timeScale = 0;
        }
        if (col.gameObject.tag == "EnemyCar"){
            loseText.text = "Git Gud";
            Time.timeScale = 0;
        }
    }
    //Exiting jump from collision
    void OnCollisionExit(Collision collision) {
        if (isGrounded)
        {
            isGrounded = false;
        }
    }

    public float getNextLookUp() {
        return nextLookUp;
    }

    public bool getIsLookingUp() {
        return isLookingUp;
    }
    public void setIsLookingUp(bool newVal) {
        isLookingUp = newVal;
    }
}
