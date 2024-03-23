using UnityEngine;
using UnityEngine.InputSystem;

public class HeroInputReader : MonoBehaviour
{

    [SerializeField] private Hero _hero;

    public void OnHorizontalMovement(InputValue ctx)
    {
        var direction = ctx.Get<Vector2>();
        _hero.SetDirection(direction);
    }
}
