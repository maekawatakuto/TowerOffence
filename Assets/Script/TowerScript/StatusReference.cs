using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StatusReference : MonoBehaviour
{
    Slider HPbar;
    public int HP { get; set; }
    private JsonRequest request;
    void Start()
    {
        
        HPbar = GetComponent<Slider>();
        request = GameObject.Find("JsonObject").GetComponent<JsonRequest>();

        StartCoroutine(UpdateStatus());
    }
    private void Update()
    {
        HPbar.value =HP;
    }
    IEnumerator UpdateStatus()//jsonからの値を読み込みUIに反映
    {
        yield return request.BaseStatus;
        HP = request.BaseStatus.HP;
        HPbar.maxValue = request.BaseStatus.HP;
        HPbar.value = HP;
    

    }
}
