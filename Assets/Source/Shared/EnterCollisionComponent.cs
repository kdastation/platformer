using UnityEngine;
using UnityEngine.Events;

public class EnterCollisionComponent : MonoBehaviour
{
    [SerializeField] private string _tag;

    [SerializeField] private UnityEvent<GameObject> _Action;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(_tag))
        {
            _Action?.Invoke(collision.gameObject);
        }
    }
}
