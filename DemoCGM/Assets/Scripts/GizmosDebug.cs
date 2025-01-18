using Unity.VisualScripting;
using UnityEngine;

public class GizmosDebug : MonoBehaviour
{
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward * 10);
        }
}