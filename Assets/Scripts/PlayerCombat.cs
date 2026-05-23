using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float attackRange = 1.5f;
    public KeyCode attackKey = KeyCode.Space;

    void Update()
    {
        if (Input.GetKeyDown(attackKey))
        {
            Attack();
        }
    }

    void Attack()
    {
        // 攻撃音を鳴らす
        if (AudioManager.Instance != null) AudioManager.Instance.PlayAttack();

        Collider[] hits = Physics.OverlapSphere(transform.position, attackRange);

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                // 敵撃破音を鳴らす
                if (AudioManager.Instance != null) AudioManager.Instance.PlayEnemyDeath();

                Destroy(hit.gameObject);
                GameManager.Instance.AddScore(10);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
