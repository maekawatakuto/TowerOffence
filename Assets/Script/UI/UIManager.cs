using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    StatusReference Base;
    [SerializeField]
    GameObject WINOBJ;
    [SerializeField]
    GameObject LOSEOBJ;
    [SerializeField]
    TIMERscript timeScript;
    private bool flag;
    void Start()
    {
        flag = false;
        Base=GameObject.Find("拠点").transform.GetChild(0).GetChild(0).GetComponent<StatusReference>();
        // statusReference = Base

        StartCoroutine(coroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (Base.HP <= 0)
        {
            WINOBJ.SetActive(true);
            LOSEOBJ.SetActive(false);
            flag = true;
        }
        else if (timeScript.timer < 0 )
        {
            LOSEOBJ.SetActive(true);
            WINOBJ.SetActive(false);
            flag = true;
        }
    }
    IEnumerator coroutine()
    {
        yield return Base.HP;
            WINOBJ.SetActive(false);
    }
}
