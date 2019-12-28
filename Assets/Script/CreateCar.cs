using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateCar : MonoBehaviour
{
    public GameObject[] carPrefab;
   
    public Transform localTransform;
    public float frequency = 10f;
    public static bool CanMove = true;
    private int stopFrame = 125;

    private float lastCreateTime = -1;
    

    private void Awake()
    {
        if (localTransform == null)
            localTransform = transform;

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!CanMove)
        {
            Time.timeScale = 0;
            stopFrame --;
            //Debug.Log("stopFrame:" + stopFrame);
            if(stopFrame <= 0)
            {
                stopFrame = int.MaxValue;
                GameObject.Find("gameController").GetComponent<GameController>().setActiveTrue();

            }
        }
        //产生的时间间隔
        if (Time.time > lastCreateTime + 1 / frequency)
        {
            //FishPrefab[Random.Range(0, FishPrefab.Length)]
            GameObject g = Instantiate(carPrefab[Random.Range(0,carPrefab.Length)], localTransform.position, localTransform.rotation) as GameObject;
            Car car = g.GetComponent<Car>();
            g.transform.Rotate(0, 90, 0);
            car.setDirection(g.transform);
            lastCreateTime = Time.time + Random.Range(0.5f,1.5f);
        }
    }
}
