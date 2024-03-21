using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    int Health { get; set; }
    int CurrentHealth { get; set; }
    void DecreaseHealth(int amount);
    void IncreaseHealth(int amount);
    void Die();
}
