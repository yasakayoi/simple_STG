using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_jump : MonoBehaviour
{
    // Start is called before the first frame update
	Vector3 movement;
	bool ismove=false;
    float Speed_Bullet;
    float AccSpeed = -0.5f;
    float Max_Speed =-25f;
    float Min_Speed =-5f;
    void Start()
    {
        Speed_Bullet = Random.Range((-1)*Min_Speed,(-1)*Max_Speed);
    }

    // Update is called once per frame
    void Update()
    {
        Speed_Bullet+=AccSpeed;
        if(Speed_Bullet<Max_Speed)
        {
            Speed_Bullet =Max_Speed;
        }
        transform.Translate(Vector3.forward * Speed_Bullet * Time.deltaTime);
    }
}
