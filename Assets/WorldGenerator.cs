using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Collections;

public class WorldGenerator : MonoBehaviour {
	
	public const float unit = 1.6f;
	public const int unitsInFab = 4;
	
	public Vector2 roadSpacing = new Vector2(10, 10);
	public Vector2 dimensions = new Vector2(10, 10);
	public Vector3 position = new Vector3();
	public Dictionary<string, GameObject> fabit;
	
	public void Init() {
		fabit = new Dictionary<string, GameObject>();
	}
	
	public void load(string name){
		fabit[name] = (GameObject) Resources.Load(name);
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Generoi() {//TODO: Create prefabs and test if this is right...
		Debug.Log("toimii!!!");
		for(int x = 0; x < dimensions.x * roadSpacing.x * unitsInFab; x++){
			for(int y = 0; y < dimensions.y * roadSpacing.y * unitsInFab; y++){
				Vector3 pos = position + new Vector3(x * unitsInFab * unit, 0, y * unitsInFab * unit);
				//Can be changed: 
				//Turn prefab is assumed to be from up to right.
				//Fork prefab is assumed to be from up to left and right.
				if(x == 0){
					if(y == 0){
						Instantiate(fabit["roadTurn"], pos, Quaternion.Euler(0, 0, 0)); //From up to right
						continue;
					}
					if(y == dimensions.y - 1){
						Instantiate(fabit["roadTurn"], pos, Quaternion.Euler(-90, 0, 0)); //From up to left
						continue;
					}
					if(y % roadSpacing.y == 0){
						Instantiate(fabit["roadFork"], pos, Quaternion.identity); //From up to left and right
						continue;
					}
				}else if(x == dimensions.x - 1){
					if(y == 0){
						Instantiate(fabit["roadTurn"], pos, Quaternion.Euler(90, 0, 0)); //From down to right
						continue;
					}
					if(y == dimensions.y - 1){
						Instantiate(fabit["roadTurn"], pos, Quaternion.Euler(180, 0, 0)); //From down to left
						continue;
					}
					if(y % roadSpacing.y == 0){
						Instantiate(fabit["roadFork"], pos, Quaternion.Euler(180, 0, 0)); //From down to left and right
						continue;
					}
				}else if(y == 0){
					if(x % roadSpacing.x == 0){
						Instantiate(fabit["roadFork"], pos, Quaternion.Euler(-90, 0, 0)); //From right to up and down
						continue;
					}
				}else if(y == dimensions.y - 1){
					if(x % roadSpacing.x == 0){
						Instantiate(fabit["roadFork"], pos, Quaternion.Euler(90, 0, 0)); //From left to up and down
						continue;
					}
				}
				if(x % roadSpacing.x == 0){
					if(y % roadSpacing.y == 0){
						Instantiate(fabit["roadCross"], pos, Quaternion.identity); //From all directions to all directions
						continue;
					}
					Instantiate(fabit["roadHor"], pos, Quaternion.identity); //From left to right
					continue;
				}
				if(y % roadSpacing.y == 0){
					Instantiate(fabit["roadVer"], pos, Quaternion.identity); //From up to down
					continue;
				}
			}
		}
	}
}
