using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawAttack : MonoBehaviour
{
    public Vector2 attackSize;
    public GameObject player;
    int attackDamage = 10;

    public void AttackStart()
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, attackSize, 0);

        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject.tag == "Enemy")
            {
                hit.gameObject.GetComponent<Enemy>().OnDamaged(attackDamage);
            }
        }
    }

    public void AttackEnded()
    {
        gameObject.SetActive(false);
    }

}