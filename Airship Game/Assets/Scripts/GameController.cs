using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
	public GameObject player;
	public GameObject hazard;
	public Transform boundary;
	public int hazardCount;
	public float startWait;
	public float spawnWait;
	public float waveWait;
	public Text scoreText;
	public Text restartText;
	public Text gameOverText;
	
	private bool restart;
	private bool gameOver;
	private int score;
	
	void Start()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore();
		StartCoroutine(SpawnWaves());
	}
	
	void Update()
	{
		if(player == null)
		{
			restart = true;
		}
		
		if(restart)
		{
			if(Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
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
			
			if(gameOver)
			{
				restartText.text = "Press 'R' to restart";
				restart = true;
				break;
			}
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
	
	public void GameOver()
	{
		gameOverText.text = "Game Over";
		gameOver = true;
	}
}
