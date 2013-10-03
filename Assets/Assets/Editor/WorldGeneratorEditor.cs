using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(WorldGenerator))]
public class WorldGeneratorEditor : Editor {
	
	public override void OnInspectorGUI() {
		WorldGenerator myTarget = (WorldGenerator) target;
		
		DrawDefaultInspector();
		if(GUILayout.Button("nappula")) {
			myTarget.Generoi();
		}
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
