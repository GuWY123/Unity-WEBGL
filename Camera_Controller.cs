using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform target; // ��ȡ�����Χ�Ƶ�����
    public float smooth_speed = 10f;  //
    public float rot_speed_x = 4f;     //
    public float rot_speed_y = 2f;     //
    public float move_speed = 4000f;    //�ƶ��ٶ�
    float X = 0;
    float Y = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //target = GameObject.Find("GameObject").GetComponent<Transform>();  //�����Ǹ�ģ�ʹ�����һ����������Ϊ����
        camerazoom();
        Cam_Move();
        rotate();

    }
    void Cam_Move()
    {
        float X = -Input.GetAxis("Mouse X") * Time.deltaTime * move_speed; 
        float Y = -Input.GetAxis("Mouse Y") * Time.deltaTime * move_speed;

        if (Input.GetMouseButton(0))
        {  //������
           //Debug.Log("move");
            if (Mathf.Abs(X) > Mathf.Abs(Y)) //��֤�ӽǲ���̫��
            { 
                transform.Translate(Vector3.right * X, Space.Self);  //����ƽ��
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

        if (Input.GetMouseButton(1)) //����Ҽ�
        {

            X = Input.GetAxis("Mouse X") * rot_speed_x * 0.02f;
            Y = Input.GetAxis("Mouse Y") * rot_speed_y * 0.02f;

            if (Mathf.Abs(X) > Mathf.Abs(Y) ) //��֤�ӽǲ���̫��
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
   
    private void camerazoom() //�������������
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
