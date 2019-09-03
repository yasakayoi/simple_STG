using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public static int index = 0;
    void Start()
    {
        GameObject.DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Application.isLoadingLevel)
        GameObject.DontDestroyOnLoad(gameObject);
    }

    public string findedPlayer() {
        string PlayerName = null;
        switch (index)
        {
            case 0: {
                PlayerName = "PlayerStarSparrow1 Variant 1"; 
                break;
            }
            case 1: {
                PlayerName= "StarSparrow3";
                break;
            }
            case 2: {
                PlayerName = "StarSparrow4";
                break;
            }
            default: {
                Debug.Log ("index wrong");
                break;
            }

        }
        return PlayerName;
    }

}
