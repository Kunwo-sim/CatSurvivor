using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    int maxHp = 100;
    int curHp = 100;

    float moveSpeed = 10.0f;
    PlayerState playerState = PlayerState.Idle;

    SpriteRenderer spriteRenderer;
    public Slider hpSlider;

    enum PlayerState
    {
        Idle,
        Invincible, // ¹«Àû
        Die
    };

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
    }

    public void OnDamaged(int damage)
    {
        if (playerState == PlayerState.Invincible)
            return;

        DecreaseHp(damage);

        spriteRenderer.color = Color.red;
        StartCoroutine("InvincibleTime");
    }

    void DecreaseHp(int value)
    {
        curHp -= value;

        if (curHp < 0)
        {
            curHp = 0;
            playerState = PlayerState.Die;
        }

        hpSlider.value = curHp / (float)maxHp;
    }

    IEnumerator InvincibleTime()
    {
        playerState = PlayerState.Invincible;
        yield return new WaitForSeconds(1.0f);

        playerState = PlayerState.Idle;
        spriteRenderer.color = new Color(1, 1, 1);
        yield return null;
    }
}
