using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[DefaultExecutionOrder(-1)]
public class BakeSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    NavMeshSurface surface;
   
    void Awake()
    {
        surface.BuildNavMesh();
     
    }

}
