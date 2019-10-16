﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class FieldCreate : MonoBehaviour
{
    TextAsset csvFile;
    [SerializeField]
    GameObject cube;
    int Width;
    int Height;
    [SerializeField]
    private string CsvTextName;
    int count;
    int nameCount;//objの名前
    public List<string[]> csvDatas;
    public List<GameObject[]> FieldObject;
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
        for(int i = 0; i < csvDatas.Count;i++)
        {
            for(int j = 0; j<count;j++)
            {
             
                GameObject Ins = Instantiate(cube, new Vector3(i, 0, j), Quaternion.identity);
                FieldObject[i][j] = Ins;
               Ins.name = nameCount.ToString();
                nameCount += 1;
            }
        }
        Width=nameCount;
        Height=csvDatas.Count;
    }

    void Update()
    {
        
    }
}