using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/**
 * generates and sends new waves
 */
public class WaveController : MonoBehaviour {
	
	public Vector3[] spawnPoints;
	public float spawnRate = 4f;
 	public float timeToBuild = 30f;
	public int startingDifficulty = 1;
	public int difficultyIncrement = 1;
	
	//enemies
	public GameObject cow;
	public GameObject boatCow;
	
	private int currentWaveNumber = 1;
	private bool wavePause = true;
	private float lastWaveEndTime;
	private float lastEnemySpawnTime;
	private GameObject enemyParent;
	private Stack<GameObject> currentWave;
	private int enemiesInCurrentWave;
	
	// Use this for initialization
	void Start () {
		lastWaveEndTime = Time.time;
		enemyParent = new GameObject();
	}
	
	// Update is called once per frame
	void Update () {
		if(!wavePause) {
			UpdateWave();
		}
		else if(Time.time - lastWaveEndTime > timeToBuild) {
			StartWave();
		}
	}
	
	private void StartWave() {
		wavePause = false;
		GenerateRandomWave(currentWaveNumber * difficultyIncrement + startingDifficulty);
		SendMessage("OnWaveStart");
	}
	
	private void UpdateWave() {
		//time to spawn a new enemy
		if(Time.time - lastEnemySpawnTime > spawnRate && currentWave.Count > 0) {
			GameObject nextEnemy = currentWave.Pop();
			if(nextEnemy == null) return;
			SpawnEnemies(nextEnemy);
			lastEnemySpawnTime = Time.time;
		}
		if(EnemiesAlive() == 0) EndWave();
	}
	
	private void SpawnEnemies(GameObject enemy) {
		//spawns an enemy to every spawn point
		foreach(Vector3 point in spawnPoints) {
			GameObject newEnemy = (GameObject) Instantiate(enemy, point, Quaternion.identity);
			newEnemy.transform.parent = enemyParent.transform;
		}
	}
	
	private void EndWave() {
		lastWaveEndTime = Time.time;
		currentWaveNumber++;
		SendMessage("OnWaveEnd");
	}
	
	private int EnemiesAlive() {
		return enemyParent.transform.childCount;
	}
	
	private void GenerateRandomWave(int difficulty) {
		currentWave = new Stack<GameObject>();
		//normal cows
		for(int i = 0; i < currentWaveNumber * 5; i++) {
			currentWave.Push(cow);
		}
		//boat cow
		for(int i = 0; i < currentWaveNumber * 2; i++) {
			currentWave.Push(boatCow);
		}
		enemiesInCurrentWave = currentWave.Count;
	}
	
	public int TimeToNextWave() {
		if(wavePause) {
			return (int) (timeToBuild - (Time.time - lastWaveEndTime));
		}
		else return 0;
	}
	
	public int EnemiesInWave() {
		return enemiesInCurrentWave * spawnPoints.Length;
	}
	
	public int EnemiesKilled() {
		return EnemiesInWave() - ((currentWave.Count * spawnPoints.Length) + EnemiesAlive());
	}
}
