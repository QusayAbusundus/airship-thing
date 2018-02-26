using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	public GameObject hazard;
	public Transform boundary;
	
	void Start()
	{
		spawnWaves();
	}
	
	void spawnWaves()
	{
		Vector3 spawnPosition = new Vector3
		(
			Random.Range(-(boundary.localScale.x/2), (boundary.localScale.x/2)),
			Random.Range(-(boundary.localScale.y/2), (boundary.localScale.y/2)), 
			boundary.localScale.z
		);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate(hazard, spawnPosition, spawnRotation);
	}
}
