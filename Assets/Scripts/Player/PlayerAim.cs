using System;
using UnityEngine;

namespace Player
{
    public class PlayerAim : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;
        private PlayerStatus _playerStatus;

        private void Awake()
        {
            Cursor.visible = false;
            _playerStatus = GetComponent<PlayerStatus>();
        }

        private void Update()
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 1;
            lineRenderer.SetPosition(1, mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                _playerStatus.currentWeapon.Fire(transform.position, mousePosition);
            }

            if (Input.GetMouseButtonDown(1))
            {
                _playerStatus.MeleeAttack(mousePosition);
            }
        }
    }
}
