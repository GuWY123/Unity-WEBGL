using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highlight_info : MonoBehaviour
{
    //开启关闭显示信息
    bool isShowInfo;
    //信息样式
    public GUIStyle _GUIStyle;
    //偏移距离
    public float Offset = 15;
    //物体名称
    public string Info = "名字";
    void Start()
    {
        //默认不显示
        isShowInfo = false;
        //字体大小
        _GUIStyle.fontSize = 40;
        //字体颜色
        _GUIStyle.normal.textColor = Color.white;
    }
    // Update is called once per frame
    void Update()
    {
        //射线方法
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            //得到射线投射到的物体gameObj
            GameObject gameObj = hitInfo.collider.gameObject;
            //显示物体信息
            isShowInfo = true;
            //获取名称
            Info = gameObj.name;
        }
        else
        {
            //不显示
            isShowInfo = false;
        }
    }
    void OnGUI()
    {
        if (isShowInfo)
        {   //标签 位置大小，信息，样式  
            GUI.Label(new Rect(Input.mousePosition.x + Offset, Screen.height - Input.mousePosition.y, 100, 100), Info, _GUIStyle);
        }
    }
}

