using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGo : MonoBehaviour {

	// 声明鼠标水平偏移量
	float hor;
	// 声明鼠标竖直偏移量
	float ver;
	// 声明移动水平偏移量
	float w;
	// 声明移动竖直偏移量
	float a;
	// 旋转速度
	public float roSpeed = 30f;
	// 移动速度
	public float speed = 5f;
	void Update()
	{
		// 初始化水平偏移量
		hor = Input.GetAxis("Mouse X");
		// 初始化竖直偏移量
		ver = Input.GetAxis("Mouse Y");
		// 初始化水平偏移量
		w = Input.GetAxis("Horizontal");
		// 初始化竖直偏移量
		a = Input.GetAxis("Vertical");
		// 得到此时偏移量方向
		Vector3 V = new Vector3(0,0,a);
		// 如果水平或者方向移动了
		if (w !=0 || a !=0)
		{
			// 让物体跟着移动
			transform.Translate( V * Time.deltaTime * speed);
		}
	}
}
