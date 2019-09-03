using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin = -20, xMax = 20, zMin = -20, zMax = 20;
}

public class MoverController : MonoBehaviour
{
    enum speed {FastSpeed = 25, SlowSpeed = 8}

	float speed_now = (float)speed.FastSpeed;
	public float tilt = 4;

	public Done_Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;

	
	public GameObject judge;
	public float fireRate = (float)0.01;
	 

    // Start is called before the first frame update
    /*
	void Start()
    {
        
    }
	*/

    // Update is called once per frame
    void Update ()
	{
		
	}
	void SpeedUpdate()
	{
		if(Input.GetAxisRaw("Slow")>0)
		{
			speed_now = (float)speed.SlowSpeed;

			//显示判定点
			judge.GetComponent<Renderer>().enabled = true;
		}
		if(Input.GetAxisRaw("Slow")==0)
		{
			speed_now = (float)speed.FastSpeed;
			judge.GetComponent<Renderer>().enabled = false;
		}
	}

    int i=0;
	void FixedUpdate ()
	{

		i++;
		if (Input.GetAxisRaw("Fire1")>0) 
		{
			//nextFire = Time.time + fireRate;
			if(i>=12)
			{
				Instantiate(shot, shotSpawn.position, shotSpawn.rotation, shotSpawn.transform);
				//GetComponent<AudioSource>().Play ();//射击音效
				i=0;
			}
		}

		SpeedUpdate();
		float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		float moveVertical = Input.GetAxisRaw ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		movement.Normalize();
		GetComponent<Rigidbody>().velocity = movement * speed_now;

		GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);		
		//旋转封印
		/*
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
		
		//judge.GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
		Vector3 posi  = new Vector3
		(
			GetComponent<Rigidbody>().position.x, 
			GetComponent<Rigidbody>().position.y, 
			GetComponent<Rigidbody>().position.z
		);
		Vector3 axis_y  = new Vector3
		(
			0, 
			1, 
			0
		);
		judge.GetComponent<Transform>().RotateAround(posi, axis_y, -1*GetComponent<Rigidbody>().velocity.x * -tilt);
		*/
	}
}
