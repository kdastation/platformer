using UnityEngine;

public class DestroyObjectComponent : MonoBehaviour
{
    [SerializeField] private GameObject _object;

    public void DestroyObject()
    {
        Destroy(_object);

    }
}
