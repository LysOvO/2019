using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterValue : MonoBehaviour {
	#region 定义的字段属性
	/// <summary>
	/// 显示湿度的文本组件
	/// </summary>
	private Text text;

	/// <summary>
	/// 定义一个计时器
	/// </summary>
	float timer = 0f;

	/// <summary>
	/// 无连接的时候显示的内容
	/// </summary>
	#endregion

	#region Unity回调方法
	private void Start()
	{
		// 初始化文本组件
		text = this.GetComponent<Text>();
	}

	private void Update()
	{
		timer += Time.deltaTime;
		SetValues ();
	}
	#endregion

	#region 方法
	/// <summary>
	/// 无连接，显示虚拟数据的方法
	/// </summary>
	void SetValues()
	{
		//print (UdpServer.Instance.WaterValue);
		text.text = UdpServer.Instance.WaterValue.ToString();
	}
	#endregion
}
