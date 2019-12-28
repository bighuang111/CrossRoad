using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public Animator animator;

    public static int crossRoadNumbers = 0;

    private Vector3 localVelocity;
    private Vector3 lastPosition;
    private float times = 1;

    private Transform tr;

    public static bool move = false;

    //这个数值应该存在数据库里
    private int historyScore;
    public static int currentScore;

    public static bool activeInput = true;

    public static Vector2 playerPosition = new Vector2(10, 0);

    private int stopFrame = 125;
    private bool isComplete;
    //对象创建的时候调用

    // Start is called before the first frame update
    void Start()
    {
        tr = transform;
        playerPosition.x = tr.position.x;
        playerPosition.y = tr.position.z;
        lastPosition = tr.position;
        currentScore = 0;
        historyScore = PlayerPrefs.GetInt("bestScore");
        GameObject.Find("gameController").GetComponent<GameController>().historyScore.text = historyScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        bool front = Input.GetKeyDown(KeyCode.W);
        bool upArrow = Input.GetKeyDown(KeyCode.UpArrow);
        bool back = Input.GetKeyDown(KeyCode.S);
        bool backArrow = Input.GetKeyDown(KeyCode.DownArrow);
        bool left = Input.GetKeyDown(KeyCode.A);
        bool leftArrow = Input.GetKeyDown(KeyCode.LeftArrow);
        bool right = Input.GetKeyDown(KeyCode.D);
        bool rightArrow = Input.GetKeyDown(KeyCode.RightArrow);

        //延时弹出菜单
        if (isComplete)
        {
            Debug.Log("isComplete");
            stopFrame--;
            if (stopFrame == 0)
            {
                Debug.Log("showMenu");
                stopFrame = 125;
                GameObject.Find("gameController").GetComponent<GameController>().showFinishMenu();
            }
        }

        if((int)playerPosition.y > currentScore)
        {
            currentScore = (int)playerPosition.y;
            GameObject.Find("gameController").GetComponent<GameController>().currentScore.text = currentScore.ToString();
        }

        if((int)playerPosition.y > historyScore)
        {
            PlayerPrefs.SetInt("bestScore", (int)playerPosition.y);
            GameObject.Find("gameController").GetComponent<GameController>().historyScore.text = PlayerPrefs.GetInt("bestScore").ToString();
        }

        if (GameController.canControlGame)
        {
            if (front || upArrow)
            {
                animator.SetTrigger("run");

                Vector3 target = new Vector3(tr.position.x, tr.position.y, tr.position.z + 1);
                transform.LookAt(target);



                if ((int)playerPosition.y + 1 > ArrayHandler.depth)
                {
                    Debug.Log("win");
                    GameObject.Find("JunkoChan").GetComponent<Move>().animator.SetTrigger("happy");
                    isComplete = true;
                    playerPosition = new Vector2(playerPosition.x, playerPosition.y + 1);
                    move = true;
                }
                else if (CreateMap.map[(int)playerPosition.x, (int)playerPosition.y + 1] == 0)
                {


                    playerPosition = new Vector2(playerPosition.x, playerPosition.y + 1);
                    Debug.Log("playerPosition:" + playerPosition);
                    move = true;
                    //activeInput = false;
                }
                else
                {
                    Debug.Log("有障碍");
                    Debug.Log("playerPosition:" + playerPosition);
                }

            }
            if (left || leftArrow)
            {
                animator.SetTrigger("run");

                Debug.Log("playerPosition:" + playerPosition);

                Vector3 target = new Vector3(tr.position.x - 1, tr.position.y, tr.position.z);
                transform.LookAt(target);

                Vector2 nextPosition = playerPosition;
                //等于0 说明下个位置没有障碍
                if (CreateMap.map[(int)playerPosition.x - 1, (int)playerPosition.y] == 0)
                {
                    move = true;
                    activeInput = false;
                    playerPosition = new Vector2(playerPosition.x - 1, playerPosition.y);
                }
                else
                {
                    Debug.Log("有障碍");
                }


            }
            if (right || rightArrow)
            {
                animator.SetTrigger("run");


                //Debug.Log("playerPosition:" + playerPosition);

                Vector3 target = new Vector3(tr.position.x + 1, tr.position.y, tr.position.z);
                transform.LookAt(target);

                //等于0 说明下个位置没有障碍
                if (CreateMap.map[(int)playerPosition.x + 1, (int)playerPosition.y] == 0)
                {
                    move = true;
                    activeInput = false;
                    playerPosition = new Vector2(playerPosition.x + 1, playerPosition.y);
                }
                else
                {
                    Debug.Log("有障碍");
                }
            }
            if (back || backArrow)
            {
                animator.SetTrigger("run");

                Debug.Log("playerPosition:" + playerPosition);

                Vector3 target = new Vector3(tr.position.x, tr.position.y, tr.position.z - 1);

                transform.LookAt(target);

                //等于0 说明下个位置没有障碍
                if (CreateMap.map[(int)playerPosition.x, (int)playerPosition.y - 1] == 0)
                {
                    playerPosition = new Vector2(playerPosition.x, playerPosition.y - 1);

                    move = true;
                    activeInput = false;
                }
                else
                {
                    Debug.Log("有障碍");
                }
            }
        }



    
    }

}
