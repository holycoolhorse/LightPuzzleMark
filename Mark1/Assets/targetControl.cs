using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UIElements;

public class targetControl : MonoBehaviour
{
    [SerializeField] GameObject light;
    public bool isLightOn;
    // Start is called before the first frame update
    void Start()
    {
        isLightOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLightOn)
        {
            light.SetActive(true);
            gameObject.transform.localScale = new Vector3(0.54f, 0.54f, 0.54f);
        }
        else
        {
            light.SetActive(false);
            gameObject.transform.localScale = new Vector3(0.42548f, 0.42548f, 0.42548f);
        }
    }
    public void makeOnLight()
    {
        isLightOn = true;
        gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
    }
    public void makeOffLight()
    {
        isLightOn = false;
        gameObject.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
    }

}

