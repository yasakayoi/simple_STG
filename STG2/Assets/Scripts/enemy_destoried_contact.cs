using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_destoried_contact : MonoBehaviour
{
    public int hp = 1;
    int hp_counter;
    public GameObject explosion;
    private Game_Process game_Process;
    public int scoreValue; //add By lee负责设置该类型战机得分
    //Start is called before the first frame update
    void Start()
    {
        hp_counter = 0;
        GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
        if (gameControllerObject != null)
            game_Process = gameControllerObject.GetComponent<Game_Process> ();
        else
            Debug.Log ("找不到tag为GameController的对象");
        if (game_Process == null)
            Debug.Log ("找不到 game_Process 脚本");       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet_me")
        {
           hp_counter++;
           if(hp_counter == hp)
           {
                Destroy(gameObject);
                Instantiate(explosion, transform.position, transform.rotation);
                game_Process.AddScore(scoreValue);
           }
           Destroy(other.gameObject);
       }
    }
}
