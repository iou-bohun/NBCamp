using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem _imPactParticleSystem;

    public static ProjectileManager Instance;

    private ObjectPool objectPool;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        objectPool = GetComponent<ObjectPool>();
    }

    public void ShootBullet(Vector2 startPosition, Vector2 dir, RangedAttackData attackData)
    {
        GameObject obj = objectPool.SpawnFromPool(attackData.bulletNameTag);
        obj.transform.position = startPosition;
        RangeAttackController attackController = obj.GetComponent<RangeAttackController>();
        attackController.InitializeAttack(dir, attackData, this);

        obj.SetActive(true);
    }
}
