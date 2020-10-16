using System;
using UnityEngine;

namespace Player
{
    public class PlayerAim : MonoBehaviour
    {
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                
            }
        }

        private void Fire()
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            RaycastHit2D hit;
            hit = Physics2D.Raycast(transform.position, mousePosition);
            if(hit.transform != null)
                Debug.Log(hit.transform.name);
        }
    }
}
