using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Soldier: UnitStatus
{
    JsonRequest request;
    [SerializeField]
    AriaHit ariaHit;
    [SerializeField]
    Slider slider;
    Thief thiefManager;

  /*  public int STR;
    public int HP;
    public string Name;
    public float AS;*/
    private float timer;//攻撃タイマー
    private bool one;//一度だけ実行
    
    void Start()
    {
       
        one = false;
        request = GameObject.Find("JsonObject").GetComponent<JsonRequest>();
        StartCoroutine(UpdateStatus());
       
    }
    private void LateUpdate()
    {
        if (ariaHit.Find)
        {
            
            if (!one)
            {
                thiefManager = ariaHit.TargetObj.GetComponent<Thief>();
                one = true;
            }
            timer += Time.deltaTime;
            if (timer >= AS)
            {
                thiefManager.HP -= STR;
                timer = 0;
            }
            if (thiefManager.HP <= 0)
            {//敵をたおしたら探索をやめる
               
                one = false;
                ariaHit.Find = false;

            }
        }
        else if (!ariaHit.Find)
        {
           
            one = false;
            thiefManager = null;//敵を見失ったときリセットする
        }
        if (slider.value <= 0)//0になると自身が消滅
        {
            Destroy(gameObject);

        }
       
        slider.value = HP;//常にUIへ更新
     
    }
    IEnumerator UpdateStatus()//jsonの値を変数に入れなおす
    {
        yield return request.soldierStatus.name;
        Name = request.soldierStatus.name;
        STR = request.soldierStatus.STR;
        HP = request.soldierStatus.HP;
        AS = request.soldierStatus.AS;
        slider.maxValue = HP;
        slider.value = HP;
     
    }
}
