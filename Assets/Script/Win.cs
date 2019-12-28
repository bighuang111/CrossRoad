using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Win : MonoBehaviour
{
    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)   //检测函数,并将检测的结果放入other变量中.
    {
        if (other.gameObject.tag == "Player")    //将检测结果的碰撞对象标签与player标签对比.判断是否相等
        {
            Debug.Log("Win");
            menu.SetActive(true);
            GameObject.Find("JunkoChan").GetComponent<Move>().animator.SetTrigger("happy");
        }
    }
}
