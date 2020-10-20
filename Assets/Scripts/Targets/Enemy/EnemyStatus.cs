using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay;
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

    private void OnDestroy()
    {
        GameManager.AddPoints(20);
    }
}
