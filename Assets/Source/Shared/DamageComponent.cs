using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    [SerializeField] private int _value;

    public void ApplyDamage(GameObject target)
    {
        var healtComponent = target.GetComponent<HealthComponent>();

        if (healtComponent != null)
        {
            healtComponent.TakeDamage(_value);
        }
    }
}
