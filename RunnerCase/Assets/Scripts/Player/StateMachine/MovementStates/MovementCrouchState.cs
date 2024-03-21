using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCrouchState : PlayerState
{
	public MovementCrouchState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
	{

	}

	public override void EnterState()
	{
		base.EnterState();
		Debug.Log("Crouch State");
	}

	public override void ExitState()
	{
		base.ExitState();
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();

		player.MovePlayer();
	}

	public override void UpdateState()
	{
		base.UpdateState();

		if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
		{
			player.Crouch(1f);
			player.PlayerStateMachine.ChangeState(player.MovementIdleState);
		}
	}
}
