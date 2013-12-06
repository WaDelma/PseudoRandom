using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
	
	private int currentWaveNumber = 1;
	private bool wavePause = true;
	private float lastWaveEndTime;
	private float lastEnemySpawnTime;
	private GameObject enemyParent;
	
	public Vector3[] spawnPoints;
	public float spawnRate = 4f;
 	public float timeToBuild = 30f;
	public int startingDifficulty = 1;
	public int difficultyIncrement = 1;
	public Stack<GameObject> currentWave;
	
	//enemies
	public GameObject cow;
	
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
	}
	
	private void UpdateWave() {
		if(Time.time - lastEnemySpawnTime > spawnRate) {
			GameObject nextEnemy = currentWave.Pop();
			if(nextEnemy == null) return;
			SpawnEnemies(nextEnemy);
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
	}
	
	public int EnemiesAlive() {
		return enemyParent.transform.childCount;
	}
	
	private void GenerateRandomWave(int difficulty) {
		currentWave = new Stack<GameObject>();
		
	}
}
