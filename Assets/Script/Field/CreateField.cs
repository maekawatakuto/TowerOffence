using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DefaultExecutionOrder(-100)]
public class CreateField : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject cube;
    public List<GameObject> fieldObj;
    [SerializeField]
    public int Width;
    [SerializeField]
    public int Depth;
    private int count;
    public bool InstanceMap;//mapが生成されたかどうかをboolで判別
    void Awake()
    {
        InstanceMap = false;
        fieldObj = new List<GameObject>();
        count = 0;
        for(int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Depth; j++)
            {
              
               fieldObj.Add(Instantiate(cube, new Vector3(i, 0, j), Quaternion.identity));
               string strcount = count.ToString();
                fieldObj[count].name = strcount;
                fieldObj[count].transform.parent = transform;
                count += 1;
                
            }
        }
        InstanceMap = true;

    }


}
