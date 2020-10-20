using System;
using Gameplay;
using UnityEngine;
using Weapons;

namespace Targets
{
    public class Box : Target
    {
        private PlayerStatus _playerStatus;

        private void Start()
        {
            _playerStatus = FindObjectOfType<PlayerStatus>();
            Life -= targetData.life;
        }

        private void OnDestroy()
        {
            GameManager.AddPoints(10);
            _playerStatus.PickupAmmo();
        }
    }
}
