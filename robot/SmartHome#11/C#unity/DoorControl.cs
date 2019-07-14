using UnityEngine;
using System.Collections;

public class DoorControl : MonoBehaviour {

	public Door right;
	public Door left;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			right.isOpen = true;
			left.isOpen = true;
			LightControl.Instance.m_onAlarm = true;
			print (LightControl.Instance.m_onAlarm);
		}

	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			right.isOpen = false;
			left.isOpen = false;
		}
	}
}