using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public List<GameObject> visibleTargets = new List<GameObject>();
    Rigidbody rb;
    public GameObject mainLight;
    public GameObject finishBar;
    public Vector3 defaultScale;
    public GameObject traceAll;
    public GameObject lightRed;
    public GameObject lightBlue;
    public GameObject realLightRed;
    public GameObject realLightBlue;
    public Vector3 aradakiFarkLightRed;
    public Vector3 aradakiFarkLightBlue;
    public LayerMask layerMaskRed;
    public LayerMask layerMaskBlue;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        defaultScale = new Vector3(0.42548f, 0.42548f, 0.42548f);
 
    }

    // Update is called once per frame
    void Update()
    {
        visibleTargets = gameObject.GetComponent<scanAreaBetter>().visibleTargets;
        aradakiFarkLightRed = (lightRed.transform.position - transform.position).normalized;
        float disToTargetRed = Vector3.Distance(transform.position, lightRed.transform.position);
        Debug.DrawLine(transform.position, lightRed.transform.position,Color.black);
        if (!Physics.Raycast(transform.position, aradakiFarkLightRed, disToTargetRed, layerMaskRed))
        {
            
            realLightRed.SetActive(true);
        }
        else
        {
            realLightRed.SetActive(false);
        }
        aradakiFarkLightBlue = (lightBlue.transform.position - transform.position).normalized;
        float disToTargetBlue = Vector3.Distance(transform.position, lightBlue.transform.position);
        if (!Physics.Raycast(transform.position, aradakiFarkLightBlue, disToTargetBlue, layerMaskBlue))
        {
            realLightBlue.SetActive(true);
        }
        else
        {
            realLightBlue.SetActive(false);
        }


        foreach (GameObject count in visibleTargets)
        {
            count.GetComponent<targetControl>().makeOnLight();
            count.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            
            

        }
        finishBar.GetComponent<Image>().fillAmount = visibleTargets.Count / 3f;
        
        

        if (visibleTargets.Count == 3)
        {
            mainLight.SetActive(true);
            gameObject.GetComponentInChildren<Light>().enabled = false;
            foreach(GameObject count in visibleTargets)
            {
                count.GetComponentInChildren<Light>().enabled = false;
            }                
            Debug.Log("bitti");
        }
        else
        {
            mainLight.SetActive(false);
            gameObject.GetComponentInChildren<Light>().enabled = true;
            foreach (GameObject count in visibleTargets)
            {
                count.GetComponentInChildren<Light>().enabled = true;
                


            }
           
        }
        
        

    }

    public void traceOpenFonk()
    {
        StartCoroutine(traceOpen());
    }
    public IEnumerator traceOpen()
    {
        
        for(int i = 0; i < 5; i++)
        {
            traceAll.transform.GetChild(i).gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < 5; i++)
        {
            traceAll.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
