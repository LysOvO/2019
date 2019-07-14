using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingMove: MonoSingleton<LivingMove>
{
	#region 定义的变量
	/// <summary>
	/// 定义动画组件
	/// </summary>
	private Animator anim;
	#endregion

	#region Unity回调方法
	/// <summary>
	/// 重写父类的单例方法
	/// </summary>
	protected override void Awake()
	{
		base.Awake();
	}

	/// <summary>
	/// 初始化动画组件
	/// </summary>
	private void Start()
	{
		anim = this.GetComponent<Animator>();
	}
	#endregion

	#region 方法

	void MoveBack()
	{
		// 移动到客厅
		CameraMoveNav.instance.Move
		(CameraMoveNav.instance.targetGameObjectPosition["浴室"]);
	}

	/// <summary>
	/// 摄像机移动的方法
	/// </summary>
	void MoveIn()
	{
		// 先将之前的路径清除
		CameraMoveNav.instance.Clean();
		// 摄像机移动
		CameraMoveNav.instance.Move
		(CameraMoveNav.instance.targetGameObjectPosition["客厅"]);
	}

	/// <summary>
	/// 播放关门的动画
	/// </summary>
	void CloseDoor()
	{
		anim.SetBool("Open", false);
	}
	#endregion
}
