using Godot;
using System;

public class Penguwin : KinematicBody2D
{
	Vector2 smer;
	float rychlostPohybu = 500;

	//int score = 0 # raw y distance traveled
	//int actual_score = 0 # y distance divided by 10

	float gravitace = 100;
	float maxRychlostPadu = 1000;
	float minRychlostPadu = 5;
	float silaSkoku = 1000;
	bool skocil = false;

	Sprite sprite;
	AnimationPlayer animacePengwina; 
	public override void _Ready()
	{
		sprite = (Sprite)GetNode("Sprite");
		animacePengwina = (AnimationPlayer)GetNode("AnimationPlayer");
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

		/*if(position.y < score) { 
			score = position.y;
			printf('new highscore: ' + str(score / 10));
			actual_score = score / 10;
			camera.position.y = position.y;
			}
		*/
		
		//Pohyb tucnacka
		smer.x = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
		smer.x *= rychlostPohybu;

		//Skok tucniaka
		
		if (IsOnFloor() && Input.IsActionJustPressed("jump"))
		{
			skocil = true;
			smer.y = -silaSkoku;
		}else
		if(skocil && Input.IsActionJustPressed("jump"))
		{
			skocil = false;
			smer.y = -silaSkoku;
		}

		//Otaceni tucnacka
		if (smer.x > 0)
		{
			sprite.FlipH = false;
		}else if(smer.x<0)
		{
			sprite.FlipH = true;
		}

		if (IsOnFloor() && smer.x == 0)
		{
			animacePengwina.Play("stojici");
		}else if(IsOnFloor() && smer.x != 0)
		{
			animacePengwina.Play("Chuze");
		}
		else
		{
			animacePengwina.Play("Skok");
		}

		smer = MoveAndSlide(smer, Vector2.Up);
		
		

	}
	public void GoodJump()
	{
		// ...
		// We connect the mob to the score label to update the score upon squashing one.
		smer.Vector2(nameof(Mob.Squashed), GetNode<ScoreLabel>("UserInterface/ScoreLabel"), nameof(ScoreLabel.OnMobSquashed));
	}

	/*public void OnMobTimerTimeout()
	{
		// ...
		// We connect the mob to the score label to update the score upon squashing one.
		mob.Connect(nameof(Mob.Squashed), GetNode<ScoreLabel>("UserInterface/ScoreLabel"), nameof(ScoreLabel.OnMobSquashed));
	}*/

}

