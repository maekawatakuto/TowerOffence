using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHit : MonoBehaviour
{
    public bool BaseFlag;
    private void Start()
    {
        BaseFlag = false;
    }

    void OnTriggerEnter(Collider collision)
    {
      

        if (collision.gameObject.CompareTag("Base"))//触れた瞬間
        {
            BaseFlag = true;
          
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Base"))
        {
            BaseFlag = false;
        }
    }
}
