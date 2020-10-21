using Gameplay;

namespace Targets.Enemy
{
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
            if(GameManager.IsGameRunning)
                GameManager.AddPoints(20);
        }
    }
}
