using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
	public int Speed = 100;

	private AnimatedSprite2D animatedSprite;

	public override void _Ready()
	{
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 direction = Vector2.Zero;

		if (Input.IsActionPressed("ui_right"))
			direction.X += 1;
		if (Input.IsActionPressed("ui_left"))
			direction.X -= 1;
		if (Input.IsActionPressed("ui_down"))
			direction.Y += 1;
		if (Input.IsActionPressed("ui_up"))
			direction.Y -= 1;

		Velocity = direction.Normalized() * Speed;
		MoveAndSlide();

		// Анимация
		if (direction != Vector2.Zero)
		{
			if (Math.Abs(direction.X) >= Math.Abs(direction.Y))
			{
				animatedSprite.FlipH = direction.X < 0;
				animatedSprite.Play("walk_side");
			}
			else
			{
				animatedSprite.FlipH = false;
				animatedSprite.Play("walk_side");
			}
		}
		else
		{
			animatedSprite.Stop();
		}
	}
}
