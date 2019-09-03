using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePlayer : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Choose;
    public GameObject choose1;
    public GameObject choose2;
    public GameObject choose3;
    private FindPlayer findPlayer;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameObject FindPlayerObject = GameObject.FindWithTag("FindPlayer");
        if (FindPlayerObject != null)
            findPlayer = FindPlayerObject.GetComponent<FindPlayer> ();
        else
            Debug.Log ("找不到tag为FindPlayer");

        if (findPlayer == null)
            Debug.Log ("找不到 findPlayer 脚本"); 
        choose1.transform.GetComponent<Renderer>().enabled = true;
        choose2.transform.GetComponent<Renderer>().enabled = false;
        choose3.transform.GetComponent<Renderer>().enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            index += 1;
            if (index > 2) {
                index = 0;
            }    
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            index -= 1;
            if (index < 0) {
                index = 2;
            }
        }
        switch (index)
        {
            case 0: {
                //Debug.Log ("找不到tag为GameController的对象");
                choose1.transform.GetComponent<Renderer>().enabled = true;
                choose2.transform.GetComponent<Renderer>().enabled = false;
                choose3.transform.GetComponent<Renderer>().enabled = false;
                //choose.transform.position = new Vector3(-800, -90, -20);
                break;
            }
            case 1: {
                // Debug.Log ("找er的对象");
                choose1.transform.GetComponent<Renderer>().enabled = false;
                choose2.transform.GetComponent<Renderer>().enabled = true;
                choose3.transform.GetComponent<Renderer>().enabled = false;
                //choose.transform.position = new Vector3(-180, -90,-20);
                break;
            }
            case 2: {
                choose1.transform.GetComponent<Renderer>().enabled = false;
                choose2.transform.GetComponent<Renderer>().enabled = false;
                choose3.transform.GetComponent<Renderer>().enabled = true;
                //choose.transform.position = new Vector3(400,0,-20);
                break;
            }
            default:
                break;
        }
        FindPlayer.index = index;
    }

    public void OnConfirm() {
        FindPlayer.index = index;
        if(FindPlayer.index == 1) {
            Debug.Log("OK");
        }
        Choose.SetActive(false);
        Menu.SetActive(true);

    }
}
