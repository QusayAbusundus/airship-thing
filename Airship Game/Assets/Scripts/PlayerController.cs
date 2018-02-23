using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour 
{
	public int speed;
	public float tilt;	
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	
	public Boundary boundary;
	
	private Rigidbody rigidbody;
	private float nextFire;
	
	void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
	}
	
	void Update()
	{
		if(Input.GetButton("Fire1") & Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}
	
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
		rigidbody.velocity = movement * speed;
		
		/*rigidbody.position = new Vector3
		(
			Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp(rigidbody.position.y, boundary.yMin, boundary.yMax),
			0.0f
		);*/
		
		rigidbody.rotation = Quaternion.Euler(rigidbody.velocity.y * -tilt, 0.0f, rigidbody.velocity.x * -tilt);
	}
}
