using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class EditCamera : MonoBehaviour
{


    [SerializeField]
    FieldCreate fieldCreate;
  
    private GameObject target;
    public GameObject Target
    {    set
        {
            target = value;
            updateColor(Target, fieldCreate.FieldObject, targetColor, defaultColor, fieldCreate.MaxDepth, fieldCreate.MaxWidth);
        }

        get{
            return target;
        }
    }
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

    string Name;
    public int width { get;  set; }
    public int depth { get; set; }
    private int save_date;
    [SerializeField]//選択されたobjの色
    private Color targetColor;
    [SerializeField]
    private Color defaultColor;
    private void Start()
    {
        width = 0;
        depth = 0;

    }

    void Update()
    {
       
        
        if (Input.GetKey(KeyCode.D))//右にターゲット移動
        {
            if (width < fieldCreate.MaxWidth-1)
            {
                width += 1;
            }
        }
       
        if (Input.GetKey(KeyCode.A))//左
        {
            if (width > 0)
            {
                width -= 1;
            }
      
        }
        if (Input.GetKey(KeyCode.W))//上
        {
            if (depth > 0)
            {
                depth -= 1;
            }
        }
        if (Input.GetKey(KeyCode.S))//下
        {
            if (depth < fieldCreate.MaxDepth-1)
            {
                depth += 1;

            }
     
        }
  
        if (Input.GetMouseButton(1))
        {
           
                updateAngle(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            
        }
        Target = fieldCreate.FieldObject[depth,width];
        updateDistance(Input.GetAxis("Mouse ScrollWheel"));
        var lookAtPos = Target.transform.position + offset;
        updatePosition(lookAtPos);
        transform.LookAt(lookAtPos);
        //updateColor(Target, fieldCreate.FieldObject, targetColor, defaultColor, fieldCreate.MaxDepth, fieldCreate.MaxWidth);
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
    private void updateColor(GameObject obj,GameObject[,]fieldobj,Color targetColor,Color defaultColor,int maxWidth,int maxDepth)
    {
        
        for(int i = 0; i < maxWidth; i++)
        {
            for(int j = 0; j < maxDepth; j++)
            {
              fieldobj[i, j].GetComponent<Renderer>().material.color=defaultColor;
            }
        }
        obj.GetComponent<Renderer>().material.color = targetColor;
    }
    

}
