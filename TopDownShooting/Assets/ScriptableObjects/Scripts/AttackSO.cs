using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="DefaultAttackData", menuName = "TopDownController/Attacks/Default",order = 0)]
public class AttackSO: ScriptableObject
{
    [Header("Attack Inof")]
    public float size;
    public float delay;
    public float power;
    public float speed;
    public LayerMask target;

    [Header("Knok back Info")]
    public bool isOnKnockback;
    public float knockbackPower;
    public float knockbackTime;
}
