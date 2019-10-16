using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StockScript : MonoBehaviour
{
    private float time;
    [SerializeField]
    Image Stock1;
    [SerializeField]
    Image Stock2;
    [SerializeField]
    Image Stock3;
    [SerializeField]
    Image Stock4;

    public int stk { get; set; }
    void Start()
    {
        stk = 4;
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(stk);
        

        if(stk < 5)//４スタック以上はたまらない
        {
            time += Time.deltaTime;
            if (time > 5.0f)//2秒ごとにスタックがたまってく
            {
                stk += 1;
                time = 0;
            }
            if (stk <= 4)
            {
                Stock1.enabled = true;
                Stock2.enabled = true;
                Stock3.enabled = true;
                Stock4.enabled = true;
                if (stk <= 3)
                {
                    Stock1.enabled = true;
                    Stock2.enabled = true;
                    Stock3.enabled = true;
                    Stock4.enabled = false;
                   
                    if (stk <= 2)
                    {
                        Stock1.enabled = true;
                        Stock2.enabled = true;
                        Stock3.enabled = false;
                        Stock4.enabled = false;
                        if (stk <= 1)
                        {
                            Stock1.enabled = true;
                            Stock2.enabled = false;
                            Stock3.enabled = false;
                            Stock4.enabled = false;
                            if (stk <= 0)
                            {
                                Stock1.enabled = false;
                                Stock2.enabled = false;
                                Stock3.enabled = false;
                                Stock4.enabled = false;
                            }
                        }
                    }
                }
            }
        }
                  
    }
}
