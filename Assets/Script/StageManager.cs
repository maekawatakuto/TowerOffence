using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : SingletonMonoBehaviour<StageManager>
{
    [SerializeField]
    private string Stage1;
    [SerializeField]
    private string Stage2;
    [SerializeField]
    private string Stage3;
    [SerializeField]
    private string Stage4;
    [SerializeField]
    private string Stage5;
  public string StageName { get; set; }
    public void Stage1Selecting()
    {
        StageName = Stage1;
    }
    public void Stage2Selecting()
    {
        StageName = Stage2;
        Debug.Log(Stage2);
    }
    public void Stage3Selecting()
    {
        StageName = Stage3;
    }
    public void Stage4Selecting()
    {
        StageName = Stage4;
    }
    public void Stage5Selecting()
    {
        StageName = Stage5;
    }
}
