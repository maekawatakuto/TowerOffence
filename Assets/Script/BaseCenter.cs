using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
[DefaultExecutionOrder(-50)]
public class BaseCenter : MonoBehaviour {

    [SerializeField]
    CreateField createField;
    [SerializeField]
    GameObject BaseObj;
    private GameObject Base;
    int mapCenter;
    string namae = "拠点";
    private void Awake()
    {
        int Width = createField.Width;
        int Depth = createField.Depth;
        int sum = (Depth*Width)/2+(Width/2);
      int mapCenter = Mathf.CeilToInt(sum);
        string str=mapCenter.ToString();

        GameObject gameobj=GameObject.Find(str);
        Vector3 target = gameobj.transform.position;
         Base= Instantiate(BaseObj, target, Quaternion.identity) as GameObject;
        Base.name = namae;

    }
}
