using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class scanAreaBetter : MonoBehaviour
{   
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;
    public LayerMask Target;
    public LayerMask obstacleMask;
    public LayerMask glasses;
    public List<GameObject> visibleTargets = new List<GameObject>();
    public LayerMask glassLayer;
    public LayerMask glassLayerBlue;
    public bool isBlueBroken;
    

    public Vector3 dirFromAngle(float angleinDegrees,bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleinDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleinDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleinDegrees * Mathf.Deg2Rad));
    }
    public void findVisibleTargets()
    {
        foreach (GameObject count in visibleTargets)
        {
            count.GetComponent<targetControl>().makeOffLight();

        }
        visibleTargets.Clear();
        Collider[] targetViewInRadius = Physics.OverlapSphere(transform.position, viewRadius, Target);
        for(int i = 0; i < targetViewInRadius.Length; i++)
        {
            GameObject target = targetViewInRadius[i].gameObject;
            Vector3 dirToTarget = (target.transform.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward,dirToTarget)< viewAngle / 2)
            {
                float disToTarget = Vector3.Distance(transform.position, target.transform.position);
                if (!Physics.Raycast(transform.position, dirToTarget, disToTarget, obstacleMask))
                {
                    
                    visibleTargets.Add(target);

                    if (Physics.Raycast(transform.position, dirToTarget, disToTarget, glassLayer))
                    {
                        if (isBlueBroken)
                        {
                            target.transform.GetChild(1).gameObject.SetActive(false);
                        }
                        
                        
                    }
                    if (Physics.Raycast(transform.position, dirToTarget, disToTarget, glassLayerBlue))
                    {

                        target.transform.GetChild(2).gameObject.SetActive(false);
                        isBlueBroken = true;

                    }

                }
                
                
            }
        }
    }
    void Start()
    {
        //StartCoroutine(FindTargetWithDelay(.2f));
        findVisibleTargets();
    }
    IEnumerator FindTargetWithDelay(float delay)
    {
        //while (true)
        //{
            yield return new WaitForSeconds(delay);
            findVisibleTargets();
        //s}
    }
    // Update is called once per frame
    void Update()
    {
        findVisibleTargets();
    }
}
