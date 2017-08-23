using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {
    public float max_Y;

    private Vector3 current_pos;
    private float moveSpeed;
	// Use this for initialization
	void Start () {
        current_pos = transform.position;
        moveSpeed = 0.2f;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        current_pos.y += moveSpeed;
        transform.position = current_pos;

        isBulletGone();
	}

    void isBulletGone()
    {
        if (transform.position.y > max_Y)
        {
            Destroy(gameObject);
        }
    }
}
