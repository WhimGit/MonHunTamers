using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildMonsters : MonoBehaviour
{
    [SerializeField] Monster wildMonster;

    public Monster GetWildMonster()
    {
        var wildMon = wildMonster;
        wildMon.Init();
        return wildMon;
    }
}
