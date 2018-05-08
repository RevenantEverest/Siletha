using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserStats : MonoBehaviour {

    public string characterName;
    public int level;

    public float currentHealth;
    public float maxHealth;
    public float currentMana;
    public float maxMana;

    public float baseAttackPower;
    public float currentAttackPower;
    public float baseAttackSpped;
    public float currentAttackSpeed;
    public float baseDodge;
    public float currentDodge;
    public float baseHitPercent;
    public float currentHitPercent;

    public float hpRegenTimer;
    public float hpRegenAmount;

    public float manaRegenTimer;
    public float manaRegenAmount;

    public float currentXP;
    public float maxXP;

    public bool isDead;

	void Start () {

	}

	void Update () {

	}
}
