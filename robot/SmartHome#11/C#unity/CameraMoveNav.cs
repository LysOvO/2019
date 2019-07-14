using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 摄像机移动的方法
/// </summary>
public class CameraMoveNav : MonoSingleton<CameraMoveNav> {
    #region 定义的字段属性
    /// <summary>
    /// 定义导航组件
    /// </summary>
    private NavMeshAgent m_Nav;

    /// <summary>
    /// 用字典储存摄像机要去的点
    /// </summary>
    public Dictionary<string, Vector3> targetGameObjectPosition = new Dictionary<string, Vector3>();

    /// <summary>
    /// 定义跟随的物体
    /// </summary>
    public Transform[] targetPosition;
    #endregion

    #region Unity回调方法
    /// <summary>
    /// 重写继承父类的单例初始化方法
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
        // 初始化导航组件
        m_Nav = this.GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        targetGameObjectPosition.Add("浴室", targetPosition[0].position);
        // 添加去浴室的位置
        targetGameObjectPosition.Add("主卧", targetPosition[1].position);
        // 添加去主卧的位置
        targetGameObjectPosition.Add("关键点", targetPosition[2].position);
        // 添加去关键点的位置
        targetGameObjectPosition.Add("客厅", targetPosition[3].position);
		// 添加去客厅的位置
    }
    #endregion

    #region 方法
    /// <summary>
    /// 设置导航终点的位置
    /// </summary>
    /// <param name="pos">导航的终点位置</param>
    public void Move(Vector3 pos)
    {
        // 设置导航的目标点为pos
        m_Nav.SetDestination(pos);
    }

    /// <summary>
    /// 清除导航原有的路径，清除目标点
    /// </summary>
    public void Clean()
    {
        m_Nav.ResetPath();
    }

    /// <summary>
    /// 移动到客厅的方法
    /// </summary>
    public void MoveLiving()
    {
        m_Nav.destination = targetGameObjectPosition["客厅"];

    }
    #endregion
}
