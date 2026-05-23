using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // 追いかける対象（プレイヤー）
    public Vector3 offset = new Vector3(0, 10, -5); // カメラの位置ズレ
    public float smoothSpeed = 5f; // 追従のなめらかさ

    void LateUpdate()
    {
        if (target == null) return;

        // 目標位置 = プレイヤーの位置 + オフセット
        Vector3 desiredPosition = target.position + offset;

        // なめらかに移動
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // 常にプレイヤーを見続ける
        transform.LookAt(target);
    }
}
