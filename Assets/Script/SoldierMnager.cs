using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoldierMnager : MonoBehaviour
{
    JsonRequest request;
    [SerializeField]
    AriaHit ariaHit;
    [SerializeField]
    Slider slider;
    ThiefManager thiefManager;
    public int STR { get; set; }
    public int HP { get; set; }
    public string Name { get; set; }
    public float AS { get; set;}
    private float timer;//攻撃タイマー
    private bool one;//一度だけ実行
    void Start()
    {
        one = false;
        request = GameObject.Find("JsonObject").GetComponent<JsonRequest>();
        StartCoroutine(UpdateStatus());
       
    }
    private void Update()
    {
        if (ariaHit.Find)
        {
            if (!one)
            {
                thiefManager = ariaHit.TargetObj.GetComponent<ThiefManager>();
                one = true;
            }
            timer += Time.deltaTime;
            if (timer >= AS)
            {
                thiefManager.HP -= STR;
                timer = 0;
            }
            if (HP <= 0)//0になると自身が消滅
            {
                Destroy(gameObject);
            }
        }
        else if (!ariaHit.Find)
        {
            one = false;
            thiefManager = null;//敵を見失ったときリセットする
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
