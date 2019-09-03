using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3_action : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 down = new Vector3(0, 0, -30f);
    Vector3 checkAPoint = new Vector3(-15f, 0f, 30f);
    float movementSpeed = 10f;
    Vector3 goal;
    void Start()
    {
        goal = transform.position + down;
        StartCoroutine(enemy3());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator enemy3()
    {
        while(transform.position != goal)
        {
            transform.position = Vector3.MoveTowards(transform.position, goal, movementSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0f);   
        }
        
        while(transform.position != checkAPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, checkAPoint, movementSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0f);
        }
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
