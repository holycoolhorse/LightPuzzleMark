using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class sinirScript : MonoBehaviour
{
    public GameObject leftStickPoint;
    public GameObject rightStickPoint;
    public GameObject leftPoint;
    public GameObject rightPoint;
    public GameObject leftStick;
    public GameObject rightStick;
    public Vector3 aradakiFarkLeft;
    public Vector3 aradakiFarkRight;
    public Transform rotNew;
    public GameObject glassLight;
    public GameObject glass;
    public GameObject glassAll;
    public GameObject player;
    public LayerMask glassLayer;
    void Start()
    {
        rotNew = transform;
        
    }

    // Update is called once per frame
    void Update()
    {

        /*aradakiFarkLeft = leftPoint.transform.position - leftStick.transform.position  ;
        float angleLeft = Mathf.Atan2(-aradakiFarkLeft.x, -aradakiFarkLeft.z) * Mathf.Rad2Deg;
        leftStick.transform.eulerAngles = Vector3.up * angleLeft;
        aradakiFarkRight = rightPoint.transform.position - rightStick.transform.position ;
        float angleRight = Mathf.Atan2(-aradakiFarkRight.x, -aradakiFarkRight.z) * Mathf.Rad2Deg;
        rightStick.transform.eulerAngles = Vector3.up * angleRight;*/
        /*Vector3 aradakifark = transform.position - leftStick.transform.position;
        leftStick.transform.position += aradakifark;*/
        
        glassLight.transform.LookAt(glass.transform);
        //leftStick.transform.LookAt(leftPoint.transform);
        //rightStick.transform.LookAt(rightPoint.transform);
        glassLight.transform.position = player.transform.position;
        //float angleDifference = CalculateAngleDifference(leftStickPoint.transform, rightStickPoint.transform, transform.position);
        //Debug.Log(angleDifference);

        glassLight.GetComponent<Light>().spotAngle = deneme(leftPoint, rightPoint, player) -6f ;
        /*Debug.Log(deneme(leftPoint, rightPoint, player));
        Vector3 dirToTarget = (glassAll.transform.position - player.transform.position).normalized;
        float disToTarget = Vector3.Distance(player.transform.position, glassAll.transform.position);
        if (Physics.Raycast(player.transform.position, dirToTarget, disToTarget, glassLayer))
        {
            glassLight.SetActive(true);
        }
        else 
        {
            glassLight.SetActive(false);
        }*/


    }
    float CalculateAngleDifference(Transform fromTransform, Transform toTransform, Vector3 axis)
    {
        Vector3 fromDirection = fromTransform.position - toTransform.position;
        Vector3 toDirection = fromTransform.TransformDirection(axis);

        return Vector3.Angle(fromDirection, toDirection);
    }
    float deneme(GameObject left,GameObject right,GameObject player)
    {
        Vector3 leftDegree = left.transform.position - player.transform.position;
        Vector3 rightDegree = right.transform.position - player.transform.position;
        return Vector3.Angle(leftDegree, rightDegree);
    }
}
