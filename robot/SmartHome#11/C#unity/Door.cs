using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public Transform _Start;
	public Transform _End;

	private Transform target;

	public float speed = 2.0f;
	private Vector3 v;

	public bool isOpen = false;
	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {

		if (isOpen)
			target = _End;
		else
			target = _Start;

		if (Vector3.Distance(target.position, transform.position) > 0.05f)
		{
			v = (target.position - transform.position).normalized * speed;
			transform.Translate(v * Time.deltaTime);
		}
	}
}