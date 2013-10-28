using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Collections;

public class WorldGenerator : MonoBehaviour {
	public float unit = 1.6f;
	public int unitsInFab = 4;
	
	public Vector2 roadSpacing = new Vector2(10, 10);
	public Vector2 dimensions = new Vector2(10, 10);
	public Vector3 position = new Vector3();
	
	public GameObject road;
	public GameObject roadTurn;
	public GameObject roadFork;
	public GameObject roadCross;
	
	public void Init() {
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Delete(){
		while(transform.childCount > 0){
			DestroyImmediate(transform.GetChild(0).gameObject);
		}
	}
	
	public void Create(GameObject obj, Vector3 pos, Quaternion nion){
		((GameObject)Instantiate(obj, pos, nion)).transform.parent = this.transform;
	}
	
	public void Generoi() {
		Init();
		float maxX = dimensions.x * roadSpacing.x;
		float maxY = dimensions.y * roadSpacing.y;
		for(int x = 0; x <= maxX; x++){
			for(int y = 0; y <= maxY; y++){
				Vector3 pos = position + new Vector3(x * unitsInFab * unit, 0, y * unitsInFab * unit);
				
				if(x % maxX == 0 && y % maxY == 0){
					Quaternion turn;
					if(x == 0){
						if(y == 0){
							turn = Quaternion.Euler(0, 180, 0);
						}else{
							turn = Quaternion.Euler(0, -90, 0);
						}
					}else{
						if(y == 0){
							turn = Quaternion.Euler(0, 90, 0);
						}else{
							turn = Quaternion.identity;
						}
					}
					Create(roadTurn, pos, turn);
					continue;
				}
				
				
				if(x % maxX == 0){
					if(y % roadSpacing.y == 0){
						Quaternion turn = Quaternion.identity;
						if(x != 0){
							turn *= Quaternion.Euler(0, 180, 0);
						}
						Create(roadFork, pos, turn);
						continue;
					}
				}
				if(y % maxY == 0){
					if(x % roadSpacing.x == 0){
						Quaternion turn = Quaternion.Euler(0, -90, 0);
						if(y != 0){
							turn *= Quaternion.Euler(0, 180, 0);
						}
						Create(roadFork, pos, turn);
						continue;
					}
				}
				
				
				if(x % roadSpacing.x == 0){
					if(y % roadSpacing.y == 0){
						Create(roadCross, pos, Quaternion.identity);
						continue;
					}
					Create(road, pos, Quaternion.identity);
					continue;
				}
				if(y % roadSpacing.y == 0){
					Create(road, pos, Quaternion.Euler(0, 90, 0));
					continue;
				}
			}
		}
	}
}
