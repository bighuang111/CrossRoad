using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    public float speed;
    private Transform tr;
    private float spawnTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    //对象创建的时候调用
    void OnEnable()
    {
        //tr = transform;
        //spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        tr.position += tr.forward * speed * Time.deltaTime;

        if (transform.localPosition.x > ArrayHandler.length+5 || transform.localPosition.x < -5)
        {
            GameObject.DestroyImmediate(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)   //检测函数,并将检测的结果放入other变量中.
    {
        if (other.gameObject.tag == "Player")    //将检测结果的碰撞对象标签与player标签对比.判断是否相等
        {
            GameObject.Find("character").GetComponent<Move>().animator.SetTrigger("cry");
            Move.crossRoadNumbers = 0;
            Move.move = false;
            Move.activeInput = false;
            CreateCar.CanMove = false;
            Move.playerPosition = new Vector2(10, 0);
        }
    }

    public void setDirection(Transform transform)
    {
        tr = transform;
    }

    public void setRotation()
    {

    }

    private void getDirection()
    {

    }
}
