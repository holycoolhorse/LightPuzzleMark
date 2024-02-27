using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    Vector3 aradakiFark;
    [SerializeField]Vector3 deneme;
    [SerializeField] GameObject Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        aradakiFark = Player.transform.position - transform.position;
        transform.position += new Vector3(aradakiFark.x ,aradakiFark.y + 13.1f,aradakiFark.z - 10f) ;
    }
}
