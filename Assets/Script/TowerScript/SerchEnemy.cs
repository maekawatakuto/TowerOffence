using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SerchEnemy : MonoBehaviour
{

    public bool Find = false;
    public GameObject TargetObj { get; set; }
    public string TargetTagname;

    public string objName { get; private set; }
    public string childName { get; private set; }
    public string targetName { get; private set; }
    public Transform SavePosition { get; private set; }
   

    void OnTriggerEnter(Collider collision)
    {
       

        if (collision.gameObject.CompareTag(TargetTagname))//触れた瞬間
        {
            Find = true;
          //  towerDamage = collision.gameObject.GetComponent<TowerDamage>();
           // towerDamage.find = true;
            TargetObj = collision.gameObject;
            targetName = TargetObj.name;//ヒットしたオブジェクトの名前を格納
            SavePosition = TargetObj.transform;//circleにヒットしたオブジェクトの位置を格納
           

        }
      
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag(TargetTagname))
        {
            Find = false;
            //towerDamage.find = false;
        }
    }
   
}
