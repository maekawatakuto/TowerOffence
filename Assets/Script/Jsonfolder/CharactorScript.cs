using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharactorScript
{
    public List<Charactor> charactor_list;
    public List<Object> object_list;
        
}
[Serializable]
public class Charactor
{
    public string name;
    public int STR;
    public int DEF;
    public int HP;
    public float AS;
}
[Serializable]
public class Object
{
    public string name;
    public int STR;
    public int HP;
    public float AS;
}
