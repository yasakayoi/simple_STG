using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_moveout_up : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 up = new Vector3(0, 0, 10f);
    float movementSpeed = 10f;
    float init_time;
    Vector3 goal;
    void Start()
    {
        init_time = Time.time;
        goal = transform.position+up;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(Time.time - init_time >= 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, goal, movementSpeed * Time.deltaTime);
        }
        if(Time.time - init_time >= 4)
        {
            Destroy(gameObject);
        }
    }
}
