using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKnowbackable
{
    void Knockback(Vector2 angle, float strenght, int direction);
}
