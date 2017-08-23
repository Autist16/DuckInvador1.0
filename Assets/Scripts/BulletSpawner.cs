using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour {
    //declare variables
    //public
    public GameObject spawnBullet;
    PlayerControls playerData;
    //private
    private Vector3 start_pos;
    private int no_bullets;
	// Use this for initialization
	void Start () {
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>();
        start_pos = playerData.transform.position;
        no_bullets = 0;
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        no_bullets = GameObject.FindGameObjectsWithTag("Bullet").Length;
        if (Input.GetKeyDown("space"))
        {
            if (no_bullets < 3)
            {
                SpawnBullet();
            }
        }
		
	}
    void SpawnBullet()
    {
        start_pos = playerData.transform.position;
        start_pos.y += 1.3f; // adjust to top of gun
        Instantiate(spawnBullet, start_pos, Quaternion.identity);
        no_bullets += 1;
    }
}
