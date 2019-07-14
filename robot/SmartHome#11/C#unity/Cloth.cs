using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloth : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (UdpServer.Instance.Fan == 2) {
			transform.Rotate (0, 0, 20);
		} else {
			//targetRotation = Quaternion.Euler (0f, 0f, 0f);
			transform.rotation = Quaternion.Euler(0f,0f,0f);
		}
	}
}
