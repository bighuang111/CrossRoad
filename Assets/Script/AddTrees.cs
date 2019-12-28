using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTrees : MonoBehaviour
{
    public GameObject[] trees;
    //public GameObject ground;
    public int numbersOfTree;

    private int z;
    private int roadlength;

    private Vector3 scale;
    // Start is called before the first frame update

    private void Awake()
    {
        scale = transform.localScale;
        scale.x = ArrayHandler.length / 10;
        transform.localScale = scale;
    }

    void Start()
    {
        roadlength = ArrayHandler.length;
        z = (int)transform.position.z;
        int numberOfTrees = Random.Range(numbersOfTree/2, numbersOfTree);

        //GameObject theGround = Instantiate(ground, new Vector3((roadlength/2), 0, z), Quaternion.identity);

        for (int i = 0; i < numberOfTrees; i++)
        {
            int x = Random.Range((roadlength / 2)- (roadlength / 2)/2, (roadlength / 2)+ (roadlength / 2)/2);
            if (CreateMap.map[x, z] == 0)
            {
                CreateMap.map[x, z] = 1;
                GameObject g = Instantiate(trees[Random.Range(0, trees.Length)], new Vector3(x, 0.5f, z), Quaternion.identity);
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
    }



}
