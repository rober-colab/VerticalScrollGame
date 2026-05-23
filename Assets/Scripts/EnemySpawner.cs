using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // 敵のプレハブ
    public float spawnInterval = 2f; // 何秒ごとに出現するか
    public float spawnRange = 5f;    // 横方向の出現範囲
    public float spawnDistance = 15f; // プレイヤーの前方何ユニットに出現するか

    private Transform player;
    private float timer;

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

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        // プレイヤーの前方にランダムな横位置で出現
        float randomX = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(
            player.position.x + randomX,
            0.5f,
            player.position.z + spawnDistance
        );

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
