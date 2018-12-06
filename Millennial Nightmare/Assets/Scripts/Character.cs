using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public float moveSpeed = 2f;
	void Start () {
		
	}

	void Update () {
        //Forwards and back mvoement
        transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * moveSpeed);
        //Left and right movement
        transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * moveSpeed);
    }
}
