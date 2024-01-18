using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatHandler : MonoBehaviour
{
    [SerializeField] private CharacterStat baseStats;
    public CharacterStat CurrentStates { get; private set; }
    public List<CharacterStat> statsModifers = new List<CharacterStat>();

    private void Awake()
    {
        UpdateCharacterStats();
    }

    private void UpdateCharacterStats()
    {
        AttackSO attackSo = null;
        if(baseStats.attackSo != null)
        {
            attackSo = Instantiate(baseStats.attackSo);
        }

        CurrentStates = new CharacterStat { attackSo = attackSo };
        CurrentStates.statsChangeType = baseStats.statsChangeType;
        CurrentStates.maxHealth = baseStats.maxHealth;
        CurrentStates.speed = baseStats.speed;  
    }
}
