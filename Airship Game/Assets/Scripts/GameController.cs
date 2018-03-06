using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
	public GameObject hazard;
	public Transform boundary;
	public int hazardCount;
	public float startWait;
	public float spawnWait;
	public float waveWait;
	public Text scoreText;
	public int score;
	
	void Start()
	{
		score = 0;
		UpdateScore();
		StartCoroutine(SpawnWaves());
	}
	
	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWait);
		while(true)
		{
			for(int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3
				(
					boundary.position.x	+ Random.Range(-(boundary.localScale.x/2), (boundary.localScale.x/2)),
					boundary.position.y + Random.Range(-(boundary.localScale.y/2), (boundary.localScale.y/2)), 
					boundary.localScale.z
				);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
		}
	}
	
	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore();
	}	
	
	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}
}
