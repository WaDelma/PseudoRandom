using UnityEngine;
using System.Collections;
using System;

public class HouseGenerator : Generator
{
	public enum Direction
	{
		NORTH = 0,
		EAST = 1,
		SOUTH = 2,
		WEST = 3
	};
	
	private int unitsInHeight = 2;
	public Direction direction = Direction.NORTH;
	public int windowOffset = 0;
	public int windowSpacing = 1;
	public Vector3 dimensions = new Vector3 (5, 15, 5);
	public Vector3 position = new Vector3 ();
	public float scale = 0.9f;
	public GameObject door;
	public GameObject wall;
	public GameObject window;
	public GameObject corner;
	
	public override void Generate ()
	{
		float dimX = dimensions.x - 1;
		float dimZ = dimensions.z - 1;
		for (int y = 0; y < dimensions.y; y++) {
			foreach (Direction dir in Enum.GetValues(typeof(Direction))) {
				Vector3 pos = new Vector3 (position.x, position.y, position.z) * (1 + (1 - scale) / 2.0f);
				pos.Scale (new Vector3 (units.x, units.y, units.x));
				Quaternion rot = Quaternion.identity;
				switch (dir) {
				case Direction.NORTH:
					pos += new Vector3 (0, 0, 0) * units.x * scale;
					rot = Quaternion.Euler (0, -90, 0);
					break;
				case Direction.EAST:
					pos += new Vector3 (dimX, 0, 0) * units.x * scale;
					rot = Quaternion.Euler (0, 180, 0);
					break;
				case Direction.SOUTH:
					pos += new Vector3 (dimX, 0, dimZ) * units.x * scale;
					rot = Quaternion.Euler (0, 90, 0);
					break;
				case Direction.WEST:
					pos += new Vector3 (0, 0, dimZ) * units.x * scale;
					break;
				}
				
				pos += new Vector3 (0, y * unitsInHeight, 0) * units.y * scale;
			
				int d = (int)dir;
				int times = (int)(d % 2 == 0 ? dimX : dimZ);
				Vector3 amount = new Vector3 ((d + 1) % 2, 0, d % 2) * (d < 2 ? 1 : -1) * units.x * scale;
			
				for (int n = 0; n < times; n++) {
					if (n == 0) {
						Scale (Create (corner, pos, rot), scale);
					} else if (y == 0 && n == times / 2 && dir == direction) {
						Scale (Create (door, pos, Quaternion.Euler (0, 90, 0) * rot), scale);
					} else if (y != 0 && (n + windowOffset) % windowSpacing == 0) {
						Scale (Create (window, pos, Quaternion.Euler (0, 90, 0) * rot), scale);
					} else {
						Scale (Create (wall, pos, Quaternion.Euler (0, 90, 0) * rot), scale);
					}
					pos += amount;
				}
			}
		}

	}
	
	public GameObject Scale (GameObject obj, float scale)
	{
		obj.transform.localScale = new Vector3 (scale, scale, scale);
		return obj;
	}
}
