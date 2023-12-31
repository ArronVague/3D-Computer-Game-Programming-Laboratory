using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetic : MonoBehaviour
{
    public LayerMask m_MagneticLayers;
    public Vector3 m_Position;
    public float m_Radius = 4f;
    public float m_Force = 10f;

    void FixedUpdate()
    {
        Collider[] colliders;
        Rigidbody rigidbody;
        colliders = Physics.OverlapSphere(transform.position + m_Position, m_Radius, m_MagneticLayers);

        foreach (Collider collider in colliders)
        {
            rigidbody = (Rigidbody)collider.gameObject.GetComponent(typeof(Rigidbody));
            Debug.Log("get rigidbody");
            if (rigidbody == null)
            {
                continue;
            }
            Debug.Log("yes");
            rigidbody.AddExplosionForce(m_Force * -1, transform.position + m_Position, m_Radius);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + m_Position, m_Radius);
    }
}