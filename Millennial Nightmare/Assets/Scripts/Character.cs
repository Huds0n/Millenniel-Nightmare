using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

    public float moveSpeed = 2f;
    public float jumpSpeed = 3f;
    public int force = 20;
    private Text winText;
    private Text loseText;
    private bool stopping;
    private bool canJump;
    private bool isGrounded;
    private Rigidbody rigidCharacter;
    public LayerMask jumpMask;

    void Start () {
        winText = GameObject.Find("Win").GetComponent<Text>();
        loseText = GameObject.Find("Lose").GetComponent<Text>();
        rigidCharacter = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Forward movement
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        //Left and right movement
        transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * moveSpeed);
        //Stopping by changing movement speed
        if (Input.GetKey("s")){
            stopping = true;
            moveSpeed = 0f;
        }
        else{
            stopping = false;
        }
        if (!stopping){
            moveSpeed = 2f;
        }
        //Checking to see if touching the ground
        RaycastHit hit;
        isGrounded = Physics.SphereCast(transform.position, 0.5f, -transform.up, out hit, 0.5f);
        if (canJump && isGrounded){
            canJump = false;
            rigidCharacter.AddForce(0, force, 0, ForceMode.Impulse);
        }
        // Jump
        if (Input.GetKeyDown(KeyCode.W))
        {
            canJump = true;
        }
    } 
    void OnCollisionEnter(Collision col) {
        //Checking Collision with invisible Win Wall
        if (col.gameObject.name == "Win") {
            winText.text = "wow...you win";
            Time.timeScale = 0;
        }
        //Checking Collision with Enemy or Car to lose
        if (col.gameObject.tag == "Enemy")
        {
            loseText.text = "Git Gud";
            Time.timeScale = 0;
        }
        if (col.gameObject.tag == "EnemyCar")
        {
            loseText.text = "Git Gud";
            Time.timeScale = 0;
        }
    }
}
