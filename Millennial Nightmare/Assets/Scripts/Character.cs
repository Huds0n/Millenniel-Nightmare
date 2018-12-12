using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

    public float moveSpeed = 2f;
    private Text winText;
    private Text loseText;
    void Start () {
        winText = GameObject.Find("Win").GetComponent<Text>();
        loseText = GameObject.Find("Lose").GetComponent<Text>();
    }

	void Update () {
        //Forwards and back mvoement
        transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * moveSpeed);
        //Left and right movement
        transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * moveSpeed);
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
