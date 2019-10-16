using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavBakeSystem : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshSurface surface;
    void Start()
    {
        GetComponent<NavMeshSurface>().BuildNavMesh();
      //  surface =GetComponent<NavMeshSurface>();
     //   surface.BuildNavMesh();
    }

}
