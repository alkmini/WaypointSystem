using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public List<Vector3> waypoints = new List<Vector3>();

    [ContextMenu("Add Waypoint")]
    public void Add()
    {
        waypoints.Add(Vector3.zero);
    }

    [ContextMenu("Remove Waypoint")]
    public void Remove()
    {
        waypoints.RemoveAt(waypoints.Count - 1);
    }

    public void OnDrawGizmos()
    {
        for (int i = 0; i < waypoints.Count; i++)
        {
            Gizmos.color = Color.cyan;
            if (i < waypoints.Count - 1)
            {
                Gizmos.DrawLine(waypoints[i], waypoints[i + 1]);
            }
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(waypoints[i], 0.1f);
        }
    }

}
