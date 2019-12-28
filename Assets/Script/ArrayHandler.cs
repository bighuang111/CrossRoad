using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ArrayHandler : MonoBehaviour
{
    public GameObject[] target;
    [SerializeField]
    public int roadDepth;
    [SerializeField]
    public int roadLength;
    public static int length;
    public static int depth;
    private GameObject controlObject;
    private void Awake()
    {
        length = roadLength;
        depth = roadDepth;
    }
    // Start is called before the first frame update
    void Start()
    {
        //controlObject = new GameObject("AutoRoads");
        for (int i = 0; i < roadDepth; i++)
        {
            GameObject g = Instantiate(target[Random.Range(0, target.Length)], new Vector3(length / 2, 0, i + 1), Quaternion.identity);
        }
    }

#if UNITY_EDITOR
    //有数值变化时调用
    private void OnValidate()
    {
        //DestroyImmediate(controlObject);
        
        for (int i = 0; i < roadDepth; i++)
        {

            //GameObject g = Instantiate(target[Random.Range(0, target.Length)], new Vector3(roadLength / 2, 0, i + 1), Quaternion.identity);
        }

    }

    private void Reset()
    {
        //GameObject go = new GameObject("Cube1");
        for (int i = 0; i < roadDepth; i++)
        {
            //GameObject g = Instantiate(target[Random.Range(0, target.Length)], new Vector3(roadLength / 2, 0, i + 1), Quaternion.identity);
        }
    }
#endif


}
