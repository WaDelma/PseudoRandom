using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Collections;

public class WorldGenerator : Generator{
	private static int unitsInFab = 4;
	
	public Vector2 roadSpacing = new Vector2(10, 10);
	public Vector2 dimensions = new Vector2(10, 10);
	public Vector3 position = new Vector3();
	
	public GameObject road;
	public GameObject roadTurn;
	public GameObject roadFork;
	public GameObject roadCross;
	
	public override void Generate() {
		float maxX = dimensions.x * roadSpacing.x;
		float maxZ = dimensions.y * roadSpacing.y;
		for(int x = 0; x <= maxX; x++){
			for(int z = 0; z <= maxZ; z++){
				Vector3 pos = position + new Vector3(x * unitsInFab, 0, z * unitsInFab);
				pos.Scale(new Vector3(units.x, units.y, units.x));
				
				if(x % maxX == 0 && z % maxZ == 0){
					Quaternion turn;
					if(x == 0){
						if(z == 0){
							turn = Quaternion.Euler(0, 180, 0);
						}else{
							turn = Quaternion.Euler(0, -90, 0);
						}
					}else{
						if(z == 0){
							turn = Quaternion.Euler(0, 90, 0);
						}else{
							turn = Quaternion.identity;
						}
					}
					Create(roadTurn, pos, turn);
					continue;
				}
				
				
				if(x % maxX == 0){
					if(z % roadSpacing.y == 0){
						Quaternion turn = Quaternion.identity;
						if(x != 0){
							turn *= Quaternion.Euler(0, 180, 0);
						}
						Create(roadFork, pos, turn);
						continue;
					}
				}
				if(z % maxZ == 0){
					if(x % roadSpacing.x == 0){
						Quaternion turn = Quaternion.Euler(0, -90, 0);
						if(z != 0){
							turn *= Quaternion.Euler(0, 180, 0);
						}
						Create(roadFork, pos, turn);
						continue;
					}
				}
				
				
				if(x % roadSpacing.x == 0){
					if(z % roadSpacing.y == 0){
						Create(roadCross, pos, Quaternion.identity);
						continue;
					}
					Create(road, pos, Quaternion.identity);
					continue;
				}
				if(z % roadSpacing.y == 0){
					Create(road, pos, Quaternion.Euler(0, 90, 0));
					continue;
				}
			}
		}
	}
}
