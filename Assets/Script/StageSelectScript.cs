using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject selectButton;
    [SerializeField]
    GameObject Stage;
    bool flag;
    private void Start()
    {
        flag = true;
        selectButton.SetActive(flag);
        Stage.SetActive(!flag);
    }
    public void SetActive()
    {
        flag = !flag;
        selectButton.SetActive(flag);
        Stage.SetActive(!flag);
    } 
}
