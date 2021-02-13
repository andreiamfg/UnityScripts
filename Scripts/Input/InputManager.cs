using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputEvent
{
	public string PlayerId;
	public InputType Input;
}

public enum InputType
{
	Up,
	Down,
	Left,
	Right,
}

public class PlayerInput
{
	public float Horizontal;
	public float Vertical;
	public bool Jump;
}

public class InputManager : Singleton<InputManager> 
{
	public static event Action<InputEvent>  OnInputEvent;
	bool m_doVertical = false;
	bool m_doHorizontal = false;

	void Update () 
	{
		SendInputForPlayer("1");
		SendInputForPlayer("2");
	}

	void SendInputForPlayer(string playerId)
	{
		float fVertical = Input.GetAxis(InputBank.VERTICAL+playerId);
		float fHorizontal = Input.GetAxis(InputBank.HORIZONTAL+playerId);

		InputEvent input = new InputEvent();
		input.PlayerId = playerId;

		if(fVertical > 0.1)
		{
			if(!m_doVertical)
				input.Input = InputType.Up;
			m_doVertical = true;
		}
		else if(fVertical < -0.1)
		{
			if(!m_doVertical)
				input.Input = InputType.Down;
			m_doVertical = true;
		}
		else if(fHorizontal > 0.1 )
		{
			if(!m_doHorizontal)
				input.Input = InputType.Right;
			m_doHorizontal = true;
		}
		else if(fHorizontal < -0.1 )
		{
			if(!m_doHorizontal)
				input.Input = InputType.Left;
			m_doHorizontal = true;
		}
		else
		{
			m_doVertical = false;
			m_doHorizontal = false;
		}

		SendControllerEvent(input);
	}

	public PlayerInput GetMoveInputForPlayer(string playerId)
	{
		PlayerInput input = new PlayerInput ();
		input.Horizontal = Input.GetAxis(InputBank.HORIZONTAL+playerId);
		input.Vertical = Input.GetAxis (InputBank.VERTICAL+playerId);
		input.Jump = Input.GetButtonDown(InputBank.JUMP+playerId);
		return input;
	}

	void SendControllerEvent(InputEvent inputEvent)
	{
		if(OnInputEvent != null)
			OnInputEvent(inputEvent);
	}
}
