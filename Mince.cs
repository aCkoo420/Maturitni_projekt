using Godot;
using System;

public class Mince : Area2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	void _on_Mince_body_entered(Node node)
	{
		QueueFree();
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	

	//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	//  public override void _Process(float delta)
	//  {
	//      
	//  }
}






