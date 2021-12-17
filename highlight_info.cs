using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highlight_info : MonoBehaviour
{
    //�����ر���ʾ��Ϣ
    bool isShowInfo;
    //��Ϣ��ʽ
    public GUIStyle _GUIStyle;
    //ƫ�ƾ���
    public float Offset = 15;
    //��������
    public string Info = "����";
    void Start()
    {
        //Ĭ�ϲ���ʾ
        isShowInfo = false;
        //�����С
        _GUIStyle.fontSize = 40;
        //������ɫ
        _GUIStyle.normal.textColor = Color.white;
    }
    // Update is called once per frame
    void Update()
    {
        //���߷���
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            //�õ�����Ͷ�䵽������gameObj
            GameObject gameObj = hitInfo.collider.gameObject;
            //��ʾ������Ϣ
            isShowInfo = true;
            //��ȡ����
            Info = gameObj.name;
        }
        else
        {
            //����ʾ
            isShowInfo = false;
        }
    }
    void OnGUI()
    {
        if (isShowInfo)
        {   //��ǩ λ�ô�С����Ϣ����ʽ  
            GUI.Label(new Rect(Input.mousePosition.x + Offset, Screen.height - Input.mousePosition.y, 100, 100), Info, _GUIStyle);
        }
    }
}

