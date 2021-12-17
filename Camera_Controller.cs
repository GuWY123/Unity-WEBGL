using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform target; // 获取到相机围绕的物体
    public float smooth_speed = 10f;  //
    public float rot_speed_x = 4f;     //
    public float rot_speed_y = 2f;     //
    public float move_speed = 4000f;    //移动速度
    float X = 0;
    float Y = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //target = GameObject.Find("GameObject").GetComponent<Transform>();  //这里是给模型创建了一个空物体作为轴心
        camerazoom();
        Cam_Move();
        rotate();

    }
    void Cam_Move()
    {
        float X = -Input.GetAxis("Mouse X") * Time.deltaTime * move_speed; 
        float Y = -Input.GetAxis("Mouse Y") * Time.deltaTime * move_speed;

        if (Input.GetMouseButton(0))
        {  //鼠标左键
           //Debug.Log("move");
            if (Mathf.Abs(X) > Mathf.Abs(Y)) //保证视角不会太晃
            { 
                transform.Translate(Vector3.right * X, Space.Self);  //左右平移
            }
            if (Mathf.Abs(X) < Mathf.Abs(Y))
            {
                transform.Translate(Vector3.up * Y, Space.Self);
            }
            //Debug.Log(target.position);
        }

    }
    void rotate()
    {

        if (Input.GetMouseButton(1)) //鼠标右键
        {

            X = Input.GetAxis("Mouse X") * rot_speed_x * 0.02f;
            Y = Input.GetAxis("Mouse Y") * rot_speed_y * 0.02f;

            if (Mathf.Abs(X) > Mathf.Abs(Y) ) //保证视角不会太晃
            {
                Y = 0;
                transform.RotateAround(target.position, Vector3.up, -X * Mathf.Rad2Deg);
            }
            if (Mathf.Abs(X) < Mathf.Abs(Y))
            {
                X = 0;
                //transform.RotateAround(target.position, Vector3.right, -Y * Mathf.Rad2Deg);
                transform.Rotate(Vector3.right, -Y * Mathf.Rad2Deg);
            }

        }
    }
   
    private void camerazoom() //摄像机滚轮缩放
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {

            transform.Translate(Vector3.forward * smooth_speed);
        }


        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            //if (Camera.main.fieldOfView <= 100)
            //    Camera.main.fieldOfView += 2;
            //if (Camera.main.orthographicSize <= 20)
            //    Camera.main.orthographicSize += 0.5F;
            transform.Translate(Vector3.forward * -smooth_speed);
        }

    }

}
