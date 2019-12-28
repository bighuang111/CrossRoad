 
using System.Collections;

using System.Collections.Generic;

using UnityEngine;

 

public class GetMouseDirection : MonoBehaviour
{

    public static MouseDirection Dir;
    public static string dir;

    bool _activeInput;
    Vector3 _mousePos;
    Vector3 _touchPos;
    // Use this for initialization

    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(MouseAction());
    }

    IEnumerator MouseAction()
    {
        while (true)
        {
            GetInputDirection();

            yield return 0;
        }
    }

    void GetInputDirection()
    {
        Dir = MouseDirection.Null;
        if (Input.GetMouseButtonDown(0))
        {
            _activeInput = true;
            _mousePos = Input.mousePosition;
            //移动端的手指坐标（Input.touches[0].position）= Input.mousePosition（电脑端）
            /*移动端输入事件检测
             * if(input.touchCount==1) 一个手指按下
             * if(touchCount==2)  两个手指
             * if(input.touches[0].phase==TouchPhase.Beagn) 手指按下事件
             * if(input.touches[0].phase==TouchPhase.Move) 手指滑动事件
             * if(input.touches[0].phase==TouchPhase.Ended)&&Input.touches[0].phase!=TouchPhase.Canceled 手指松开
             * 
            */
           // _touchPos = Input.touches[0].position;

        }

        if (Input.GetMouseButton(0) && _activeInput)

        {

            //计算鼠标的向量

            //当前鼠标坐标减去鼠标按下时的坐标就可以得到鼠标滑动方向的向量

            Vector3 vec = Input.mousePosition - _mousePos;

            //判断向量长度，避免鼠标刚刚滑动就计算他的方向，给一定的长度能够准确判断鼠标滑动方向

            if (vec.magnitude > 20)
            {
                //Vector3.Dot获得点积
                //点积：
                //点积的计算方式为: a·b =| a |·| b | cos < a,b > 其中 | a | 和 | b | 表示向量的模，
                //< a,b > 表示两个向量的夹角。另外在 点积 中，< a,b > 和 < b,a > 夹角是不分顺序的。 
                //所以通过点积，我们其实是可以计算两个向量的夹角的。 
                //另外通过点积的计算我们可以简单粗略的判断当前物体是否朝向另外一个物体:
                //只需要计算当前物体的transform.forward向量与(otherObj.transform.position 
                //– transform.position)的点积即可， 大于0则面对，否则则背对着。当然这个计算也会有一点误差，但大致够用。 
                //然后取它的反余弦，获取到角度
                //Mathf.Acos(f);
                // 以弧度为单位计算并返回参数 f 中指定的数字的反余弦值。
                //在然后Mathf.Rad2（弧度转为度数）

                var angleY = Mathf.Acos(Vector3.Dot(vec.normalized, Vector2.up)) * Mathf.Rad2Deg;

                var angleX = Mathf.Acos(Vector3.Dot(vec.normalized, Vector2.right)) * Mathf.Rad2Deg;

                //判断鼠标在对X和Y的正方向的夹角

                if (angleY <= 45)

                {
                    Dir = MouseDirection.Up;
                }
                else if (angleY >= 135)
                {
                    Dir = MouseDirection.Down;

                }

                else if (angleX <= 45)

                {
                    Dir = MouseDirection.Right;

                }

                else if (angleX >= 135)

                {
                    Dir = MouseDirection.Left;
                }

                _activeInput = false;
                Debug.Log(Dir);

            }

        }

    }

    public enum MouseDirection

    {

        Null,

        Left,

        Right,

        Up,

        Down,

    }

}
