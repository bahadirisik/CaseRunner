using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
	[field: SerializeField] public int Health { get; set; } = 100;
	public int CurrentHealth { get; set; }

	#region Movement Variables

	private Rigidbody2D rb;
	private CapsuleCollider2D col;
	private float moveSpeed = 3f;
	private Vector2 frameVelocity = new Vector2(1, 0);
	private float horizontalAccleration = 150f;

	[field : SerializeField] public bool IsGrounded { get; set; }
	[SerializeField] private LayerMask groundLayer;
	private float groundForce = -1f;
	private float groundDistance = 0.05f;
	private float jumpForce = 15f;
	private float verticalAccleration = 65f;
	private float fallSpeed = 25f;

	#endregion

	#region State Machine

	public PlayerStateMachine PlayerStateMachine { get; set; }
	public MovementIdleState MovementIdleState { get; set; }
	public MovementJumpState MovementJumpState { get; set; }
	public MovementCrouchState MovementCrouchState { get; set; }

	#endregion

	private void Awake()
	{
		PlayerStateMachine = new PlayerStateMachine();

		MovementIdleState = new MovementIdleState(this, PlayerStateMachine);
		MovementJumpState = new MovementJumpState(this, PlayerStateMachine);
		MovementCrouchState = new MovementCrouchState(this, PlayerStateMachine);
	}

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		col = GetComponent<CapsuleCollider2D>();
		CurrentHealth = Health;

		PlayerStateMachine.Init(MovementIdleState);
	}

	void Update()
	{
		PlayerStateMachine.CurrentState.UpdateState();
	}

	private void FixedUpdate()
	{
		PlayerStateMachine.CurrentState.FixedUpdateState();

		HorizontalMovement();
		GravityApply();
		//GroundCheck();
	}

	#region PlayerMovement
	public void MovePlayer()
	{
		rb.velocity = frameVelocity * moveSpeed;
	}

	public void Crouch(float value)
	{
		transform.localScale = new Vector3(transform.localScale.x, value, transform.localScale.z);
	}

	#region Horizontal Movement
	private  void HorizontalMovement()
	{
		frameVelocity.x = Mathf.MoveTowards(frameVelocity.x, moveSpeed, horizontalAccleration * Time.fixedDeltaTime);
	}
	#endregion

	#region Vertical Movement
	private void GravityApply()
	{
		if (IsGrounded && frameVelocity.y <= 0f)
		{
			frameVelocity.y = groundForce;
		}
		else
		{
			float inAirGravity = verticalAccleration;
			frameVelocity.y = Mathf.MoveTowards(frameVelocity.y, -fallSpeed, inAirGravity * Time.fixedDeltaTime);
		}
	}

	public bool IsMovingDown()
	{
		return frameVelocity.y < 0;
	}
	#endregion

	#region Jump
	public void Jump()
	{
		if (IsGrounded)
		{
			frameVelocity.y = jumpForce;
		}
	}
	#endregion

	#region Ground Check
	public void GroundCheck()
	{
		bool groundHit = Physics2D.CapsuleCast(col.bounds.center, col.size, col.direction, 0, 
			Vector2.down, groundDistance, groundLayer);

		if (!IsGrounded && groundHit)
		{
			IsGrounded = true;
		}
		else if (IsGrounded && !groundHit)
		{
			IsGrounded = false;
		}
	}
	#endregion

	#endregion

	#region PlayerHealth
	public void DecreaseHealth(int amount)
	{
		CurrentHealth -= amount;

		if(CurrentHealth <= 0)
		{
			Die();
		}
	}

	public void Die()
	{
		GameMaster.Instance.LevelFailed();

		Destroy(gameObject);
	}

	public void IncreaseHealth(int amount)
	{
		CurrentHealth += amount;

		if(CurrentHealth >= Health)
		{
			CurrentHealth = Health;
		}
	}
	#endregion

}
