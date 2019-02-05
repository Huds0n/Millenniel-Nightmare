using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public ArrayList spawners;
    public GameObject[] enemy;
    public GameObject[] whatToSpawn;
    private bool whenToSpawn = true;

    void Start () {
        spawners = new ArrayList();
        CreateSpawners();
        InvokeRepeating("SpawnEnemyPerson", 0, 5);
	}

	void Update () {
     // TODO: Set spawn rate
	}
    //Spawning which enemy ay which location and rotation
    void SpawnEnemyPerson() {
        whatToSpawn[1] = Instantiate(enemy[1], ((Spawner)spawners[0]).position, ((Spawner)spawners[0]).orientation) as GameObject;
        whatToSpawn[1] = Instantiate(enemy[1], ((Spawner)spawners[1]).position, ((Spawner)spawners[1]).orientation) as GameObject;
        whatToSpawn[1] = Instantiate(enemy[1], ((Spawner)spawners[2]).position, ((Spawner)spawners[2]).orientation) as GameObject;
        whatToSpawn[0] = Instantiate(enemy[0], ((Spawner)spawners[3]).position, ((Spawner)spawners[3]).orientation) as GameObject;
        whatToSpawn[0] = Instantiate(enemy[0], ((Spawner)spawners[4]).position, ((Spawner)spawners[4]).orientation) as GameObject;
        whatToSpawn[0] = Instantiate(enemy[0], ((Spawner)spawners[5]).position, ((Spawner)spawners[5]).orientation) as GameObject;
        whatToSpawn[0] = Instantiate(enemy[0], ((Spawner)spawners[6]).position, ((Spawner)spawners[6]).orientation) as GameObject;
        
    }

    private void CreateSpawners() {
        Spawner spawner1 = new Spawner(-55f, 1.35f, 44.5f, Quaternion.Euler(0, 90, 0), "person"); //Works
        Spawner spawner2 = new Spawner(55f, 1.35f, 44f, Quaternion.Euler(0, -90, 0), "person");
        Spawner spawner3 = new Spawner(-1.43f, 1.35f, 168.5f, Quaternion.Euler(0, 180, 0), "person");
        Spawner spawner4 = new Spawner(-52.75f, -0.33f, 55.25f, Quaternion.Euler(0, 90, 0), "car");
        Spawner spawner5 = new Spawner(55.5f, -0.33f, 50.5f, Quaternion.Euler(0, -90, 0), "car");
        Spawner spawner6 = new Spawner(3f, -0.33f, 164f, Quaternion.Euler(0, 180, 0), "car");
        Spawner spawner7 = new Spawner(-1.5f, -0.33f, -25f, Quaternion.Euler(0, 0, 0), "car");

        spawners.Add(spawner1);
        spawners.Add(spawner2);
        spawners.Add(spawner3);
        spawners.Add(spawner4);
        spawners.Add(spawner5);
        spawners.Add(spawner6);
        spawners.Add(spawner7);
    }
}
