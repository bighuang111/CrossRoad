using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudio : MonoBehaviour
{
    //音源AudioSource相当于播放器，而音效AudioClip相当于磁带
    private AudioSource music;
    //这里我要给主角添加跳跃的音效
    public AudioClip carAudio;

    private void Awake()
    {
        //给对象添加一个AudioSource组件
        music = gameObject.AddComponent<AudioSource>();
        //设置不一开始就播放音效
        music.playOnAwake = false;
        //加载音效文件
        //whistle = Resources.Load<AudioClip>("music/train");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //这里是逻辑代码，判断距离角色的距离,当小于某个数字的时候，可以鸣笛
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            music.clip = carAudio;
            music.Play();
        }
    }
}
