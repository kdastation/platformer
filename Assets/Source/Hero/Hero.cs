using UnityEngine;

public class Hero : MonoBehaviour
{

    [SerializeField] private Vector2 _direaction;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private LayerChecker _groundLayerChecker;
    [SerializeField] private Animator _animator;

    private SpriteRenderer _spirteRenderer;

    private bool _allowDoubleJump;

    private readonly static int RunningAnimationKey = Animator.StringToHash("is-running");
    private readonly static int IsGroundedAnimationKey = Animator.StringToHash("is-grounded");
    private readonly static int VelocityYAnimationKey = Animator.StringToHash("velocity-y");

    private void Awake()
    {
        _spirteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetDirection(Vector2 direction)
    {
        _direaction = direction;
    }

    private void FixedUpdate()
    {

        var xVelocity = _direaction.x * _speed;
        var yVelocity = CalculateYVelocity();

        _rigidbody.velocity = new Vector2(xVelocity, yVelocity);

        _animator.SetBool(RunningAnimationKey, _direaction.x != 0);
        _animator.SetBool(IsGroundedAnimationKey, IsGrounded());
        _animator.SetFloat(VelocityYAnimationKey, _rigidbody.velocity.y);

        UpdateSpriteDirection();
    }

    private float CalculateYVelocity()
    {
        var yVelocity = _rigidbody.velocity.y;

        var isJumpPressing = _direaction.y > 0;

        if (isJumpPressing)
        {
            yVelocity = CalculateJumpVelocity(yVelocity);
        }

        return yVelocity;
    }

    private float CalculateJumpVelocity(float yVelocity)
    {

        var isFalling = yVelocity <= 0.001f;
        if (!isFalling) return yVelocity;

        if (IsGrounded())
        {
            yVelocity += _jumpSpeed;
            _allowDoubleJump = true;
        }
        else if (_allowDoubleJump)
        {
            yVelocity = _jumpSpeed;
            _allowDoubleJump = false;
        }

        return yVelocity;
    }

    private void UpdateSpriteDirection()
    {
        if (_direaction.x > 0)
        {
            _spirteRenderer.flipX = false;
        }
        else if (_direaction.x < 0)
        {
            _spirteRenderer.flipX = true;
        }
    }

    private bool IsGrounded()
    {
        return _groundLayerChecker.IsToucningLayer;
    }
}
