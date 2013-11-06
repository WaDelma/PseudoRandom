using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HousingBlockGenerator : Generator {
	public HouseTile[] houses;
	
	public Vector2 dimensions = new Vector2(15, 15);
	public Vector3 position = new Vector3();
	
	public Vector3 minHouseDimensions = new Vector3(3, 5, 3);
	public Vector3 maxHouseDimensions = new Vector3(9, 15, 9);
	
	public int minHorizontalDifference = 1;
	public int maxHorizontalDifference = 2;
	
	public int minVerticalDifference = 2;
	public int maxVerticalDifference = 5;
	
	public int horizontalDifferenceBetweenHouses = 3;
	
	public override void Generate ()
	{
		if(houses == null || houses.Length == 0) return;
		int amountOfHouses = 4;
		float dimX = dimensions.x / amountOfHouses;
		float dimZ = dimensions.y / amountOfHouses;
		for(int x = 0; x < amountOfHouses; x++){
			for(int z = 0; z < amountOfHouses; z++){
				Vector3 pos = position;
				pos.x += x * dimX * units.x;
				pos.z += z * dimZ * units.z;
				HouseGenerator generator = Create<HouseGenerator>(pos);//new Vector3(pos.x * units.x, pos.y * units.y, pos.z * units.z));
				generator.position = pos;
				generator.scale = 1;
				generator.dimensions.x = dimX;
				generator.dimensions.y = Random.Range(minHouseDimensions.y, maxHouseDimensions.y);
				generator.dimensions.z = dimZ;
				generator.houseTiles = houses[Random.Range(0, houses.Length)];
				generator.Generate();
			}
		}
	}
}
