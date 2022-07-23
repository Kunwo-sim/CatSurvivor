using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public GameObject player;
    public Transform pawAttackTrans;
    public GameObject pawAttack;
    float pawAttackCoolDown = 1.0f;

    void Awake()
    {
        StartCoroutine("StartPawAttack", pawAttackCoolDown);
    }

    void Update()
    {
        
    }

    IEnumerator StartPawAttack(float coolDown)
    {
        yield return new WaitForSeconds(coolDown);

        pawAttackTrans.position = player.transform.position + new Vector3(5.0f, 0, 0);
        pawAttack.SetActive(true);

        StartCoroutine("StartPawAttack", coolDown);
    }
}
