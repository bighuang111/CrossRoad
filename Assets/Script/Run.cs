using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    public float speed = 1;
    private Transform tr;
    //public float interval = 1;
    private float times;

    private bool move;

    void OnEnable()
    {
        tr = transform;
        //spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        move = Move.move;
        if (move)
        {
            float step = speed * Time.deltaTime;

            /*times -= Time.deltaTime;
            if (times > 0)
            {
                tr.localPosition = Vector3.MoveTowards(tr.localPosition, new Vector3(Move.playerPosition.x, 0.5f, Move.playerPosition.y), step);
                //tr.position += tr.forward * speed * Time.deltaTime;

            }
            else
            {
                times = interval;
                Move.move = false;
                //Move.activeInput = true;

            }*/
            tr.localPosition = Vector3.MoveTowards(tr.localPosition, new Vector3(Move.playerPosition.x, 0.5f, Move.playerPosition.y), step);
        }

    }
}
