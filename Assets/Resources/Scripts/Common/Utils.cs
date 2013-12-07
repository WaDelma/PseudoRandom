﻿using UnityEngine;
using System.Collections;

public static class Utils {

	public static Vector3 RotateX(Vector3 vector, float angle ) {
		float sin = Mathf.Sin( angle );
		float cos = Mathf.Cos( angle );
		return new Vector3(vector.x, (cos * vector.y) - (sin * vector.z), (cos * vector.z) + (sin * vector.y));
	}

	public static Vector3 RotateY(Vector3 vector, float angle ) {
		float sin = Mathf.Sin( angle );
		float cos = Mathf.Cos( angle );
		return new Vector3((cos * vector.x) + (sin * vector.z), vector.y, (cos * vector.z) - (sin * vector.x));
	}

	public static Vector3 RotateZ(Vector3 vector, float angle ) {
		float sin = Mathf.Sin( angle );
		float cos = Mathf.Cos( angle );
		return new Vector3((cos * vector.x) - (sin * vector.y), (cos * vector.y) + (sin * vector.x), vector.z);
	}
	
	public static Vector3 Snap(Vector3 vector, float unit) {
		vector.x = Mathf.Floor(vector.x / unit) * unit;
		vector.y = Mathf.Floor(vector.y / unit) * unit;
		vector.z = Mathf.Floor(vector.z / unit) * unit;
		return vector;
	}
}