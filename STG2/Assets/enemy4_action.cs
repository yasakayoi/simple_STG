using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy4_action : MonoBehaviour
{
    Vector3 move = new Vector3(0, 0, 21.75f);
    Vector3 init_position;
    Vector3 goal;
    float movementSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        init_position = transform.position;
        goal = init_position - move;
        StartCoroutine(enemy4());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator enemy4()
    {
        while(transform.position != goal)
        {
            transform.position = Vector3.MoveTowards(transform.position, goal, movementSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0f);
        }

        yield return new WaitForSeconds(0.6f);

        while(transform.position != init_position)
        {
            transform.position = Vector3.MoveTowards(transform.position, init_position, movementSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0f);
        }

        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
