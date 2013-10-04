using UnityEngine;
using System.Collections;

public class WorldGen : MonoBehaviour
{
	Terrain terrain;
	
	// Use this for initialization
	void Start ()
	{
		terrain = this.GetComponent<Terrain>();
		int res = 513;
		TerrainData tData = terrain.terrainData;
		tData.heightmapResolution = res;
		
		float[,] heights = new float[res, res];
		for (int i = 0; i < res * res; i++)
			heights [i % res, i / res] = Random.Range(.49F, .51F);
		tData.SetHeights (0, 0, heights);
 
		float[,] flat = new float[50, 50];
		for (int i = 0; i < 50 * 50; i++)
			flat [i % 50, i / 50] = .5F;
		for (int i = 0; i < 10; i++) {
			tData.SetHeights(Random.Range(0, res - 50), Random.Range(0, res - 50), flat);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
