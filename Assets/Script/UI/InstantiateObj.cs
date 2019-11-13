using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InstantiateObj : MonoBehaviour
{
    // Start is called before the first frame update
     public bool botanflag;
    [SerializeField]
   public Button botan;
    [SerializeField]
    EditCamera editCamera;//カメラ視点のポジションをとるため
    [SerializeField]
    GameObject prefav;//生成したいprefav
    [SerializeField]
    private string prefavName;
    [SerializeField]
    Vector3 offset;
    public GameObject prefavObj { get; set; }//prefavをここに格納
    [SerializeField]
    FieldCreate fieldCreate;//csvデータを参照
    
    private void Start()
    {
        botanflag = false;
        prefavObj = null;
       
    }
    public void NewObj()
    {
      
        botanflag =true;
        if (prefavObj == null)
        {
            prefavObj = Instantiate(prefav, editCamera.Target.transform.position, Quaternion.identity);
        }

    }
    private void LateUpdate()
    {
        if (prefavObj != null)
        {
            prefavObj.transform.position = editCamera.Target.transform.position;//選択された位置にobjectとが移動する
            if (Input.GetKeyDown(KeyCode.Space))
            {
                prefavObj = null;
                botanflag = false;
                if (prefavName == "Tower")
                {
                   fieldCreate.csvDatas[editCamera.width][editCamera.depth] = "1";
                }
                if (prefavName == "Enemy")
                {
                    fieldCreate.csvDatas[editCamera.width][editCamera.depth] = "2";
                }
               
            }
         
        }
       
    }
}
