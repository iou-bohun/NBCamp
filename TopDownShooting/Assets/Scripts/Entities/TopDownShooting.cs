
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    private ProjectileManager _projectileManager;
    private TopDownPlayerController _controller;

    [SerializeField]private Transform projectileSpawnPosition;
    private Vector2 _aimDirecton = Vector2.right;


    private void Awake()
    {
        _controller = GetComponent<TopDownPlayerController>();
    }
    private void Start()
    {
        _projectileManager = ProjectileManager.Instance;
        _controller.OnAttackEvent += OnShot;
        _controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 newAimDir)
    {
        _aimDirecton = newAimDir;
    }
    private void OnShot(AttackSO attackSO)
    {
        RangedAttackData rangedAttackData = attackSO as RangedAttackData;
        float projectileAngleSpace = rangedAttackData.multipleProjectiontilesAngel;
        int numberOfProjectilePerShot = rangedAttackData.numberofProjectilesPerShot;
        float minAngle = -(numberOfProjectilePerShot / 2f) * projectileAngleSpace + 0.5f * rangedAttackData.multipleProjectiontilesAngel; ;

        for(int i = 0; i<numberOfProjectilePerShot; i++)
        {
            float angle = minAngle + projectileAngleSpace * i;
            float randomSpred = Random.Range(-rangedAttackData.spread, rangedAttackData.spread);
            angle += randomSpred;
            CreateProjectile(rangedAttackData, angle);
        }
    }
    private void CreateProjectile(RangedAttackData rangedAttackData, float angle)
    {
        // TODO
        _projectileManager.ShootBullet(projectileSpawnPosition.position, RotateVector2(_aimDirecton, angle), rangedAttackData);
    }

    private static Vector2 RotateVector2(Vector2 v, float degree)
    {
        return Quaternion.Euler(0, 0, degree) * v;
    }
}
