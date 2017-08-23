using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    //declare variables
    //public
    public GameObject spawnObject;
    public float max_Y;
    public float min_Y;
    public float min_X;
    public float max_X;
    //private
    private int maxEnemys;
    private int no_enemys;
    private float nextActionTime = 0.0f;
    private float spawn_time = 1.0f;
    private Vector3 spawn_pos;

	// Use this for initialization
	void Start () {
        no_enemys = 0;
        maxEnemys = 8;
    }
	

	// Update is called once per frame
	void Update () {
        no_enemys = GameObject.FindGameObjectsWithTag("Duck").Length;
        if (Time.time > nextActionTime)
        {
            nextActionTime += spawn_time;
            if (no_enemys < maxEnemys)
            {
                Spawn_Enemy();
            }
        }
    }


    void Spawn_Enemy()
    {
        //randomise spawn location
        spawn_pos = new Vector3(Random.Range(min_X, max_X), Random.Range(min_Y, max_Y));

        Instantiate(spawnObject, spawn_pos, Quaternion.identity);
        no_enemys += 1;
    }
}
