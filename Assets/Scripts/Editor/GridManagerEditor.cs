using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GridManager))]
public class GridManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        var gridManager = target as GridManager;

        DrawDefaultInspector();
        if(GUILayout.Button("Generate"))
        {
            gridManager.GenerateGrid();
        }
    }
}
