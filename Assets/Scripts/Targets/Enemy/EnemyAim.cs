using Player;
using UnityEngine;

namespace Targets.Enemy
{
    public class EnemyAim : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                var playerStatus = other.GetComponent<PlayerStatus>();
                playerStatus.TakeDamage(10);
            }
        }
    }
}
