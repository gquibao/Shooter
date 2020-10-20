using UnityEngine;

namespace Targets
{
    public class Target : MonoBehaviour, ITarget
    {
        [SerializeField] protected TargetData targetData;
        protected float Life;

        public void TakeDamage(float damageTaken)
        {
            Life -= damageTaken;
            if (Life <= 0) Destroy(gameObject);
        }
    }
}
