using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointTraversal : MonoBehaviour
{
    [SerializeField] Waypoints point;
    int currentPoint = 0;

    
    private void Update()
    {
        float dis = Vector3.Distance(point.waypoints[currentPoint], transform.position);
        if ( dis > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, point.waypoints[currentPoint], Time.deltaTime);
        }
        else if(currentPoint < point.waypoints.Count - 1)
        {
            currentPoint++;
        }
        
    }
}
