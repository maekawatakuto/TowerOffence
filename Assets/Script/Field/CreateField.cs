using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DefaultExecutionOrder(-100)]
public class CreateField : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject TowerPrefav;
    [SerializeField]
    private GameObject SoldierPrefav;
    [SerializeField]
    private GameObject cube;
    public List<GameObject> fieldObj;
    public GameObject[,] CSVarray;//csvの形でデータ格納
    [SerializeField]
    public int Width;
    [SerializeField]
    public int Depth;
    [SerializeField]
    CSVRequest csv;
    private int count;
    public bool InstanceMap;//mapが生成されたかどうかをboolで判別
    void Awake()
    {
        InstanceMap = false;
        fieldObj = new List<GameObject>();
        CSVarray = new GameObject[Depth, Width];
        count = 0;
        for (int i = 0; i < Depth; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                GameObject obj = Instantiate(cube, new Vector3(i, 0, j), Quaternion.identity);
                CSVarray[i, j] = obj;
                fieldObj.Add(Instantiate(obj));
                string strcount = count.ToString();
                fieldObj[count].name = strcount;
                fieldObj[count].transform.parent = transform;

                count += 1;
            }
        }
        StartCoroutine(request());
    }
    IEnumerator request()
    {
        yield return csv.csvDatas;
        Debug.Log(csv.csvDatas[5][17]);
        for (int i = 0; i < Depth; i++)
        {
           for (int j = 0; j < Width; j++)
            {
               
                if (csv.csvDatas[i][j] =="1")
                {
                    GameObject Obj = Instantiate(TowerPrefav, CSVarray[i, j].transform.position, Quaternion.identity);
                  //  Debug.Log(CSVarray[i, j]);
                }
                if(csv.csvDatas[i][j]=="2")
                {
                    GameObject obj = Instantiate(SoldierPrefav, CSVarray[i, j].transform.position, Quaternion.identity);
                }
            }
        }
        InstanceMap = true;
    }

}
