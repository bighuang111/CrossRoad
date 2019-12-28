using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public Transform player;
    Vector3 distance;
    Vector3 ve;


    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        //平滑阻尼移动
        transform.position = Vector3.SmoothDamp(transform.position, player.position + distance, ref ve, 0);
    }

    private void LateUpdate()
    {
        if (player != null)
            GameObject.Find("Main Camera").transform.LookAt(player.transform.position);
    }
}
