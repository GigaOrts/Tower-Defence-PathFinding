using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] private Transform _weapon;
    [SerializeField] private ParticleSystem _projectileParticles;
    [SerializeField] private float _range = 15f;

    private Transform _target;

    private void Update()
    {
        FindClosestEnemy();

        if (_target == null)
        {
            Attack(false);
            return;
        }
            

        float targetDistance = Vector3.Distance(transform.position, _target.position);

        if (targetDistance <= _range)
        {
            AimWeapon();
            Attack(true);
        }
    }

    private void FindClosestEnemy()
    {
        Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);

        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (var enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if(targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        _target = closestTarget;
    }

    private void AimWeapon()
    {
        _weapon.LookAt(_target);
    }

    private void Attack(bool isActive)
    {
        var emissionModule = _projectileParticles.emission;
        emissionModule.enabled = isActive;
    }
}
