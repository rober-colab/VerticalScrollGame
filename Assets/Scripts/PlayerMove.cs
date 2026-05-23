using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("移動設定")]
    public float moveSpeed = 5f;       // 左右の移動速度
    public float autoScrollSpeed = 4f; // 自動で前進するスピード

    void Update()
    {
        // 左右入力（A/D または ←→）
        float horizontal = Input.GetAxis("Horizontal");

        // 自動前進 + 左右移動
        Vector3 move = new Vector3(horizontal * moveSpeed, 0f, autoScrollSpeed) * Time.deltaTime;

        transform.Translate(move, Space.World);
    }
}
