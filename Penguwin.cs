using Godot;
using System;

public class Penguwin : KinematicBody2D
{
	Vector2 smer;
	float rychlostPohybu = 550;

	//int score = 0 # raw y distance traveled
	//int actual_score = 0 # y distance divided by 10

	float gravitace = 110;
	float maxRychlostPadu = 1000;
	float minRychlostPadu = 5;
	float silaSkoku = 1000;
	bool skocil = false;
	int score = 0;

	public Label scoreText;

	Sprite sprite;
	AnimationPlayer animacePengwina; 
	public override void _Ready()
	{
		scoreText = (Label)GetNode("Label");
		scoreText.Text = "0";
		sprite = (Sprite)GetNode("Sprite");
		animacePengwina = (AnimationPlayer)GetNode("AnimationPlayer");
	}
	private void _on_Sprite_body_entered(object body)
	{
		score += 1;
		scoreText.Text = score.ToString();
	}
	private void _on_Area2D_body_entered(object body)
	{
   		GetTree().ReloadCurrentScene();
	}
	public override void _PhysicsProcess(float delta)
	{

		//Gravitace
		smer.y += gravitace;
		if (smer.y > maxRychlostPadu)
		{
			smer.y = maxRychlostPadu;
		}
		if (IsOnFloor())
		{
			smer.y = minRychlostPadu;
		}

		

		//Pohyb tucnacka
		smer.x = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
		smer.x *= rychlostPohybu;

		//scoreText.Text = 

		//Skok tucniaka

		if (IsOnFloor() && Input.IsActionJustPressed("jump"))
		{
			skocil = true;
			smer.y = -silaSkoku;
		}
		else
		if (skocil && Input.IsActionJustPressed("jump"))
		{
			skocil = false;
			smer.y = -silaSkoku;
		}

		//Otaceni tucnacka
		if (smer.x > 0)
		{
			sprite.FlipH = false;
		}
		else if (smer.x < 0)
		{
			sprite.FlipH = true;
		}

		if (IsOnFloor() && smer.x == 0)
		{
			animacePengwina.Play("stojici");
		}
		else if (IsOnFloor() && smer.x != 0)
		{
			animacePengwina.Play("Chuze");
		}
		else
		{
			animacePengwina.Play("Skok");
		}

		smer = MoveAndSlide(smer, Vector2.Up);

		

	}


}




