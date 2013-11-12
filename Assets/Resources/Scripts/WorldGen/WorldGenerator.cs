using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Collections;

public class WorldGenerator : Generator{
	private static int unitsInFab = 4;
	public HouseTile[] houses;
	
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
				Vector3 pos = position + new Vector3(x, 0, z) * unitsInFab;
				Vector3 scaledPos = new Vector3(pos.x * units.x, pos.y * units.y, pos.z * units.z);
				
				if(x % maxX == 0 && z % maxZ == 0){
					Quaternion turn;
					if(x == 0){
						if(z == 0){
							turn = Quaternion.Euler(0, 180, 0);
							CreateHousingBlock (scaledPos);
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
					Create(roadTurn, scaledPos, turn);
					continue;
				}
				
				
				if(x % maxX == 0){
					if(z % roadSpacing.y == 0){
						Quaternion turn = Quaternion.identity;
						if(x == 0){
							CreateHousingBlock (scaledPos);
						}else{
							turn *= Quaternion.Euler(0, 180, 0);
						}
						Create(roadFork, scaledPos, turn);
						continue;
					}
				}
				if(z % maxZ == 0){
					if(x % roadSpacing.x == 0){
						Quaternion turn = Quaternion.Euler(0, -90, 0);
						if(z == 0){
							CreateHousingBlock (scaledPos);
						}else{
							turn *= Quaternion.Euler(0, 180, 0);
						}
						Create(roadFork, scaledPos, turn);
						continue;
					}
				}
				
				
				if(x % roadSpacing.x == 0){
					if(z % roadSpacing.y == 0){
						CreateHousingBlock (scaledPos);
						Create(roadCross, scaledPos, Quaternion.identity);
						continue;
					}
					Create(road, scaledPos, Quaternion.identity);
					continue;
				}
				if(z % roadSpacing.y == 0){
					Create(road, scaledPos, Quaternion.Euler(0, 90, 0));
					continue;
				}
			}
		}
	}
	
	void CreateHousingBlock (Vector3 scaledPos)
	{
		HousingBlockGenerator generator = Create<HousingBlockGenerator>(scaledPos);
		generator.position = scaledPos + new Vector3(units.x, 0, units.z) * unitsInFab * 0.625f;//pos + new Vector3(unitsInFab * 0.5f + 0.125f, 0, unitsInFab * 0.5f + 0.125f);
		generator.dimensions = roadSpacing;
		generator.dimensions.x -= 1;
		generator.dimensions.y -= 1;
		generator.dimensions *= unitsInFab;
		generator.houses = houses;
		generator.Generate();
	}
}
