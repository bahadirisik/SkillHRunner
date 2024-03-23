using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public int Health { get; set; }
    public int CurrentHealth { get; set; }

    public void DecreaseHealth(int amount);
    public void Die();

}
