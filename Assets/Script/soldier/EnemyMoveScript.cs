using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMoveScript : MonoBehaviour
{

    private GameObject[] obj;
    private float[] distans;
    private float[] savedistans;
    [SerializeField]
    private NavMeshAgent m_navAgent;
    GameObject Target;
    [SerializeField]
    AriaHit ariaHit;
    float dis;
    Vector3 targetposition;
    Vector3 tar;

    bool one;
    // Start is called before the first frame update
    void Start()
    {
        one = false;
        obj = new GameObject[4];
        distans = new float[4];
        savedistans = new float[4];

       
        obj[0] = GameObject.Find("Colider1");
        obj[1] = GameObject.Find("Colider2");
        obj[2] = GameObject.Find("Colider3");
        obj[3] = GameObject.Find("Colider4");
      
        for (int i = 0; i < 4; i++)
        {
            savedistans[i] = Vector3.SqrMagnitude(this.transform.position - obj[i].transform.position);//ソートする前の配列の中身を保持
            distans[i] = Vector3.SqrMagnitude(this.transform.position - obj[i].transform.position);//4方向のcolliderObjectと自分との距離をだす
        }
        BubbleSort(ref distans);//距離が短いものを配列の三番目に持ってくる
        for (int i = 0; i < 4; i++)
        {

            if (distans[3] == savedistans[i])
            {
                targetposition = obj[i].transform.position;
                
                    m_navAgent.SetDestination(obj[i].transform.position);//拠点の方向に進む
                   
            }
        }


    }
    
    private void FixedUpdate()
    {
      //  if (ariaHit.Find)
       // {
            if (ariaHit.TargetObj == null)
            {
                for (int i = 0; i < 4; i++)
                {
                    savedistans[i] = Vector3.SqrMagnitude(this.transform.position - obj[i].transform.position);//ソートする前の配列の中身を保持
                    distans[i] = Vector3.SqrMagnitude(this.transform.position - obj[i].transform.position);//4方向のcolliderObjectと自分との距離をだす
                }
                BubbleSort(ref distans);//距離が短いものを配列の三番目に持ってくる
                for (int i = 0; i < 4; i++)
                {

                    if (distans[3] == savedistans[i])
                    {
                        
                        targetposition = obj[i].transform.position;
                        if (!one)
                        {
                            m_navAgent.SetDestination(obj[i].transform.position);//拠点の方向に進む
                            one = true;
                        }
                    }
                }
                ariaHit.Find = false;
            }
            else if (ariaHit.TargetObj != null)
            {
                one = false;
                targetposition = ariaHit.TargetObj.transform.position;
                tar = this.transform.position - targetposition;
                dis = tar.sqrMagnitude;//targetと敵の距離のべき乗
                m_navAgent.SetDestination(targetposition);

            }
        //}
    }

    void BubbleSort(ref float[] a)
    {
        bool isEnd = false;
        while (!isEnd)
        {
            bool loopSwap = false;
            for (int i = 0; i < a.Length - 1; i++)
            {
                if (a[i] < a[i + 1])
                {
                    swap(ref a[i], ref a[i + 1]);
                    loopSwap = true;
                }
            }
            if (!loopSwap) // Swapが一度も実行されなかった場合はソート終了
            {
                isEnd = true;
            }
        }
    }
    void swap(ref float a, ref float b)
    {
        float c;
        c = a;
        a = b;
        b = c;
    }
}


