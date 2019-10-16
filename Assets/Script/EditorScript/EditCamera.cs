using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class EditCamera : MonoBehaviour
{


    [SerializeField]
    FieldCreate fieldCreate;
    public GameObject Target;
    public Vector3 offset; // offset form the target object
    
    [SerializeField] private float distance = 4.0f; // distance from following object
    [SerializeField] public float polarAngle = 45.0f; // angle with y-axis
    [SerializeField] private float azimuthalAngle = 45.0f; // angle with x-axis

    [SerializeField] private float minDistance = 1.0f;
    [SerializeField] private float maxDistance = 100.0f;
    [SerializeField] private float minPolarAngle = 5.0f;
    [SerializeField] private float maxPolarAngle = 75.0f;
    [SerializeField] private float mouseXSensitivity = 5.0f;
    [SerializeField] private float mouseYSensitivity = 5.0f;
    [SerializeField] private float scrollSensitivity = 5.0f;
    private bool lotation_flag = false;
    public int center;
    string Name;
   
    private int save_date;
    private void Start()
    {
        center = 0;
         Name = center.ToString();
        Target = GameObject.Find(Name);
    }

    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.D))//右にターゲット移動
        {
         
            if (center < 50* 50 - 1)//フィールドの上限を超えていない場合
            {
                center += 1;
                for (int i = 1; i <= center; i++)
                {
                    if (i * 50- 1 ==center)//端までcenterが移動した場合それ以上さきにいけないようにする
                    {
                        center -= 1;
                    }
                }
            }

            Name = center.ToString();
            Target = GameObject.Find(Name);
          
                 
        }
       
        if (Input.GetKey(KeyCode.A))
        {
            
             center -= 1;
            if (center == 0)//centerが左端に行った場合いけなくする
            {
                center += 1;
            }
           
            Name = center.ToString();
            Target = GameObject.Find(Name);
          
         
        }
        if (Input.GetKey(KeyCode.W))
        {

            if (center >50)//上にターゲット移動
            {
                center -=50;

            }
            Name = center.ToString();
            Target = GameObject.Find(Name);
          
        }
        if (Input.GetKey(KeyCode.S))
        {

            
            if (center < (50 - 1) * 50)
            {

                center +=50;
                
            }
            Name = center.ToString();
            Target = GameObject.Find(Name);
          
        }
        
      
        if (Input.GetMouseButton(1))
        {
           
                updateAngle(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            
        }

        updateDistance(Input.GetAxis("Mouse ScrollWheel"));
        var lookAtPos = Target.transform.position + offset;
        updatePosition(lookAtPos);
        transform.LookAt(lookAtPos);
    
}

    void updateAngle(float x, float y)//回転処理
    {
        x = azimuthalAngle - x * mouseXSensitivity;
        azimuthalAngle = Mathf.Repeat(x, 360);

        y = polarAngle + y * mouseYSensitivity;
        polarAngle = Mathf.Clamp(y, minPolarAngle, maxPolarAngle);
    }

    void updateDistance(float scroll)//ホイールでの拡大処理
    {
        scroll = distance - scroll * scrollSensitivity;
        distance = Mathf.Clamp(scroll, minDistance, maxDistance);
    }

    void updatePosition(Vector3 lookAtPos)
    {
        var da = azimuthalAngle * Mathf.Deg2Rad;
        var dp = polarAngle * Mathf.Deg2Rad;
        transform.position = new Vector3(
            lookAtPos.x + distance * Mathf.Sin(dp) * Mathf.Cos(da),
            lookAtPos.y + distance * Mathf.Cos(dp),
            lookAtPos.z + distance * Mathf.Sin(dp) * Mathf.Sin(da));
    }
    void fixedrotate(ref bool lotation_flag)
    {
        if (lotation_flag)//回転処理
        {
            if (azimuthalAngle <= 180)
            {
                azimuthalAngle -= 10f;
            }
            else if (azimuthalAngle > 180)
            {
                azimuthalAngle += 10;
            }
        }
        if (azimuthalAngle <= 0 || azimuthalAngle >= 360)
        {
            azimuthalAngle = 0;
            lotation_flag = false;
        }

    }

}
