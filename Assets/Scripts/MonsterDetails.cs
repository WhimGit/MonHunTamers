using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterDetails : MonoBehaviour
{
    public Text LvlText;
    public int lvl;
    [SerializeField] MonsterParty playerParty;

    void Update()
    {
        lvl = playerParty.GetMonster().Level;
        LvlText.text = "LV: " + lvl;
    }
}
