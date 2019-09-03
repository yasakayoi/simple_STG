using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_center : MonoBehaviour
{
    // Start is called before the first frame update
   
	Vector3 movement;
    float speed_bullet;
    Vector3 goal;
    float Max_Speed =35f;
    float Min_Speed =5f;
	void Start ()
	{
        speed_bullet = Random.Range(Min_Speed,Max_Speed);
        goal.x= Random.Range(-25f,25f);
        goal.y=0;
        goal.z=Random.Range(-25f,25f);
        GetPlayerPosi(goal);
	}
	void Update()
    {
		GetComponent<Rigidbody>().velocity = movement * speed_bullet;
	}

	public void GetPlayerPosi(Vector3 playerPosi)
	{
	
		float moveHorizontal = playerPosi.x-transform.position.x;
		float moveVertical = playerPosi.z-transform.position.z;


		movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		movement.Normalize();
	}
}

