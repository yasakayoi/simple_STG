using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_destory_contact : MonoBehaviour
{
    public GameObject Player; 
    public GameObject playerExplosion;
    private Game_Process game_Process;
    public GameObject ReviveSphere;
    private bool enabled = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
        if (gameControllerObject != null)
            game_Process = gameControllerObject.GetComponent<Game_Process> ();
        else
            Debug.Log ("找不到tag为GameController的对象");

        if (game_Process == null)
            Debug.Log ("找不到 game_Process 脚本"); 
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {  
       if (other.tag == "Bullet_enemy" || other.tag == "Enemy")
       {
           if (enabled == false) {
               Game_Process.life = Game_Process.life - 1; //保护罩处于关闭状态才会减少生命
           }
           Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
           if(Game_Process.life == 0) {
                Destroy(other.gameObject);
                Destroy(gameObject);
           }
           else {
               game_Process.UpdateHP();
               Player.transform.position = new Vector3(0,0,-20);
               //ReviveSphere.transform.GetComponent<Collider>().enabled = true;
               StartCoroutine(cancerProtection());
           }
       }
    }

    IEnumerator cancerProtection() {
        //0~2s之内启动保护罩，即启动无敌时间
        ReviveSphere.SetActive(true);
        enabled = true;
        Player.transform.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(2f);

        //2s之后关闭保护罩
        ReviveSphere.SetActive(false);
        Player.transform.GetComponent<Collider>().enabled = true;
        enabled = false; 
        yield return new WaitForSeconds(1f);
    }
}
