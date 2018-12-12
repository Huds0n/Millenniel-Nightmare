using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public Transform[] spawners;
    public GameObject[] enemy;
    public GameObject[] whatToSpawn;
    private bool whenToSpawn = true;

    void Start () {
        SpawnEnemyPerson();
	}

	void Update () {
       // if(whenToSpawn == true){
           // SpawnEnemyPerson();
        //}
	}
    void SpawnEnemyPerson() {
        whatToSpawn[1] = Instantiate(enemy[1],spawners[0].transform.position, Quaternion.Euler(0, 90, 0))as GameObject;
        whatToSpawn[1] = Instantiate(enemy[1], spawners[1].transform.position, Quaternion.Euler(0, -90, 0)) as GameObject;
        whatToSpawn[1] = Instantiate(enemy[1], spawners[2].transform.position, Quaternion.Euler(0, 180, 0)) as GameObject;
        whatToSpawn[0] = Instantiate(enemy[0], spawners[3].transform.position, Quaternion.Euler(0, 90, 0)) as GameObject;
        whatToSpawn[0] = Instantiate(enemy[0], spawners[4].transform.position, Quaternion.Euler(0, -90, 0)) as GameObject;
        whatToSpawn[0] = Instantiate(enemy[0], spawners[5].transform.position, Quaternion.Euler(0, 180, 0)) as GameObject;
        whatToSpawn[0] = Instantiate(enemy[0], spawners[6].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        
    }
}
