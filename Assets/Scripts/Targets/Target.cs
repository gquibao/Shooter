using System;
using UnityEngine;

namespace Targets
{
    public class Target : MonoBehaviour, ITarget
    {
        [SerializeField] protected TargetData targetData;
        protected float Life;

        public void TakeDamage(float damageTaken)
        {
            Debug.Log($"{gameObject.name} took {damageTaken} damage");
            Life -= damageTaken;
            if (Life <= 0) Destroy(gameObject);
        }
    }
}
