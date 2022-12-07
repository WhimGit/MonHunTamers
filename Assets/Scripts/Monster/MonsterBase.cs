using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "Monster/Create new monster")]
public class MonsterBase : ScriptableObject
{
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;

    //BattleSprites
    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    //Dual typing
    [SerializeField] MonsterType type1;
    [SerializeField] MonsterType type2;

    //Base Stats
    [SerializeField] int maxHp;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int eleAttack;
    [SerializeField] int eleDefense;
    [SerializeField] int speed;

    [SerializeField] List<LearnableMove> learnableMoves;

    public string Name { get { return name; } }

    public string Description { get { return description; } }

    public int MaxHp { get { return maxHp; } }

    public int Attack { get { return attack; } }

    public int Defense { get { return defense; } }

    public int EleAttack { get { return eleAttack; } }

    public int EleDefense { get { return eleDefense; } }

    public int Speed { get { return speed; } }

    public Sprite FrontSprite { get { return frontSprite; } }

    public Sprite BackSprite { get { return backSprite; } }

    public List<LearnableMove> LearnableMoves { get { return learnableMoves; } }
}

[System.Serializable]
public class LearnableMove
{
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;

    public MoveBase Base { get { return moveBase; } }

    public int Level { get { return level; } }
}

public enum MonsterType
{
    //Pokemon types as placeholders until more research on monster hunter types and weaknesses/
    None,
    Normal,
    Fire,
    Water,
    Electric,
    Grass,
    Ice,
    Fighting,
    Poison,
    Ground,
    Flying,
    Psychic,
    Bug,
    Rock,
    Dark,
    Dragon
}
