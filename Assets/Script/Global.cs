using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{

    //public static int _HistoryScore;

   

    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(gameObject);
        //_HistoryScore = PlayerPrefs.GetInt("bestScore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
