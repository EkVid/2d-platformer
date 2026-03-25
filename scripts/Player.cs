
using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private const float Speed = 200.0f;
	private const float JumpVelocity = -300.0f;
	private AnimatedSprite2D character;
	private float direction;
	Vector2 velocity;


	public override void _Ready()
	{
		base._Ready();	
		character = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		velocity = Velocity;
		
		ApplyGravity(delta);
		HandleJump();
		HandleHorizontalMovement();
		UpdateAnimation();
		
		Velocity = velocity;
		MoveAndSlide();
	}

	private void ApplyGravity(double delta)
	{
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}
	}

	private void HandleJump()
	{
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}
	}

	private void HandleHorizontalMovement()
	{
		direction = Input.GetAxis("move_left", "move_right");
		if (direction != 0)
		{
			velocity.X = direction * Speed;
			character.FlipH = direction < 0;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}
	}
	
	private void UpdateAnimation()
	{
		string anim = direction != 0 ? "walk" : "idle";
		PlayAnimation(anim);
	}

	private void PlayAnimation(string animation)
	{
		if (character.Animation != animation)
			character.Play(animation);
	}
}
