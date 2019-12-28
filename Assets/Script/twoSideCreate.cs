using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twoSideCreate : MonoBehaviour
{
    public GameObject target;
    private GameObject targetLeft;
    private GameObject targetRight;

    public float randomRate;

    private Vector3 objPosition_left;
    private Vector3 objPosition_right;

    private Vector3 objTransfrom_left;
    private Vector3 objTransfrom_right;

    private Vector3 scale;

    private void Awake()
    {
        scale = transform.localScale;
        scale.x = ArrayHandler.length / 10;
        transform.localScale = scale;
    }
    // Start is called before the first frame update
    void Start()
    {
        targetLeft = target;
        targetRight = target;

        objPosition_left = targetLeft.transform.position;
        //这里的10指的车道的长度
        objPosition_right = targetRight.transform.position + new Vector3(scale.x*10, 0, 0);

        if (Random.Range(0, 1f) > randomRate)
        {

                objPosition_left = new Vector3(objPosition_left.x, objPosition_left.y, objPosition_left.z);
                Instantiate(targetLeft, objPosition_left, Quaternion.identity);
                target.SetActive(false);
        }
        else
        {

                objPosition_right = new Vector3(objPosition_right.x, objPosition_right.y, objPosition_right.z);
                Instantiate(targetRight, objPosition_right, new Quaternion(0, 90, 0, 0));
            target.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
