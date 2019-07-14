using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 强制使用该脚本的游戏物体必须有Collider组件
[RequireComponent(typeof(Collider))]
public class VRComponent : Singleton<VRComponent> {

    // 在Inspector面板上隐藏
    // 交互需要等待的时间
    [HideInInspector]
    public float waitingTime = 1.5f;

    // 是否等待过1.5秒
    [HideInInspector]
    public bool isWaitted = false;
	public bool isOn = false;

    private void Start()
    {
        // 设置sleepTimeout为SleepTimeout.NeverSleep，防止屏幕休眠
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    /// <summary>
    /// 射线检测后响应的方法
    /// </summary>
    /// <param name="name">射线检测到的名字</param>
    /// <param name="trans">射线检测到的物体的Transform信息</param>
    public void ResponEvent(string name,Transform trans)
    {
        // 判断检测到的物体是什么
        switch (name)
        {
            case "OpenImage":
                {
                    Debug.Log("检测到的物体时OpenImage");
                    // 调用检测父物体的方法，参数为OpenImage的父物体名字
                    ResponentOpenParent(trans.parent.name);
                    break;
                }
            case "CloseImage":
                {
                    Debug.Log("检测到的物体时CloseImage");
                    // 调用检测父物体的方法，参数为CloseImage的父物体名字
                    ResponentCloseParent(trans.parent.name);
                    break;
                }
            case "BackImage":
                {
                    Debug.Log("检测到的物体时BackImage");
                    break;
                }
			case "Floor":
			{
				Debug.Log ("即将移动");
				break;
			}
			case "Livingroom":
			{
				//print ("liaoliao");
				CameraMoveNav.instance.Move
				(CameraMoveNav.instance.targetGameObjectPosition["客厅"]);
				break;
			}
			case "important":
			{
				//print ("liaoliao");
				CameraMoveNav.instance.Move
				(CameraMoveNav.instance.targetGameObjectPosition["关键点"]);
				break;
			}
			case "BathRoom":
			{
				//print ("liaoliao");
				CameraMoveNav.instance.Move
				(CameraMoveNav.instance.targetGameObjectPosition["浴室"]);
				break;
			}
			case "BedRoom":
			{
				//print ("liaoliao");
				CameraMoveNav.instance.Move
				(CameraMoveNav.instance.targetGameObjectPosition["主卧"]);
				break;
			}

            default:
                {
                    Debug.Log("什么都没检测到" + name);
                    break;
                }
        }
    }
    /// <summary>
    /// 检测OpenImage父物体名字是什么
    /// </summary>
    /// <param name="name">OpenImage父物体名字</param>
    void ResponentOpenParent(string name)
    {
        switch (name)
        {
            // 如果名字是CurtainImage
            case "CurtainImage":
                {
                    Debug.Log("检测到的物体时CurtainImage,点击的是开");
                    break;
                }
            // 如果名字是AirConditionImage
            case "AirConditionImage":
                {
                    Debug.Log("检测到的物体时AirConditionImage,点击的是开");
				    UdpServer.Instance.Fan = 2;
                    break;
                }
            // 如果名字是AlarmImage
            case "AlarmImage":
                {
                    Debug.Log("检测到的物体时AlarmImage,点击的是开");
                    break;
                }
            // 如果名字是LightImage
            case "LightImage":
                {
                    Debug.Log("检测到的物体时LightImage,点击的是开");
                    break;
                }
            default:
                {
                    Debug.Log("什么也没检测到" + name);
                    break;
                }
        }
    }
    /// <summary>
    /// 检测CloseImage父物体名字是什么
    /// </summary>
    /// <param name="name">CloseImage父物体名字</param>
    void ResponentCloseParent(string name)
    {
        switch (name)
        {
            // 如果名字是CurtainImage
            case "CurtainImage":
                {
                    Debug.Log("检测到的物体时CurtainImage,点击的是关");
                    break;
                }
            // 如果名字是AirConditionImage
            case "AirConditionImage":
                {
                    Debug.Log("检测到的物体时AirConditionImage,点击的是关");
				    UdpServer.Instance.Fan = 1;
                    break;
                }
            // 如果名字是AlarmImage
            case "AlarmImage":
                {
                    Debug.Log("检测到的物体时AlarmImage,点击的是关");
                    break;
                }
            // 如果名字是LightImage
            case "LightImage":
                {
                    Debug.Log("检测到的物体时LightImage,点击的是关");
                    break;
                }
            default:
                {
                    Debug.Log("什么也没检测到" + name);
                    break;
                }
        }
    }
}
