using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonRequest : MonoBehaviour
{
    public Charactor thiefStatus;
    public Charactor soldierStatus;
    public Object BaseStatus;
    public Object TowerStatus;


    private void Awake()
    {

        StartCoroutine(Request());
    }
    IEnumerator Request()
    {
        string path = Application.streamingAssetsPath;//pathを取得
        WWW www = new WWW($"file://{path}/charactorList.json");
        yield return www;
        string jsontText = www.text;

        CharactorScript charactor = JsonUtility.FromJson<CharactorScript>(jsontText);//読み込み
        foreach (var chara in charactor.charactor_list)
        {
            if (chara.name == "thief")
            {
                thiefStatus = chara;//jsonのthiefのステータスを取得
            }
            if (chara.name == "soldier")
            {
                soldierStatus = chara;

            }


            foreach (var Objstatus in charactor.object_list)
            {
                if (Objstatus.name == "Base")
                {
                    BaseStatus = Objstatus;
                }
                if (Objstatus.name == "Tower")
                {
                    TowerStatus = Objstatus;
                }
            }




        }
    }
}