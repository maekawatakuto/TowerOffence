using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class FieldCreate : MonoBehaviour
{

  //  [SerializeField]
   // private GameObject field;
    [SerializeField]
    private GameObject TowerPrefav;
    [SerializeField]
    private GameObject SoldierPrefav;
    [SerializeField]
    private GameObject Wall;
    [SerializeField]
    private Vector3 offset;
    TextAsset csvFile;
    [SerializeField]
    GameObject grand;//床
    [SerializeField]
    GameObject BaseObj;
    [SerializeField]
    private string CsvTextName;
     public int count { get; set; }
    int nameCount;//objの名前
    public List<string[]> csvDatas; //stringがたの配列
    public GameObject[,] FieldObject;
    public int MaxWidth { get;private set; }
    public int MaxDepth { get; private set; }
    void Awake()
    {
   
        nameCount = 0;
        count = 0;
        csvDatas = new List<string[]>();
        csvFile = Resources.Load(CsvTextName) as TextAsset;//Resource下のcsv読み込み
        StringReader reader = new StringReader(csvFile.text);//Csvデータを操作しやすいデータとしてよみこみ？
                                                             // , で分割しつつ一行ずつ読み込み
                                                             // リストに追加していく
        while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        {
            count += 1;
            string line = reader.ReadLine(); // 一行ずつ読み込み
            csvDatas.Add(line.Split(',')); // , 区切りでリストに追加
        }
        FieldObject = new GameObject[csvDatas.Count,count]; 
        for(int i = 0; i < csvDatas.Count;i++)
        {
            for(int j = 0; j<count;j++)
            {
             
                GameObject Ins = Instantiate(grand, new Vector3(i, 0, j), Quaternion.identity);
             
               Ins.name = nameCount.ToString();
                FieldObject[i,j] = Ins;
                if (csvDatas[i][j] == "1")//1だった場合タワーを配置
                {
                    GameObject Obj = Instantiate(TowerPrefav, Ins.transform.position+offset, Quaternion.identity);
                    //  Debug.Log(CSVarray[i, j]);
                }
                if (csvDatas[i][j] == "2")//2だった場合兵士を配置
                {
                    GameObject obj = Instantiate(SoldierPrefav, Ins.transform.position+offset, Quaternion.identity);
                }
                if (csvDatas[i][j] == "3")//3だった場合壁を配置
                {
                    GameObject obj = Instantiate(Wall, Ins.transform.position+offset, Quaternion.identity);
                }
                if (i == csvDatas.Count / 2 && j == count / 2)
                {
                    GameObject obj = Instantiate(BaseObj, Ins.transform.position + offset, Quaternion.identity);//中心に拠点を配置
                }
                nameCount += 1;//数値で名前付け
            }
        }
       
        MaxWidth=count;
        MaxDepth=csvDatas.Count;
    }

    void Update()
    {
        
    }
}
