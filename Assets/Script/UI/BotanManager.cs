using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BotanManager : MonoBehaviour
{
    [SerializeField]
    GameObject NPCUI;
    Button NpcButton;
    InstantiateObj NpcIns;
    [SerializeField]
    GameObject TowerUI;
    Button towerButton;
    InstantiateObj towerIns;
    void Start()
    {
        NpcButton = NPCUI.GetComponent<Button>();
        NpcIns = NPCUI.GetComponent<InstantiateObj>();
        towerButton = TowerUI.GetComponent<Button>();
        towerIns = TowerUI.GetComponent<InstantiateObj>();
    }

    // Update is called once per frame
    void Update()
    {

        if (towerIns.botanflag)//ボタンが押された場合すべてのボタンが押されなくなる
        {

            towerButton.interactable = false;
            NpcButton.interactable = false;

        }
        else if (!towerIns.botanflag)
        {
            towerButton.interactable = true;
            NpcButton.interactable = true;
        }
        /* if (!instantiateObj[i].botanflag)//ボタンを押せるようにする
         {
             for (int j = 0; j <array; j++)
             {
                 button[j].interactable = true;
             }
         }*/


    }
}
