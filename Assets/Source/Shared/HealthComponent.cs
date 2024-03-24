using UnityEngine;
using UnityEngine.Events;



public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int _health;

    [SerializeField] private UnityEvent _OnTakeDamage;

    [SerializeField] private UnityEvent _OnDie;


    public void TakeDamage(int damage)
    {
        _health -= damage;
        _OnTakeDamage?.Invoke();

        if (IsDie(_health))
        {
            _OnDie?.Invoke();
        }
    }

    private bool IsDie(int health)
    {
        return health <= 0;
    }
}

