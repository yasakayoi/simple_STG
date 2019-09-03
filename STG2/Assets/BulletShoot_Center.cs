using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot_Center : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Bullet1;
    public int BulletCount;
    int bulletNumber= 0;
    public int Min_Num_wave;
    public int Max_Num_wave;
    int bullet_Number_wave;
    private GameObject SaveBullet; //add By Lee


    int i=0;
    int j=0;
    public int Bulletfrequence;
    void Start()
    {
        if(SaveBullet == null) {
            SaveBullet = GameObject.FindGameObjectWithTag("SaveBullet");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        i++;
        
        if(i>Bulletfrequence && bulletNumber < BulletCount)
        { 
            bullet_Number_wave = Random.Range(Min_Num_wave,Max_Num_wave);
            while(j<bullet_Number_wave)
            {
                Instantiate(Bullet1,GetComponent<Rigidbody>().position,Quaternion.identity, SaveBullet.transform);//开花弹中的一发
                j++;
            }
            i=0;
            j=0;
            bulletNumber++;
        }
    }
    
}
