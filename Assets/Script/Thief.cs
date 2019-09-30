using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Thief : UnitStatus
{
    GameObject BaseObject;
    JsonRequest request;
    StatusReference statusReference;
    Soldier soldierManager;
    [SerializeField]
    AriaHit ariaHit;
    [SerializeField]
    BaseHit baseHit;
    [SerializeField]
    Slider slider;
    private float time;//攻撃タイマー
   
    bool one;//一度だけ実行
    private void Awake()
    {
        
    }
    void Start()
    {
        HP = 1;
        one = false;
        request = GameObject.Find("JsonObject").GetComponent<JsonRequest>();
        BaseObject = GameObject.Find("拠点");
        statusReference=BaseObject.transform.GetChild(0).GetChild(0).GetComponent<StatusReference>();
       // statusReference = Base
        StartCoroutine(UpdateStatus());
       
    }

 
    void Update()
    {
        if (baseHit.BaseFlag)//baseへの攻撃処理
        {
            time += Time.deltaTime;
            if (time > 4.0f)
            {
                statusReference.HP -= STR;
                time = 0;
            }
        }
        if (ariaHit.Find)
        {
            if (!one)
            {

                soldierManager = ariaHit.TargetObj.GetComponent<Soldier>();//敵のステータスを参照
                one = true;
            }
            Debug.Log(soldierManager);
            time += Time.deltaTime;
            if (time > AS)
            {
                soldierManager.HP -= STR;
                time = 0;
            }
            if (soldierManager.HP <= 0)//敵のｈPがなくなったらfindをリセット＆敵の情報をリセット
            {
                ariaHit.Find = false;
                
            }
           
        }
       else if (!ariaHit.Find)
        {
            soldierManager = null;
            one = false;
        }
        slider.value = HP;
        if (slider.value <= 0)//hpが0の時消滅する
        {
            Destroy(gameObject);
        }
    }
    IEnumerator UpdateStatus()//jsonの値を変数に入れなおす
    {
        yield return request.thiefStatus;
       Name = request.thiefStatus.name;
        STR = request.thiefStatus.STR;
        HP = request.thiefStatus.HP;
        AS = request.thiefStatus.AS;
        slider.maxValue = HP;
        slider.value = HP;
    }
}
