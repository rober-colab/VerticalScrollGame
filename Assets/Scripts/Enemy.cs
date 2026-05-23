using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;       // 敵の移動速度
    private Transform player;      // プレイヤーの位置

    void Start()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        // プレイヤーに向かって移動
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    // プレイヤーと衝突したとき
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.TakeDamage(1); // HPを1減らす
            Destroy(gameObject);                 // 敵も消える
        }
    }
}
