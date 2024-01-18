using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsChangeType
{
    Add,
    Multiple,
    Override,
}

[Serializable]
public class CharacterStat 
{
    public StatsChangeType statsChangeType;
    [Range(0, 100)] public int maxHealth;
    [Range(1f, 20f)] public int speed;

    //공격 데이터
    public AttackSO attackSo;
}
