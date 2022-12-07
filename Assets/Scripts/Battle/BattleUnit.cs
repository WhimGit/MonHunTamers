using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] MonsterBase monBase;
    [SerializeField] int level;
    [SerializeField] bool isPlayerUnit;

    public Monster Monster { get; set; }

    public void Setup()
    {
        Monster = new Monster(monBase, level);
        if (isPlayerUnit)
        {
            GetComponent<Image>().sprite = Monster.Base.BackSprite;
        }
        else
        {
            GetComponent<Image>().sprite = Monster.Base.FrontSprite;
        }
    }
}
