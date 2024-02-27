using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof (scanAreaBetter))]
public class fieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        scanAreaBetter  scan = (scanAreaBetter)target;
        Handles.color = Color.yellow;
        Handles.DrawWireArc(scan.transform.position, Vector3.up, Vector3.forward, 360, scan.viewRadius);
        Vector3 viewAngle1 = scan.dirFromAngle(-scan.viewAngle / 2, false);
        Vector3 viewAngle2 = scan.dirFromAngle(scan.viewAngle / 2, false);
        Handles.DrawLine(scan.transform.position,scan.transform.position + viewAngle1 * scan.viewRadius);
        Handles.DrawLine(scan.transform.position, scan.transform.position + viewAngle2 * scan.viewRadius);
        Handles.color = Color.red;
        foreach(GameObject visibleTarget in scan.visibleTargets)
        {
            Handles.DrawLine(scan.transform.position, visibleTarget.transform.position);
        }
    }
}
