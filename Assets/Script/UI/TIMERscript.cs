using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TIMERscript : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textMesh;
    
   public float timer { get; set; }//制限時間
  
    void Start()
    {
        timer =60;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        textMesh.text = ((int)timer).ToString();
       
    }
}
