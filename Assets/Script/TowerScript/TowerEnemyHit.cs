using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEnemyHit : MonoBehaviour
{

    public bool Find = false;
    public GameObject TargetObj { get; set; }
    public string TargetTagname;

    public string objName { get; private set; }
    public string childName { get; private set; }
    public string targetName { get; private set; }
    public Transform SavePosition { get; private set; }


    void OnTriggerStay(Collider collision)
    {


        if (collision.gameObject.CompareTag(TargetTagname))//触れてる間
        {
            if (collision.gameObject.GetComponent<Thief>() != null)
            {
                if (collision.gameObject.GetComponent<Thief>().HP > 0)
                {
                    Find = true;         
                    TargetObj = collision.gameObject;
                    targetName = TargetObj.name;//ヒットしたオブジェクトの名前を格納
                    SavePosition = TargetObj.transform;//circleにヒットしたオブジェクトの位置を格納
                    
                }


            }

        }
       
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag(TargetTagname))//離れた瞬間　情報をリセット
        {
            
             
                Find = false;
            
        }
    }
}
