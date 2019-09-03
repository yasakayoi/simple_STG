using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPause : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ingameMenu;//关于游戏暂停
    public GameObject player;//游玩内容的传递
    public bool IsGamePaused;//游戏是否暂停
    void Start()
    {
        IsGamePaused = false;
        Time.timeScale = 1f;
        ingameMenu.SetActive(false);
        //Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)) {
            IsGamePaused = true;
            Time.timeScale = 0;
            ingameMenu.SetActive(true);
            player.SetActive(false);
        }
    }
    
    public void OnResume()//点击“回到游戏”时执行此方法
    {
        IsGamePaused = false;
        Time.timeScale = 1f;
        ingameMenu.SetActive(false);
        player.SetActive(true);
    }

    public void OnRestart()//点击“重新开始”时执行此方法
    {
        //Destroy(this);
        //Application.LoadLevel("SampleScene");
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        /*
        IsGamePaused = false;
        Time.timeScale = 1f;
        ingameMenu.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        */
    }
    
    public void OnReturnMenu() {
        IsGamePaused = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");
        Destroy(this);
    }

}
