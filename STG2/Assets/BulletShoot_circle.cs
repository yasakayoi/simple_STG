using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot_circle : MonoBehaviour
{ 
    public GameObject Bullet1;
    public int BulletCount;
    int bulletNumber= 0;
    static float angel = 20;
    GameObject Bullet1_control;

    GameObject PlayerObj=null;

    private GameObject SaveBullet; //add By Lee


    float angel_tanA;//发弹源和自机的角度
    float angel_tanB;//增加的角度
    int i=0;
    int j=0;
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
            while(j < 18)
            {
                goal = GetOtherWayGoal(angel*j);

                Bullet1_control=Instantiate(Bullet1,GetComponent<Rigidbody>().position,Quaternion.identity, SaveBullet.transform);//开花弹中的一发
            
                Bullet1_control.GetComponent<Mover_bullet>().GetPlayerPosi(goal);
                j++;
            }

            j=0;
            i=0;
            bulletNumber++;
        }
    }

    
    Vector3 GetOtherWayGoal(float getangel)
    {
        angel_tanB = Mathf.Tan(getangel* Mathf.PI / 180);
        float x1 = GetComponent<Rigidbody>().position.x;//发弹源位置
        float z1 = GetComponent<Rigidbody>().position.z;
        float x2 = PlayerObj.GetComponent<Rigidbody>().position.x;//目标位置
        float z2 = PlayerObj.GetComponent<Rigidbody>().position.z;
        
        if(getangel>=180&&getangel<360)
        {
            x2 =x1*2-x2;
            z2 =z1*2-z2;
        }

         if(Mathf.Abs(z2-z1)>Mathf.Abs(x2-x1))
        {
            if(x1 == x2)
            {
                return new Vector3(x2+angel_tanB*(z2-z1),0,z2);
            }
            else
            {
                angel_tanA = (z1-z2)/(x1-x2);

                float temp_tan = (angel_tanA +angel_tanB)/(1-angel_tanA*angel_tanB);
            //    return new Vector3(x2,0,(z1+temp_tan*(x2-x1)));
                return new Vector3(((z2-z1)/temp_tan)+x1,0,z2);
            }
        }
        else
        {
            if(z1 == z2)
            {
               // return new Vector3(x2+angel_tanB*(z2-z1),0,z2);
                
                return new Vector3(x2,0,z2+angel_tanB*(x2-x1));
            }
            else
            {
                angel_tanA = (z1-z2)/(x1-x2);

                float temp_tan = (angel_tanA +angel_tanB)/(1-angel_tanA*angel_tanB);
                return new Vector3(x2,0,(z1+temp_tan*(x2-x1)));
            //    return new Vector3(((z2-z1)/temp_tan)+x1,0,z2);
            }
        }
        

        }
}

