using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Waypoints))]
public class WaypointInspector : Editor
{
    Waypoints point;
    private SerializedObject serializedTarget;
    private SerializedProperty wayPointList;

    private void OnEnable() 
    {
        point = (Waypoints)target;
        SceneView.duringSceneGui += DuringSceneGUI;

        serializedTarget = new SerializedObject(point);
        wayPointList = serializedTarget.FindProperty("waypoints");
    }

    private void OnDisable()
    {
        SceneView.duringSceneGui -= DuringSceneGUI;
    }

    private void DuringSceneGUI(SceneView sceneView)
    {
        serializedTarget.Update();
        for (int i = 0; i < wayPointList.arraySize; i++)
        {
            wayPointList.GetArrayElementAtIndex(i).vector3Value = Handles.PositionHandle(point.waypoints[i] , Quaternion.identity);
        }

        serializedTarget.ApplyModifiedProperties();

        if (Event.current.type == EventType.MouseMove)
        {
            sceneView.Repaint();
        }
    }
}
