using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner {

    public Vector3 position;
    public Quaternion orientation;
    private string enemyType;

	// Use this for initialization
	public Spawner(float x, float y, float z, Quaternion omega, string enemy) {
        position = new Vector3(x, y, z);
        orientation = omega;
        enemyType = enemy;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
