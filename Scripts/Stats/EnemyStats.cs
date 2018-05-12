using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

	public float currentHealth;
	public float maxHealth;

	public bool isDead = false;

	void Start() {

	}

	void Update() {

		if(currentHealth <= 0) {
			currentHealth = 0;
			isDead = true;
		}
	}

	public void RecieveDamage(float dmg) {
		currentHealth -= dmg;

		print("Damage done => " + dmg);
		print("Enemy Health => " + currentHealth);
	}
}
