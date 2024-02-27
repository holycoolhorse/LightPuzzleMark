using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scanArea : MonoBehaviour
{
    private Vector3 aradakiFark;
    [SerializeField] LayerMask enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {   
        RaycastHit hit;
        Debug.Log(other.name);
        aradakiFark = transform.position - other.transform.position;
        if (Physics.Raycast(transform.position, aradakiFark, out hit,Mathf.Infinity,enemy))
        {
            Debug.Log(other.name);
            Debug.Log("Çalýþtý");
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, aradakiFark);
        
    }
}
