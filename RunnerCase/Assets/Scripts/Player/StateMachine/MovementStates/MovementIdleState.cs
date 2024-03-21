using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementIdleState : PlayerState
{
	public MovementIdleState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
	{

	}

	public override void EnterState()
	{
		base.EnterState();
		Debug.Log("Idle State");
	}

	public override void ExitState()
	{
		base.ExitState();
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();

		player.GroundCheck();
		player.MovePlayer();
	}

	public override void UpdateState()
	{
		base.UpdateState();

		//Sadece Idle'den zýplamaya geçebiliyoruz
		if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
		{
			player.Jump();
			player.PlayerStateMachine.ChangeState(player.MovementJumpState);
		}

		//Sadece Idle'den eðilmeye geçebiliyoruz
		if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
		{
			player.Crouch(0.5f);
			player.PlayerStateMachine.ChangeState(player.MovementCrouchState);
		}
	}
}
