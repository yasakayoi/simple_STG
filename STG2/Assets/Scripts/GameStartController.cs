using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartController : MonoBehaviour
{
    
	
    //游戏界面状态机

	//主菜单界面
	public const int STATE_MAINMENU = 0;
	//开始游戏界面
	public const int STATE_STARTGAME = 1;
	//游戏设置界面
	public const int STATE_OPTION = 2;
	//游戏帮助界面
	public const int STATE_HELP = 3;
	//游戏退出界面
	public const int STATE_EXIT = 4;
    

    //当前游戏状态
	private int gameState;
    
    public GameObject startGameMenu;//游戏开始菜单
    public GameObject GameChoose;//游戏选择菜单
    
    
    
    
    void Start()
    {
        //初始化游戏状态为：主菜单界面
        OnRenderMainMenu();
        GameChoose.SetActive(false);
        Application.targetFrameRate = 60; //锁定帧数
    }

    void Update()
    {
        
    }


    public void OnRenderMainMenu() {
        gameState = STATE_MAINMENU; //进入游戏游玩
        startGameMenu.SetActive(true);  //设定游戏菜单界面
    }
    
    public void OnRenderStart() {
        gameState = STATE_STARTGAME; //进入游戏游玩
        startGameMenu.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        //Application.LoadLevel("SampleScene");
        Destroy(this);
        //Application.LoadLevel("SampleScene");
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void OnRenderOption() {
        startGameMenu.SetActive(false);
        GameChoose.SetActive(true);
    }

    void RenderHelp() {
        
    }

    public void RenderExit() {
        Application.Quit(); //结束游戏
    }

}
