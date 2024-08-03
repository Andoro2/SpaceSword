using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceArrowCollider : MonoBehaviour
{
    public GameObject m_ExplosionVFX;
    public float m_ArrowDamage = 5f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(m_ArrowDamage);
            Instantiate(m_ExplosionVFX, collision.transform.position, Quaternion.identity);
        }
    }
}
