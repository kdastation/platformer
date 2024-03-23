using System.Collections;
using System.Collections.Generic;
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
       _rigidbody.velocity =  new Vector2(_direaction.x * _speed, _rigidbody.velocity.y);

        var isJumping = _direaction.y > 0;

        var isGrounded = IsGrounded();

        if (isJumping)
        {
            if (isGrounded)
            {
                _rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
            }
            
        } else if (_rigidbody.velocity.y > 0)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * 0.5f);
        }

        _animator.SetBool(RunningAnimationKey, _direaction.x  != 0);
        _animator.SetBool(IsGroundedAnimationKey, isGrounded);
        _animator.SetFloat(VelocityYAnimationKey, _rigidbody.velocity.y);

        UpdateSpriteDirection();
    }


    private void UpdateSpriteDirection() {
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
