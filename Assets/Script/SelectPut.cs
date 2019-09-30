using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class SelectPut : MonoBehaviour
{
    [SerializeField]
   private CreateField createField;
    [SerializeField]
    private GameObject prefav;
    [SerializeField]
    StockScript stockScript;
    public List<int> north { get; private set; }
    public List<int> south { get; private set; }
    public List<int> east { get; private set; }
    public List<int> west { get; private set; }
   
    public List<GameObject> targetList;
    int width;
    int depth;
    int node;
    private float timer;
    void Start()
    {
        north = new List<int>();
        south = new List<int>();
        east = new List<int>();
        west = new List<int>();
        targetList = new List<GameObject>();
        node = 0;
        StartCoroutine(Coroutine());
    
    }
    IEnumerator Coroutine()
    {
        yield return createField.fieldObj;//fieldが生成されるまで待機
        width = createField.Width;
        depth = createField.Depth;

        ///正方形の地形の辺の情報をリストに格納
        for (int i = 0; i < width; i++)//北
        {
            north.Add(i);
            string str = i.ToString();
            GameObject target = GameObject.Find(str);
            targetList.Add(target);
            Renderer renderer = target.GetComponent<Renderer>();
            renderer.material.color = new Color(0, 0, 1);

        }
        for (int i = 1; i <= width; i++)//東
        {
            int i1 = i * depth - 1;
            east.Add(i1);
            string str = i1.ToString();
            GameObject target = GameObject.Find(str);
            targetList.Add(target);
            Renderer renderer = target.GetComponent<Renderer>();
            renderer.material.color = new Color(0, 0, 1);
        }
        for (int i = width * depth - 1; i > width * (depth - 1); i--)//南
        {
            south.Add(i);
            string str = i.ToString();
            GameObject target = GameObject.Find(str);
            targetList.Add(target);
            Renderer renderer = target.GetComponent<Renderer>();
            renderer.material.color = new Color(0, 0, 1);
        }

        for (int i = depth - 1; i >= 1; i--)//西
        {

            int i1 = i * width;
            west.Add(i1);
            string str = i1.ToString();
            GameObject target = GameObject.Find(str);
            targetList.Add(target);
            Renderer renderer = target.GetComponent<Renderer>();
            renderer.material.color = new Color(0, 0, 1);
        }
    }
    

    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.A))
        {
            node += 1;
        
            if (node >= targetList.Count)
            {
                node = 0;

            }
            BlockUpdate();
            ChangeSelecetColor();

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            node -= 1;     
            if (node < 0)
            {
                node = targetList.Count - 1;

            }
            BlockUpdate();
            ChangeSelecetColor();


        }

        if (Input.GetKeyDown(KeyCode.Space)&&timer>=0.5f)//連打できないようにする
        {
            timer = 0;
            if (stockScript.stk > 0)
            {
                stockScript.stk -= 1;
                InstanceNPC(prefav);
            }
            
        }


    }
    private void BlockUpdate()
    {
        foreach (var obj in targetList)
        {
            Renderer rder = obj.GetComponent<Renderer>();
            rder.material.color = new Color(0, 0, 1);
        }
    }
    private void ChangeSelecetColor()
    {
        Renderer renderer = targetList[node].GetComponent<Renderer>();
        renderer.material.color = new Color(1, 0, 0);
    }
    private void InstanceNPC(GameObject obj)
    {
        GameObject ins = Instantiate(obj, targetList[node].transform.position, Quaternion.identity);
    }
}
