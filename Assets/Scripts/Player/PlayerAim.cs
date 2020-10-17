using System;
using UnityEngine;

namespace Player
{
    public class PlayerAim : MonoBehaviour
    {
        private PlayerStatus _playerStatus;

        private void Awake()
        {
            _playerStatus = GetComponent<PlayerStatus>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _playerStatus.currentWeapon.Fire(transform.position, GetMousePosition());
            }

            if (Input.GetMouseButtonDown(1))
            {
                _playerStatus.MeleeAttack(GetMousePosition());
            }
        }

        private Vector2 GetMousePosition()
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return mousePosition;
        }
    }
}
