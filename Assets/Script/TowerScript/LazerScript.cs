using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LazerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject Tower;
    
    private LineRenderer lineRenderer;
    [SerializeField]
    private SerchEnemy serchEnemy;
    
    private float targetPosition;
    Vector3 Offset;
  
    void Start()
    {
        Offset = new Vector3(0,3,0);
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0,Tower.transform.position+Offset);
        lineRenderer.SetPosition(1, Tower.transform.position+Offset);
    }

    // Update is called once per frame
    void Update()
    {
     
        if (serchEnemy.Find)
        {
            lineRenderer.SetPosition(1,serchEnemy.TargetObj.transform.position);
           
        }
        else if (!serchEnemy.Find)
        {
            lineRenderer.SetPosition(1,Tower.transform.position+Offset);
        }
        
    }
    
}
