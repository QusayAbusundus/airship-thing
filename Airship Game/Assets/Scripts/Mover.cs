using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour 
{
	public float speed;
	private Rigidbody RB;
	
	void Start()
	{
		RB = GetComponent<Rigidbody>();
		
		RB.velocity = transform.forward * speed;
	}
}
