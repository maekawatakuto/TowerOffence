using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    JsonRequest request;
    [SerializeField]
    AriaHit serchEnemy;
    Thief thiefManager;
    public int STR { get; set; }
    public string Name { get; set; }
    public float AS { get; set;}
    bool one;//一度だけ実行
    float timer;//攻撃するタイミング
    void Start()
    {
        one = false;
        request = GameObject.Find("JsonObject").GetComponent<JsonRequest>();
        StartCoroutine(UpdateStatus());
    }

    // Update is called once per frame
    void Update()
    {
        if (serchEnemy.Find)
        {
            if (!one)
            {
                one = true;
                thiefManager = serchEnemy.TargetObj.GetComponent<Thief>();
            }
            timer += Time.deltaTime;
            if (timer >= AS)
            {
                thiefManager.HP -= STR;
                timer = 0;
            }
          
        }
        else if (!serchEnemy.Find)
        {
            one = false;
        }
    }
    IEnumerator UpdateStatus()//jsonの値を変数に入れなおす
    {
        yield return request.TowerStatus;
        Name = request.TowerStatus.name;
        STR = request.TowerStatus.STR;
        AS = request.TowerStatus.AS;

    }
}
