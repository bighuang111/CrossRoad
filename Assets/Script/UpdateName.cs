using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateName : MonoBehaviour
{
    public GameObject player0;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject player5;
    public GameObject player6;
    public GameObject player7;
    public GameObject player8;

    // Start is called before the first frame update
    void Start()
    {
        updateUseName();
        

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateUseName() {
        //遍历对象的子物体，根据数据库中的拥有情况 给页面赋值
        Button[] father = GetComponentsInChildren<Button>();
        foreach (var child in father)
        {
            if (PlayerPrefs.GetInt(child.name) == 2)
            {
                child.GetComponentInChildren<Text>().text = "使用中";
                if (child.name == "players0") {
                    GameObject.Find("gameController").GetComponent<GameController>().allFalse(); 
                    GameObject.Find("gameController").GetComponent<GameController>().CharacterPlayers[0].SetActive(true); 
                }
                if (child.name == "players1")
                {
                    GameObject.Find("gameController").GetComponent<GameController>().allFalse();
                    GameObject.Find("gameController").GetComponent<GameController>().CharacterPlayers[1].SetActive(true);
                }
                if (child.name == "players2")
                {
                    GameObject.Find("gameController").GetComponent<GameController>().allFalse();
                    GameObject.Find("gameController").GetComponent<GameController>().CharacterPlayers[2].SetActive(true);
                }
                if (child.name == "players3")
                {
                    GameObject.Find("gameController").GetComponent<GameController>().allFalse();
                    GameObject.Find("gameController").GetComponent<GameController>().CharacterPlayers[3].SetActive(true);
                }
                if (child.name == "players4")
                {
                    GameObject.Find("gameController").GetComponent<GameController>().allFalse();
                    GameObject.Find("gameController").GetComponent<GameController>().CharacterPlayers[4].SetActive(true);
                }
                if (child.name == "players5")
                {
                    GameObject.Find("gameController").GetComponent<GameController>().allFalse();
                    GameObject.Find("gameController").GetComponent<GameController>().CharacterPlayers[5].SetActive(true);
                }
                if (child.name == "players6")
                {
                    GameObject.Find("gameController").GetComponent<GameController>().allFalse();
                    GameObject.Find("gameController").GetComponent<GameController>().CharacterPlayers[6].SetActive(true);
                }
                if (child.name == "players7")
                {
                    GameObject.Find("gameController").GetComponent<GameController>().allFalse();
                    GameObject.Find("gameController").GetComponent<GameController>().CharacterPlayers[7].SetActive(true);
                }
                if (child.name == "players8")
                {
                    GameObject.Find("gameController").GetComponent<GameController>().allFalse();
                    GameObject.Find("gameController").GetComponent<GameController>().CharacterPlayers[8].SetActive(true);
                }

            }
            if (PlayerPrefs.GetInt(child.name) == 1)
            {
                child.GetComponentInChildren<Text>().text = "已拥有";
            }
            if (PlayerPrefs.GetInt(child.name) == 0)
            {
                child.GetComponentInChildren<Text>().text = 100+"";
            }
        }
    }

}
