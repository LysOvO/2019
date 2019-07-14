using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest : MonoBehaviour {

    // 定义一条射线
    private Ray ray;
    // 定义射线信息
    private RaycastHit hitInfo;

    private void Update()
    {
        // 如果一直点击鼠标左键
        if (Input.GetMouseButton(0))
        {
            // 返回一条射线从摄像机通过鼠标点击的屏幕点
            // Input.mousePosition为鼠标点击的位置
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // 使用Physics类方法Raycast方法实现涉嫌碰撞检测功能
            // 第一个参数为要发射的射线
            // 第二个参数为返回的碰撞信息
            if (Physics.Raycast(ray,out hitInfo))
            {
                // 在scene中画一条红线
                Debug.DrawLine(ray.origin,hitInfo.point,Color.red);
                // 打印出射线检测到的名字
                Debug.Log("射线检测到的名字是：" + hitInfo.collider.name);
            }
        }
    }
}
