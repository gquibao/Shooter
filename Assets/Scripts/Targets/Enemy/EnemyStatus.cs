using System.Collections;
using System.Collections.Generic;
using Targets;
using UnityEngine;

public class EnemyStatus : Target
{
    private float _damage;
    void Start()
    {
        Life = targetData.life;
        _damage = targetData.damage;
    }
}
