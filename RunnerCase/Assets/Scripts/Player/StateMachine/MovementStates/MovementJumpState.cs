using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementJumpState : PlayerState
{
	public MovementJumpState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
	{

	}

	public override void EnterState()
	{
		base.EnterState();
		Debug.Log("Jump State");
	}

	public override void ExitState()
	{
		base.ExitState();
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();

		player.MovePlayer();
		player.GroundCheck();
	}

	public override void UpdateState()
	{
		base.UpdateState();

		if (player.IsMovingDown() && player.IsGrounded)
		{
			player.PlayerStateMachine.ChangeState(player.MovementIdleState);
		}
	}
}
