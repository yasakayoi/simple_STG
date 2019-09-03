using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot_pile : MonoBehaviour
{
    public GameObject Bullet1;
    GameObject Bullet1_control;

    GameObject PlayerObj=null;

    private GameObject SaveBullet; //add By Lee
    static float spacing =3;
    Vector3[] vector = {new Vector3(-3*spacing,0,(float)1.73*spacing),new Vector3(-1*spacing,0,(float)1.73*spacing),new Vector3(1*spacing,0,(float)1.73*spacing),new Vector3(3*spacing,0,(float)1.73*spacing),
                        new Vector3(-2*spacing,0,0),new Vector3(0,0,0),new Vector3(2*spacing,0,0)
                        ,new Vector3(-1*spacing,0,(float)-1.73*spacing),new Vector3(1*spacing,0,(float)-1.73*spacing)
                        ,new Vector3(0,0,2*(float)-1.73*spacing)};

    Vector3 goal ;
    public int BulletCount;
    int i = 0;
    int j = 0;
    int k=0;
    float z_angel=0;
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
        if(i>Bulletfrequence&&j<BulletCount&&PlayerObj!=null)
        { 
    
            goal = PlayerObj.GetComponent<Rigidbody>().position;
            //Bullet1_control=Instantiate(Bullet1,GetComponent<Rigidbody>().position+vector[1],Quaternion.identity);
            //Bullet1_control.GetComponent<Mover_bullet>().GetPlayerPosi(goal+vector[1]);
            //for循环在FixedUpdate有问题
             
            z_angel =Mathf.Atan2(goal.x-GetComponent<Rigidbody>().position.x,goal.z-GetComponent<Rigidbody>().position.z);
            //angel_tanB = Mathf.Tan(getangel* Mathf.PI / 180);
            z_angel=180-1*z_angel*180/Mathf.PI;
           
            while(k<10)
            {
                Bullet1_control=Instantiate(Bullet1,GetComponent<Rigidbody>().position+vector[k], Quaternion.Euler(90,0,z_angel), SaveBullet.transform);
            
                Bullet1_control.GetComponent<Mover_bullet>().GetPlayerPosi(goal+vector[k]);
                k++;
            }
            j++;
            k=0;
            i=0;
        }
    }
}
