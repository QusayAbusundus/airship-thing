using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	public GameObject hazard;
	public Transform boundary;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	
	void Start()
	{
		StartCoroutine(spawnWaves());
	}
	
	IEnumerator spawnWaves()
	{
		yield return new WaitForSeconds(startWait);
		for(int i = 0; i < hazardCount; i++)
		{
			Vector3 spawnPosition = new Vector3
			(
				Random.Range(-(boundary.localScale.x/2), (boundary.localScale.x/2)),
				Random.Range(-(boundary.localScale.y/2), (boundary.localScale.y/2)), 
				boundary.localScale.z
			);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate(hazard, spawnPosition, spawnRotation);
			yield return new WaitForSeconds(spawnWait);
		}
	}
}
