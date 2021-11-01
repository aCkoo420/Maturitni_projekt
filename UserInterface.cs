using Godot;
using System;

public class UserInterface : Control
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}
	
	public class ScoreLabel : Label
{
	private int _score = 0;
}

public void OnGoodJump()
{
	_score += 1;
	Text = string.Format("Score: {0}", _score);
}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
