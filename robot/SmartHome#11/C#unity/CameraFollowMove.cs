using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowMove : MonoBehaviour
{

    #region 定义的字段属性变量

    // 定义需要跟随的目标位置
    public Transform target;

    #endregion

    #region Unity回调方法

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.time);
    } 

    #endregion
}
