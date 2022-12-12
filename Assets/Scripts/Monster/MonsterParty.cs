using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterParty : MonoBehaviour
{
    [SerializeField] Monster monster;

    void Start()
    {
        monster.Init();
    }

    public Monster GetMonster()
    {
        return monster;
    }
}
