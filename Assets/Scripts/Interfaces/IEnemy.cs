using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    // Returns life points of the enemy.
    void IncreaseSpeed(float amount);

    // Increase the speed of the enemy.
    void UpdateLifePoints(float amount);

    // Update life points of the enemy.
    float GetLifePoints();
}