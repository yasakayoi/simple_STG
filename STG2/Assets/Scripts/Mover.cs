using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20.0f;
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
