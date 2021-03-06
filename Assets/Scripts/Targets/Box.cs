﻿using Gameplay;
using Player;

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
            if (!GameManager.IsGameRunning) return;
            GameManager.AddPoints(10);
            _playerStatus.PickupAmmo();
        }
    }
}
