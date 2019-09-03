using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_bullet : MonoBehaviour
{
   
	Vector3 movement;
	bool ismove=false;
    public float speed_bullet;
	void Start ()
	{
	}
	void Update()
    {
		if(ismove)
		{
		GetComponent<Rigidbody>().velocity = movement * speed_bullet;
		}


	}

	public void GetPlayerPosi(Vector3 playerPosi)
	{
	
		float moveHorizontal = playerPosi.x-transform.position.x;
		float moveVertical = playerPosi.z-transform.position.z;


		movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		movement.Normalize();

		ismove = true;
	}





}
