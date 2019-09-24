using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ThiefManager : MonoBehaviour
{
    GameObject BaseObject;
    JsonRequest request;
    StatusReference statusReference;
    SoldierMnager soldierManager;
    [SerializeField]
    AriaHit ariaHit;
    [SerializeField]
    BaseHit baseHit;
    [SerializeField]
    Slider slider;
    private float time;//攻撃タイマー
    public int HP { get; set;}
    public int STR { get; set; }
    public float AS { get; set; }
    public string Name { get; set; }
    bool one;//一度だけ実行
    void Start()
    {
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
                soldierManager = ariaHit.TargetObj.GetComponent<SoldierMnager>();//敵のステータスを参照
                one = true;
            }
            time += Time.deltaTime;
            if (time > AS)
            {
                soldierManager.HP -= STR;
                time = 0;
            }
            if (HP <= 0)//hpが0の時消滅する
            {
                Destroy(gameObject);
            }
        }
        else if (!ariaHit.Find)
        {
            one = false;
            soldierManager = null;//敵を見失ったときリセットする
        }
        slider.value = HP;
     
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
