using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Process : MonoBehaviour
{
    public GameObject enemy_type1;
    public GameObject enemy_type2;
    public GameObject enemy_type3;
    public GameObject enemy_type4;
    public GameObject enemy_type5;
    public GameObject enemy_type6;
    public GameObject enemy_type7;
    public GameObject enemy_type8;
    public GameObject enemy_type9;
    public GameObject enemy_type10;

    public GameObject boss_type1;
    public GameObject boss_type2;
    public GameObject boss_type3;

    public GameObject gameOver_Canves;
    public GameObject PlayGame;
    
    //public GameObject Player;
    private GameObject Player;//临时测试
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;

    private FindPlayer findPlayer;
    
    public static int life;

    public Text scoreText;
    public Text HPText;
    private int score;

    enum width{xmax = 25, zmax = 25};
    Vector3 position326 = new Vector3(-(float)width.xmax, 0f, 0.5f*(float)width.zmax + 5f);
    Vector3 position8210 = new Vector3(-(float)width.xmax * 0.5f, 0f, (float)width.zmax + 5f);
    Vector3 position12214 = new Vector3((float)width.xmax * 0.5f, 0f, (float)width.zmax + 5f);
    Vector3 position15217 = new Vector3((float)width.xmax * 0.75f, 0f, (float)width.zmax + 5f);
    Vector3 position25227 = new Vector3(-(float)width.xmax * 0.75f, 0f, (float)width.zmax + 5f);
    Vector3 position36237 = new Vector3(-(float)width.xmax * 0.428f, 0f, (float)width.zmax + 5f);
    Vector3 position37238 = new Vector3(-(float)width.xmax * 0.571f, 0f, (float)width.zmax + 5f);
    Vector3 position38239 = new Vector3(-(float)width.xmax * 0.714f, 0f, (float)width.zmax + 5f);
    Vector3 position43246 = new Vector3(0f, 0f, (float)width.zmax + 5f);
    Vector3 position49252 = new Vector3(-(float)width.xmax * 0.333f, 0f, (float)width.zmax + 5f);
    Vector3 position55258 = new Vector3(-(float)width.xmax * 0.6f, 0f, (float)width.zmax + 5f);
    Vector3 position61264 = new Vector3((float)width.xmax + 5, 0, (float)width.zmax * 0.667f);
    Vector3 position61264_1 = new Vector3(-(float)width.xmax - 5, 0, (float)width.zmax * 0.667f - 5);    

    Vector3 Bossposition = new Vector3(0f,0f,15f);
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
        switch (FindPlayer.index)
        {
            case 0: {
                Player = GameObject.Find("StarSparrow1 Variant 1");
                Player2.SetActive(false);
                Player3.SetActive(false);
                break;
            }
            case 1: {
                Player = GameObject.Find("StarSparrow3");
                Player1.SetActive(false);
                Player3.SetActive(false);
                break;
            }
            case 2: {
                Player = GameObject.Find("StarSparrow4");
                Player1.SetActive(false);
                Player2.SetActive(false);
                break;
            }
            default:
                break;
        }
        life = 3;
        score = 0;
        scoreText.text = "得分: " + score; 
        HPText.text = "\n\nHP: " + life;
        gameOver_Canves.SetActive(false);
        StartCoroutine(process());
    }

    void Update()
    {
        if(Player == null) {
            gameOver_Canves.SetActive(true);
            PlayGame.SetActive(false);
        }
    }

    IEnumerator process()
    {
        
        // 0 - 3 s
        yield return new WaitForSeconds(3f);

        // 3 - 6 s
        int enemy_counter = 0;
        while(enemy_counter < 6)
        {
            position326.x += 0.25f * (float)width.xmax;
            position326.z += 0.050f * (float)width.zmax;
            Instantiate(enemy_type1, position326, Quaternion.identity, PlayGame.transform);
            enemy_counter++;
            yield return new WaitForSeconds(0.5f);
        }
        enemy_counter = 0;

        // 6 - 8 s
        yield return new WaitForSeconds(2f);

        // 8 - 10 s
        while (enemy_counter < 6)
        {
            Instantiate(enemy_type2, position8210, Quaternion.identity, PlayGame.transform);
            enemy_counter++;
            yield return new WaitForSeconds(0.3f);
        }
        enemy_counter = 0;
        
        // 10 - 12 s
        yield return new WaitForSeconds(2f);

        // 12 - 14 s
        while (enemy_counter < 6)
        {
            Instantiate(enemy_type3, position12214, Quaternion.identity, PlayGame.transform);
            enemy_counter++;
            yield return new WaitForSeconds(0.3f);   
        }
        enemy_counter = 0;

        // 14 - 15 s
        yield return new WaitForSeconds(1f);

        // 15 - 17 s
        Instantiate(enemy_type4, position15217, Quaternion.identity, PlayGame.transform);

        // 17 - 19 s
        yield return new WaitForSeconds(2f);

        // 19 - 21 s
        while (enemy_counter < 6)
        {
            Instantiate(enemy_type3, position12214, Quaternion.identity, PlayGame.transform);
            enemy_counter++;
            yield return new WaitForSeconds(0.3f);   
        }
        enemy_counter = 0;

        // 21 - 23 s
        while (enemy_counter < 6)
        {
            Instantiate(enemy_type2, position8210, Quaternion.identity, PlayGame.transform);
            enemy_counter++;
            yield return new WaitForSeconds(0.3f);
        }
        enemy_counter = 0;

        // 23 - 25 s
        yield return new WaitForSeconds(2f);

        // 25 - 27 s
        Instantiate(enemy_type4, position25227, Quaternion.identity, PlayGame.transform);

        // 27 - 30 s
        yield return new WaitForSeconds(3f);

        // 30 - 31 s
        while (enemy_counter < 4)
        {
            Instantiate(enemy_type3, position12214, Quaternion.identity, PlayGame.transform);
            enemy_counter++;
            yield return new WaitForSeconds(0.3f);   
        }
        enemy_counter = 0;
        
        // 31 - 33 s
        while (enemy_counter < 10)
        {
            Instantiate(enemy_type2, position8210, Quaternion.identity, PlayGame.transform);
            Instantiate(enemy_type3, position12214, Quaternion.identity, PlayGame.transform);
            enemy_counter++;
            yield return new WaitForSeconds(0.1f);
        }
        enemy_counter = 0;

        // 33 - 36 s
        yield return new WaitForSeconds(3f);

        // 37 - 38 s
        while (enemy_counter < 5)
        {
            Instantiate(enemy_type5, position37238, Quaternion.identity, PlayGame.transform);
            position37238.x += 0.286f * (float)width.xmax;
            enemy_counter++;
            yield return new WaitForSeconds(0f);
        }
        enemy_counter = 0;
        yield return new WaitForSeconds(1f);

        // 38 - 39 s
        while (enemy_counter < 6)
        {
            Instantiate(enemy_type5, position38239, Quaternion.identity, PlayGame.transform);
            position38239.x += 0.286f * (float)width.xmax;
            enemy_counter++;
            yield return new WaitForSeconds(0f);
        }
        enemy_counter = 0;

        // 39 - 43 s
        yield return new WaitForSeconds(5f);

        // 43 - 46 s
        Instantiate(enemy_type6, position43246, Quaternion.identity, PlayGame.transform);

        // 46 - 49 s
        yield return new WaitForSeconds(3f);

        // 49 - 52 s
        Instantiate(enemy_type6, position49252, Quaternion.identity, PlayGame.transform);
        position49252.x += (float)width.xmax * 0.667f;
        Instantiate(enemy_type6, position49252, Quaternion.identity, PlayGame.transform);

        // 52 - 55 s
        yield return new WaitForSeconds(3f);

        // 55 - 58 s
        Instantiate(enemy_type6, position55258, Quaternion.identity, PlayGame.transform);
        position55258.x += (float)width.xmax * 1.2f;
        Instantiate(enemy_type6, position55258, Quaternion.identity, PlayGame.transform);

        // 58 - 61 s
        yield return new WaitForSeconds(3f);

        // 61 - 64 s
        while (enemy_counter < 6)
        {
            Instantiate(enemy_type7, position61264, Quaternion.identity, PlayGame.transform);
            Instantiate(enemy_type8, position61264_1, Quaternion.identity, PlayGame.transform);
            enemy_counter++;
            yield return new WaitForSeconds(0.5f);
        }
        enemy_counter = 0;

        // 64 - 65 s
        yield return new WaitForSeconds(1f);
        
        // 65 - 68 s
        while (enemy_counter < 6)
        {
            Instantiate(enemy_type9, position61264, Quaternion.identity, PlayGame.transform);
            Instantiate(enemy_type10, position61264_1, Quaternion.identity, PlayGame.transform);
            enemy_counter++;
            yield return new WaitForSeconds(0.5f);
        }
        enemy_counter = 0;
        
        // 68 - 70 s
        yield return new WaitForSeconds(2f);

        // 70 - 72 s
        position36237 = new Vector3(-(float)width.xmax * 0.428f, 0f, (float)width.zmax + 5f);
        while (enemy_counter < 4)
        {
            Instantiate(enemy_type5, position36237, Quaternion.identity, PlayGame.transform);
            position36237.x += 0.286f * (float)width.xmax;
            enemy_counter++;
            yield return new WaitForSeconds(0f);
        }
        enemy_counter = 0;
        yield return new WaitForSeconds(2f);

        // 72 - 75 s
        while (enemy_counter < 6)
        {
            Instantiate(enemy_type9, position61264, Quaternion.identity, PlayGame.transform);
            Instantiate(enemy_type10, position61264_1, Quaternion.identity, PlayGame.transform);
            enemy_counter++;
            yield return new WaitForSeconds(0.5f);
        }

        // 75 - 76 s
        yield return new WaitForSeconds(1f);

        // 76 - 79 s
        while (enemy_counter < 6)
        {
            Instantiate(enemy_type7, position61264, Quaternion.identity, PlayGame.transform);
            Instantiate(enemy_type8, position61264_1, Quaternion.identity, PlayGame.transform);
            enemy_counter++;
            yield return new WaitForSeconds(0.5f);
        }

        // 79 - 84 s
        yield return new WaitForSeconds(8f);
         
        
        //Boss1   +17s
        Instantiate(boss_type1, Bossposition, Quaternion.identity, PlayGame.transform);
        yield return new WaitForSeconds(17f);

        //Boss2   +17s
        Instantiate(boss_type2, Bossposition, Quaternion.identity, PlayGame.transform);
        yield return new WaitForSeconds(17f);

        //Boss3   +17s
        Instantiate(boss_type3, Bossposition, Quaternion.identity, PlayGame.transform);
        yield return new WaitForSeconds(17f);

    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "得分: " + score;
    }

    public void UpdateHP() {
        HPText.text = "\n\nHP: " + life;
    }

    public void OnRestart()//点击“重新开始”时执行此方法
    {
        Destroy(this);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void OnReturnMenu() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");
        Destroy(this);
    }

}
