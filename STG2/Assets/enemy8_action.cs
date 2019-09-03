using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy8_action : MonoBehaviour
{
    Vector3 move = new Vector3(60, 0, 0);
    Vector3 init_position;
    Vector3 goal;
    float movementSpeed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        init_position = transform.position;
        goal = init_position + move;
        StartCoroutine(enemy8());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator enemy8()
    {
        while(transform.position != goal)
        {
            transform.position = Vector3.MoveTowards(transform.position, goal, movementSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0f);
        }

        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
