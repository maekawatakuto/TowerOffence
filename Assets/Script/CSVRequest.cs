using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class CSVRequest : MonoBehaviour
{
    TextAsset csvFile;
    
    private string CsvTextName;
    private int width;
    public int WIDTH//値が入った時-1
    {
         set
        {
            width=value;
            width -= 1;
            
        }
        get
        {
            return width;
        }
    }
    private int depth;
    public int DEPTH//値が入った時-1
    {
        set
        {
            depth= value;
            depth -= 1;

        }
        get
        {
            return DEPTH;
        }
    }
    
    public List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト;
    void Awake()
    {
        CsvTextName = StageManager.Instance.StageName;
        WIDTH = 18;
        DEPTH = 6;
        csvFile = Resources.Load(CsvTextName)as TextAsset;//Resource下のcsv読み込み
        StringReader reader = new StringReader(csvFile.text);//Csvデータをテキストとしてよみこみ？
                                                             // , で分割しつつ一行ずつ読み込み
                                                             // リストに追加していく
        while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            csvDatas.Add(line.Split(',')); // , 区切りでリストに追加
        }

    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
