using Godot;
using System;

public class Mob : KinematicBody2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var animSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		animSprite2D.Playing = true;
		string[] mobTypes = animSprite2D.Frames.GetAnimationNames();
		animSprite2D.Animation = mobTypes[GD.Randi() % mobTypes.Length];
	}
	
	public void OnVisibilityNotifier2DScreenExited()
	{
		QueueFree();
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
