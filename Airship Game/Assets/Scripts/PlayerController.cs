using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public int speed;
	public float tilt;
	private Rigidbody rigidbody;
	
	void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
		rigidbody.velocity = movement * speed;
		
		rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	}
}
