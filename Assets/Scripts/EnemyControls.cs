using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour {

    //declare variables
    //public
    PlayerControls playerData;
    //position controls
    public float max_X_pos;
    public float mix_X_pos;
    public float max_Y_pos;
    public float min_Y_pos;

    //private
    private float move_Direction;
    private Vector3 pos;
    private Vector3 dirScale;
	// Use this for initialization
	void Start () {
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>();
        move_Direction = 0.1f;
        //prevent flipping at spawning
        dirScale = transform.localScale;
        if(dirScale.x < 0)
        {
            dirScale.x *= (-1);
        }
        transform.localScale = dirScale;

        //get position
        pos = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        //flip movement direction
        if (pos.x <= mix_X_pos || pos.x >= max_X_pos)
        {
            move_Direction = move_Direction * (-1);
            dirScale.x *= (-1);
            transform.localScale = dirScale;
            if(pos.x < mix_X_pos)
            {
                pos.x = mix_X_pos;
            }
            if(pos.x>max_X_pos)
            {
                pos.x = max_X_pos;
            }
        }

        //move enemy
        pos.x += move_Direction;
        transform.position = pos;
	}
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            KillEnemy();
        }
    }
    
        
    void KillEnemy()
    {
        Destroy(gameObject);
        playerData.IncreaseScore();
    }
}
