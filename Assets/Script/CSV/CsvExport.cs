using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
public class CsvExport : MonoBehaviour
{  [SerializeField]
    FieldCreate fieldCreate;
    [SerializeField]
    private string CSVTEXTNAME;
    
    public  void ExportCSV()
    {
      
        // ファイル書き出し
        // 現在のフォルダにsaveData.csvを出力する(決まった場所に出力したい場合は絶対パスを指定してください)
        // 引数説明：第1引数→ファイル出力先, 第2引数→ファイルに追記(true)or上書き(false), 第3引数→エンコード
        StreamWriter sw = new StreamWriter(@"Assets/Resources/stage3.csv", false, Encoding.GetEncoding("Shift_JIS"));
        for (int i = 0; i < fieldCreate.csvDatas.Count; i++)
        {
            for (int j = 0; j < fieldCreate.count; j++)
            {
                //  string s1= string.Join(",", fieldCreate.csvDatas[i][j]);
                sw.Write(fieldCreate.csvDatas[i][j]+ ',');//，単位で入力
               // sw.WriteLine(s1);
            }
            sw.WriteLine();//改行
        }
      
        sw.Close();

        // ファイル読み込み
        // 引数説明：第1引数→ファイル読込先, 第2引数→エンコード
        StreamReader sr = new StreamReader(@"Assets/Resources/stage3.csv", Encoding.GetEncoding("Shift_JIS"));
        string line;
        // 行がnullじゃない間(つまり次の行がある場合は)、処理をする
        while ((line = sr.ReadLine()) != null)
        {
            // コンソールに出力
            Debug.Log(line);
        }
        // StreamReaderを閉じる
        sr.Close();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
