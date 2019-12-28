using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject Menu;
    public GameObject AfterDeathMenu;
    
    public GameObject finishMenu;

    public Text AfterDeathMenuReward;
    public Text currentScore;
    public Text historyScore;
    public Text rewardScore;

    public Text Countdown;

    private int CountDownTime = 3;

    private int currentNumbers;
    private int historyNumbers;
    private int rewardNumbers;



    public static bool getRrewards = true;
    public static bool canControlGame = false;

    private int[] players = new int[9];

    public GameObject[] CharacterPlayers;




    private void Awake()
    {
        PlayerPrefs.SetInt("FirstRun", 1);
        //修改金币
        //PlayerPrefs.SetInt("reward", 200);
        //GameObject.Find("gameController").GetComponent<GameController>().rewardScore.text = PlayerPrefs.GetInt("reward").ToString();
        allFalse();
        string currentPlayer = PlayerPrefs.GetString("CurrentPlayer");
        string result = currentPlayer.Substring(7);//索引从0开始，第一个字符代表0
        int number = int.Parse(result);
        CharacterPlayers[number].SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        string name = PlayerPrefs.GetString("CurrentPlayer");

        if (PlayerPrefs.GetInt("FirstRun") == 1) {

            PlayerPrefs.SetInt("players", 2);
            PlayerPrefs.SetInt("FirstRun", 0);
        }
        //GameObject.Find("players").GetComponent<UpdateName>().updateUseName();
        StartCoroutine("countDown");
        rewardScore.text = PlayerPrefs.GetInt("reward").ToString();

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void showMenu()
    {
        Menu.SetActive(true);
        Time.timeScale = 0;
    }


    public void advance() {
        SceneManager.LoadScene("Second");
    }

    public void createCar(Vector3 pos,GameObject car)
    {

    }

    public void destroyCar(GameObject gameObject)
    {
        GameObject.DestroyImmediate(gameObject);
    }

    public void OnResume()
    {
        Time.timeScale = 1f;
        Menu.SetActive(false);
    }

    public void OnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        Move.activeInput = true;
        CreateCar.CanMove = true;
        canControlGame = false;
    }

    public void OnADMRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        Move.activeInput = true;
        CreateCar.CanMove = true;
        canControlGame = false;
        getRrewards = true;

    }
    public void OnADMGiveup()
    {
        SceneManager.LoadScene("FirstScene");
        Time.timeScale = 1;
        Move.activeInput = true;
        CreateCar.CanMove = true;
        canControlGame = false;
        getRrewards = true;
    }

    IEnumerator countDown()
    {
        while(CountDownTime >= 0)
        {
            if(CountDownTime > 0)
            {
                Countdown.text = CountDownTime+"";
                yield return new WaitForSeconds(1);
                CountDownTime--;
            }
            else
            {
                canControlGame = true;
                Countdown.text = "";
                yield break;
            }
        }
    }

    public void setActiveTrue() {
        if (getRrewards)
        {
            int add = Move.currentScore / 2;
            rewardNumbers = PlayerPrefs.GetInt("reward") + add;
            PlayerPrefs.SetInt("reward", rewardNumbers);
            AfterDeathMenuReward.text = "获得奖励" + add;
            rewardScore.text = PlayerPrefs.GetInt("reward").ToString();

            AfterDeathMenu.SetActive(true);
        }
        getRrewards = false;


    }

    public void showFinishMenu()
    {
        finishMenu.SetActive(true);
    }
    public void allFalse()
    {
        CharacterPlayers[0].SetActive(false);
        CharacterPlayers[1].SetActive(false);
        CharacterPlayers[2].SetActive(false);
        CharacterPlayers[3].SetActive(false);
        CharacterPlayers[4].SetActive(false);
        CharacterPlayers[5].SetActive(false);
        CharacterPlayers[6].SetActive(false);
        CharacterPlayers[7].SetActive(false);
        CharacterPlayers[8].SetActive(false);

    }
}

