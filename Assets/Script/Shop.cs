using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
   
     //0：代表 
     //1：代表 已拥有
     //2：代表 使用中
    


    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(delegate () {
            string text = this.gameObject.GetComponentInChildren<Text>().text;
            string name = gameObject.name;
            Debug.Log(name);
            if (text == "使用中")
            {
                Debug.Log("已经是当前使用角色");
            }
            else if (text == "已拥有")
            {
                Debug.Log("已经购买的角色，成功切换");
                this.gameObject.GetComponentInChildren<Text>().text = "使用中";
                setPlayersValueOne();
                PlayerPrefs.SetInt(name, 2);
                GameObject.Find("players").GetComponent<UpdateName>().updateUseName();
                PlayerPrefs.SetString("CurrentPlayer", name);
            }
            else
            {
                Debug.Log("未购买的角色");
                if(PlayerPrefs.GetInt("reward") >= int.Parse(text))
                {
                    Debug.Log("成功购买");
                    int reward = PlayerPrefs.GetInt("reward") - int.Parse(text);
                    PlayerPrefs.SetInt("reward", reward);
                    PlayerPrefs.SetInt(name, 1);
                    this.gameObject.GetComponentInChildren<Text>().text = "已拥有";
                    GameObject.Find("gameController").GetComponent<GameController>().rewardScore.text = PlayerPrefs.GetInt("reward").ToString();
                }
                else
                {
                    Debug.Log("金币不足");
                }
            }
        });
        GameObject.Find("players").GetComponent<UpdateName>().updateUseName();
    }



    // Update is called once per frame
    void Update()
    {
    }


    public void setPlayersValueOne() {
        for(int i = 0; i < 9; i++)
        {
            string name = "players" + i;
            if (PlayerPrefs.GetInt(name) == 2)
            {
                PlayerPrefs.SetInt(name, 1);
            }
        }
    }
}
