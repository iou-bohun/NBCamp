using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem _imPactParticleSystem;

    public static ProjectileManager Instance;

    [SerializeField] private GameObject testOb;
    private void Awake()
    {
        Instance = this;
    }

    public void ShootBullet(Vector2 startPosition, Vector2 dir, RangedAttackData attackData)
    {
        GameObject obj = Instantiate(testOb);
        obj.transform.position = startPosition;

    }
}
