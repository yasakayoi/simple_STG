using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot_jump : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Bullet1;
    public int BulletCount;
    GameObject Bullet1_control;
    private GameObject SaveBullet; //add By Lee
    public int Bulletfrequence;
    float Random_x;
    float Random_z;
    int i =0;
    int bulletNumber=0;
    float Bullet_Xposi_Range =5f;

    float Bullet_Zposi_Range= 10f;
    float j =0;
    Vector3 Position_set;
    Vector3 goal;
    void Start()
    {
        if(SaveBullet == null) {
            SaveBullet = GameObject.FindGameObjectWithTag("SaveBullet");
        }
        Position_set =new Vector3(-25,0,0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        i++;
        if(i>Bulletfrequence && bulletNumber < BulletCount)
        {
            while((Position_set.x+j*Bullet_Xposi_Range)<25)
            {
                
                Random_x = Random.Range(0,Bullet_Xposi_Range);
                Random_z = Random.Range(0,Bullet_Zposi_Range);

                goal.x =Position_set.x+j*Bullet_Xposi_Range+Random_x;
                goal.z =Position_set.z+Random_z;

                Bullet1_control=Instantiate(Bullet1,goal,Quaternion.identity, SaveBullet.transform);
                j++;

            }
            j=0;
            i=0;
            bulletNumber++;
        }
    }
}
