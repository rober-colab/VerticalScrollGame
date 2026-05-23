using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("BGM")]
    public AudioSource bgmSource;      // BGM用のAudioSource
    public AudioClip bgmClip;          // BGMの音楽ファイル

    [Header("効果音")]
    public AudioSource seSource;       // 効果音用のAudioSource
    public AudioClip attackClip;       // 攻撃音
    public AudioClip damagedClip;      // ダメージ音
    public AudioClip enemyDeathClip;   // 敵撃破音

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // BGMを再生
        if (bgmClip != null)
        {
            bgmSource.clip = bgmClip;
            bgmSource.loop = true;
            bgmSource.Play();
        }
    }

    public void PlayAttack()
    {
        if (attackClip != null) seSource.PlayOneShot(attackClip);
    }

    public void PlayDamaged()
    {
        if (damagedClip != null) seSource.PlayOneShot(damagedClip);
    }

    public void PlayEnemyDeath()
    {
        if (enemyDeathClip != null) seSource.PlayOneShot(enemyDeathClip);
    }
}
