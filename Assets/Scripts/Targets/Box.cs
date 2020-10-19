using System;
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
            _playerStatus.PickupAmmo();
        }
    }
}
