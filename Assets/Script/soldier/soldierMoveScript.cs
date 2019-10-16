using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class soldierMoveScript : MonoBehaviour
{
    
    [SerializeField]
    NavMeshAgent agent;
    Vector3 respawnPosition;
    [SerializeField]
    AriaHit ariaHit;
    GameObject saveObj;
    Vector3 targetposition;
    void Awake()
    {
        respawnPosition = this.transform.position;//初期位置を格納
    }

    // Update is called once per frame
    void Update()
    {
        if (ariaHit.Find)
        {
           
            if (ariaHit.TargetObj == null)//hitしたオブジェクトがないとき初期の位置に戻る
            {
                ariaHit.Find = false;
                agent.SetDestination(respawnPosition);
            }
            else if (ariaHit.TargetObj != null)//hitした場合そこへ向かう
            {
                targetposition = ariaHit.TargetObj.transform.position;
              
                agent.SetDestination(targetposition);
            }
            
        }
       else if (!ariaHit.Find)
        {
            agent.SetDestination(respawnPosition);
        }
    }
}
