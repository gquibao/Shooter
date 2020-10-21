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
            var pos = Camera.main.WorldToScreenPoint(transform.position);
            var mousePosition = Input.mousePosition - pos;
            mousePosition.z = 1;
            lineRenderer.SetPosition(1, mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                _playerStatus.CurrentWeapon.Fire(transform.position, mousePosition, _playerStatus.attackLayerMask);
            }

            if (Input.GetMouseButtonDown(1))
            {
                _playerStatus.MeleeAttack(mousePosition);
            }
        }
    }
}
