using UnityEngine;
using System.Collections;

using System.Collections.Generic;
/// <summary>
/// The camera added this script will follow the specified object.
/// The camera can be moved by left mouse drag and mouse wheel.
/// </summary>
//[ExecuteInEditMode, DisallowMultipleComponent]
public class CameraControl : MonoBehaviour
{


  
    private GameObject target; // target 
    public Vector3 offset; // 

    [SerializeField] private float distance = 4.0f; // targetとカメラの距離
    [SerializeField] public float polarAngle = 45.0f; // angle with y-axis
    [SerializeField] private float azimuthalAngle = 45.0f; // angle with x-axis

    [SerializeField] private float minDistance = 1.0f;//拡大率
    [SerializeField] private float maxDistance = 100.0f;//縮小率
    [SerializeField] private float minPolarAngle = 5.0f;
    [SerializeField] private float maxPolarAngle = 75.0f;
    [SerializeField] private float mouseXSensitivity = 5.0f;
    [SerializeField] private float mouseYSensitivity = 5.0f;
    [SerializeField] private float scrollSensitivity = 5.0f;
    private bool lotation_flag = false;
    public int field_center { get; private set; }
    
    // private float timer;

  
    private void Start()
    {
        target = GameObject.Find("拠点");
    }
    void LateUpdate()
    {
        
        
       fixedrotate(ref lotation_flag);
        if (Input.GetMouseButton(1))
        {
           
                updateAngle(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            
        }

       // updateDistance(Input.GetAxis("Mouse ScrollWheel"));

        var lookAtPos = target.transform.position + offset;
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
void fixedrotate(ref bool lotation_flag )
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
