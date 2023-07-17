using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _maxHitPoints = 5;
    [SerializeField] private int _difficultyRamp = 1;

    private int _currentHitPoint;
    private Enemy _enemy;

    private void OnEnable()
    {
        _currentHitPoint = _maxHitPoints;
    }

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        _currentHitPoint--;

        if (_currentHitPoint <= 0)
        {
            _enemy.RewardGold();
            gameObject.SetActive(false);

            _maxHitPoints += _difficultyRamp;
        }
    }
}
