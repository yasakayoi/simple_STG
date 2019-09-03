using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot_2way : MonoBehaviour
{
    public GameObject Bullet1;
    GameObject Bullet1_control;
    GameObject Bullet1_control_add;
    public int BulletCount;
    GameObject Bullet1_control_cut;

    GameObject PlayerObj=null;

    private GameObject SaveBullet; //add By Lee
    public float angel =15;
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
            PlayerObj = GameObject.FindWithTag("Player");
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
            /* 
            Bullet1_control=Instantiate(Bullet1,GetComponent<Rigidbody>().position,Quaternion.identity, SaveBullet.transform); //中间弹道的子弹
            goal = PlayerObj.GetComponent<Rigidbody>().position;
            Bullet1_control.GetComponent<Mover_bullet>().GetPlayerPosi(goal);
*/

            Bullet1_control_add=Instantiate(Bullet1,GetComponent<Rigidbody>().position,Quaternion.identity, SaveBullet.transform); //增加角度的弹道的子弹
            goal = GetOtherWayGoal(angel);
            Bullet1_control_add.GetComponent<Mover_bullet>().GetPlayerPosi(goal);

            Bullet1_control_cut=Instantiate(Bullet1,GetComponent<Rigidbody>().position,Quaternion.identity, SaveBullet.transform); //减少角度的弹道的子弹
            goal = GetOtherWayGoal(angel*-1);
            Bullet1_control_cut.GetComponent<Mover_bullet>().GetPlayerPosi(goal);

            i=0;
            j++;
        }
    }

    Vector3 GetOtherWayGoal(float getangel)
    {
        angel_tanB = Mathf.Tan(getangel* Mathf.PI / 180);
        float x1 = GetComponent<Rigidbody>().position.x;//发弹源位置
        float z1 = GetComponent<Rigidbody>().position.z;
        float x2 = PlayerObj.GetComponent<Rigidbody>().position.x;//目标位置
        float z2 = PlayerObj.GetComponent<Rigidbody>().position.z;
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
