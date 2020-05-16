using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackRate = 1f;
    public AudioSource weaponSFX;
    public AudioSource punchSFX;

    private float attackCountdown = 0f;

    public event System.Action OnAttack;

    CharacterStats myStats;
    CharacterStats enemyStats;

    void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    void Update()
    {
        attackCountdown -= Time.deltaTime;
    }

    public void Attack(CharacterStats enemyStats)
    {
        if (attackCountdown <= 0f)
        {
            this.enemyStats = enemyStats;
            attackCountdown = 1f / attackRate;

            StartCoroutine(DoDamage(enemyStats, .6f));

            if (OnAttack != null)
            {
                OnAttack();
            }
        }
    }


    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        if (weaponSFX != null && punchSFX != null)
        {
            if (EquipmentManager.instance.hasWeapon())
                weaponSFX.Play();
            else
                punchSFX.Play();
        }

        yield return new WaitForSeconds(delay);

        enemyStats.TakeDamage(myStats.damage.GetValue(), gameObject);
    }
}
