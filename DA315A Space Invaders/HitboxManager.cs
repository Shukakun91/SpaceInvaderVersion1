using System;
using Microsoft.Xna.Framework;

public class HitboxManager
{
	public HitboxManager()
	{

	}

	public bool CheckCollision(Rectangle hitboxA, Rectangle hitboxB)
	{
		return (hitboxA.Intersects(hitboxB));
    }
}
