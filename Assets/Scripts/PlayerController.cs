using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private static readonly KeyCode UP_KEY = KeyCode.UpArrow;
    private static readonly KeyCode DOWN_KEY = KeyCode.DownArrow;
    private static readonly KeyCode RIGHT_KEY = KeyCode.RightArrow;
    private static readonly KeyCode LEFT_KEY = KeyCode.LeftArrow;

    private Animator _animator;
    private Rigidbody2D _rigidbody;

    private float _idleClock;
    private bool _idle;

    public int StepSize;
    public float StepDuration;

	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!_idle && Time.fixedTime >= _idleClock)
        {
            _animator.SetBool("Idle", true);
            _idle = true;
            _rigidbody.velocity = new Vector2(0, 0);
        }

        if (_idle)
            ManageMovement();
	}

    private void ManageMovement()
    {
        var velocity = StepSize / StepDuration;

        if (Input.GetKey(RIGHT_KEY))
        {
            _rigidbody.velocity = new Vector2(velocity, 0);
            _animator.Play("Caminar_Derecha");
        }
        else if (Input.GetKey(UP_KEY))
        {
            _rigidbody.velocity = new Vector2(0, velocity);
            _animator.Play("Caminar_Atras");
        }
        else if (Input.GetKey(LEFT_KEY))
        {
            _rigidbody.velocity = new Vector2(-velocity, 0);
            _animator.Play("Caminar_Izquierda");
        }
        else if (Input.GetKey(DOWN_KEY))
        {
            _rigidbody.velocity = new Vector2(0, -velocity);
            _animator.Play("Caminar_Frente");
        }
        else
            return;

        _idle = false;
        _animator.SetBool("Idle", false);
        _idleClock = Time.fixedTime + StepDuration;
    }
}
