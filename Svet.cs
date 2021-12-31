using Godot;
using System;

public class Svet : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.

   

	public override void _Ready()
	{
	
	}
		private void _on_OnePlayer_pressed()
	{
		GetNode<KinematicBody2D>("Penguwin2").Hide();
		GetNode<Button>("OnePlayer").Hide();
		
	}

	private void _on_Button_pressed()
	{
		GetTree().ChangeScene("res://Svet2.tscn");
	}
	
		
		private void _on_Continue_pressed()
	{
		GetTree().Paused = false;
		GetNode<Button>("Quit").Hide();
		GetNode<Button>("Continue").Hide();
	}
  
 /* public override void _Process(float delta)
  {
	 
 	}*/
}















