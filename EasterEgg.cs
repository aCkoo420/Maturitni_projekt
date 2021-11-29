using Godot;
using System;

public class EasterEgg : Area2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private void _on_EasterEgg_body_entered(object body)
{
	GetNode<Label>("Label").Text = "YOU HAVE FOUND AN EASTER EGG";
}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}
	
	/// Called every frame. 'delta' is the elapsed time since the previous frame.
	//  public override void _Process(float delta)
	//  {
	//      
	//  }
}



