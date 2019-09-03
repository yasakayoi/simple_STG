using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movein_up : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 down = new Vector3(0, 0, -5f);
    float movementSpeed = 5f;
    Vector3 goal;
    void Start()
    {
        goal = transform.position+down;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, goal, movementSpeed * Time.deltaTime);
    }

}
