using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    //行 x
    private int row;
    //列 z
    private int col;

    public static float[,] map;

    

    private void Awake()
    {
        row = ArrayHandler.length;
        col = ArrayHandler.depth;
        map = new float[row+1, col+1];
        for (int i = 0; i <= row; i++)
        {
            for (int j = 0; j <= col; j++)
            {
                map[i, j] = 0;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
