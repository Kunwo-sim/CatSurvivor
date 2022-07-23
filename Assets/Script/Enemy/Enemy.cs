using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    int maxHp = 20;
    int curHp = 20;
    public float moveSpeed = 3.0f;
    public int attackDamage = 10;

    SpriteRenderer spriteRenderer;
    public Slider hpSlider;
    EnemyState enemyState = EnemyState.Idle;

    enum EnemyState
    {
        Idle,
        Attacked,
        Die
    }

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().OnDamaged(attackDamage);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("콜리전 충돌!");
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().OnDamaged(attackDamage);
        }
    }

    public void OnDamaged(int damage)
    {
        DecreaseHp(damage);

        spriteRenderer.color = Color.red;
        StartCoroutine("AttackedTime");
    }

    void DecreaseHp(int value)
    {
        curHp -= value;

        if (curHp <= 0)
        {
            curHp = 0;
            Die();
        }

        hpSlider.value = curHp / (float)maxHp;
    }

    void Die()
    {
        enemyState = EnemyState.Die;
        Destroy(gameObject);
    }

    IEnumerator AttackedTime()
    {
        yield return new WaitForSeconds(1.0f);

        spriteRenderer.color = new Color(1, 1, 1);
        yield return null;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
}
