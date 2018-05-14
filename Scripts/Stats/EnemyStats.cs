using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

	public string enemyName;
	public float currentHealth;
	public float maxHealth;

	public bool isDead;
	public float respawnTime;
	public GameObject RespawnPoint;

	void Start() {
		currentHealth = maxHealth;
	}

	void Update() {

		if(currentHealth <= 0 && !isDead) {

			isDead = true;
			currentHealth = 0;
			StartCoroutine(Death());
		}
	}

	public void RecieveDamage(float dmg) {
		currentHealth -= dmg;

		print("Damage done => " + dmg);
		print("Enemy Health => " + currentHealth);
	}

	IEnumerator Death() {

		yield return new WaitForSeconds(respawnTime);
		//Death animation or notify enemy has died
		Destroy(this.gameObject);
	}
}
