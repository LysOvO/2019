using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRResponse : MonoBehaviour {

    // 当射线检测到物体时，发生变化的图片
    public Image waitingImage;
    // 射线是否检测过
    private bool isHovered = false;
    // 射线检测到的物体的信息 
    private RaycastHit hitInfo;
    // 射线检测到的物体的名字
    private string hitInfoName;
    // 射线检测到的物体的Transform信息
    private Transform hitInfoTrans;
    // 射线检测到物体后所等待的时间
    private float enterTime;
    // 选择中的物体
    private VRComponent selectComponent;

    private void Start()
    {
        // 让该图片填充为0
        waitingImage.fillAmount = 0;
    }

    private void Update()
    {
        // 实时调用射线检测
        CastRay();

        // 如果被检测过，直接返回
        if (isHovered)
        {
            return;
        }
        // 如果没有被检测过，首先让Image中的外圈图片隐藏
        waitingImage.gameObject.SetActive(false);
        // 当检测到的物体不为空的时候
        if (selectComponent!=null)
        {
            // 记录射线检测到物体等待的时间
            float selectTime = Time.time - enterTime;
            if (selectTime <= selectComponent.waitingTime)
            {
                // 先将外圈图片显示出来
                waitingImage.gameObject.SetActive(true);
                // 让图片缓慢填充
                waitingImage.fillAmount = selectTime / selectComponent.waitingTime;
            }
            else// 当填充完毕
            {
                // 首先将物体设置为检测过
                isHovered = true;
                // 开始执行所选中物体对应得方法
				VRComponent.Instance.isOn = true;
				print (VRComponent.Instance.isOn);
                selectComponent.ResponEvent(hitInfoName,hitInfoTrans);
				//任何部分调用socket部分的代码45151514
				//UdpClient.Instance.

            }
        }
    }

    // 射线检测的方法
    void CastRay()
    {
        // 射线目前检测到的物体为空
        VRComponent currentComponent = null;

        // 定义射线发射的方向为向前，Z轴为前方
        Vector3 rayDirection = transform.forward;

        // 如果碰到物体，返回碰撞信息并且Physics.Raycast为true
        // 第一个参数为该脚本所在物体的点，发射一条向前的射线
        // float.MaxValue表示射线无穷远
        // out hitInfo表示将射线所检测到的物体的信息返回
        if (Physics.Raycast(transform.position,rayDirection,out hitInfo,float.MaxValue))
        {
            // 让currentComponent为射线检测到的物体
            currentComponent = hitInfo.collider.GetComponent<VRComponent>();
            // 返回射线检测到的物体和Transform信息
            hitInfoName = hitInfo.collider.name;
            hitInfoTrans = hitInfo.collider.transform;
        }

        // 如果选择的物体不是当前检测到的物体
        if (currentComponent != selectComponent)
        {
            // 说明没有被检测过
            isHovered = false;
            selectComponent = currentComponent;
            // 记录当前时间
            enterTime = Time.time;
        }
    }
}
