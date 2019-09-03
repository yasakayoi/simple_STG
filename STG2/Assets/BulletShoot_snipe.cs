using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot_snipe : MonoBehaviour
{   public GameObject Bullet1;
    public int BulletCount;
    int bulletNumber= 0;
    GameObject Bullet1_control;

    GameObject PlayerObj=null;

    private GameObject SaveBullet; //add By Lee

    int i=0;
    Vector3 goal ;
    public int Bulletfrequence;
    
    void Start()
    {
        
        if(PlayerObj==null)
        {
            PlayerObj = GameObject.FindGameObjectWithTag("Player");
        }
        

        if(SaveBullet == null) {
            SaveBullet = GameObject.FindGameObjectWithTag("SaveBullet");
        }
    }
    void FixedUpdate()
    {
        i++;
        if(i>Bulletfrequence && bulletNumber < BulletCount&&PlayerObj!=null)
        { 
    
            goal = PlayerObj.GetComponent<Rigidbody>().position;

            Bullet1_control=Instantiate(Bullet1,GetComponent<Rigidbody>().position,Quaternion.identity, SaveBullet.transform);
            
            Bullet1_control.GetComponent<Mover_bullet>().GetPlayerPosi(goal);
            i=0;
            bulletNumber++;
        }
    }
}
