using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraDirection : MonoBehaviour
{   [SerializeField]
    private Canvas canvas;
  
    void Update()
    {
        //Main Cameraに向かせる
        canvas.transform.rotation = Camera.main.transform.rotation;
    }
}
