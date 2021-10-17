using Godot;
using System;

public class Penguwin : KinematicBody2D
{
	Vector2 smer;
	float rychlostPohybu = 500;

	float gravitace = 90;
	float maxRychlostPadu = 1000;
	float minRychlostPadu = 5;
	float silaSkoku = 1500;
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

}

