using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(Generator), true)]
public class GeneratorEditor : Editor {
	
	public override void OnInspectorGUI() {
		Generator myTarget = (Generator) target;
		
		DrawDefaultInspector();
		if(GUILayout.Button("Generate")) {
			myTarget.Delete();
			myTarget.Generate();
		}
		if(GUILayout.Button("Remove")) {
			myTarget.Delete();
		}
	}
}
