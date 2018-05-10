using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserStats : MonoBehaviour {

    //Character Info
    public string characterName;
    public int level;
    public string userClass;

    //Character Stats
    public float currentHealth;               //Health
    public float maxHealth;
    public float hpRegenTimer;                //Health Regen
    public float hpRegenAmount;

    public float currentMana;                 //Mana
    public float maxMana;
    public float manaRegenTimer;              //Mana Regen
    public float manaRegenAmount;


    public float baseAttackPower;             //Attack Power
    public float currentAttackPower;

    public float baseAttackSpped;             //Attack Speed
    public float currentAttackSpeed;

    public float baseDodge;                   //Dodge
    public float currentDodge;

    public float baseHitPercent;              //Hit Percent
    public float currentHitPercent;


    public float currentXP;                   //Experience
    public float maxXP;

    public bool isDead = false;

    //Selection
    public GameObject selectedUnit;

    //Current Enemy References
    public EnemyStats enemyStatsScript;

    //Attack
    public bool behindEnemy;
    public bool canAttack;

    //KeyCodes
    public KeyCode attack;

	void Start () {

	}

	void Update () {
    if(Input.GetMouseButtonDown(0)) {

      SelectTarget();
    }

    if(selectedUnit != null) {

      Vector3 toTarget = (selectedUnit.transform.position - transform.position).normalized;

      //Check if player is behind enemy ( Calculate dodge, parry, extra damage, etc. )
      if(Vector3.Dot(toTarget, selectedUnit.transform.forward) < 0) {
        behindEnemy = false;
      }else {
        behindEnemy = true;
      }

      //Calculate if the player is facing the enemy and is within attack distance
      float distance = Vector3.Distance(this.transform.position, selectedUnit.transform.position);
      Vector3 targetDir = selectedUnit.transform.position - transform.position;
      Vector3 forward = transform.forward;
      float angle = Vector3.Angle(targetDir, forward);

      if(angle > 60.0) {

        canAttack = false;
      }else {

        if(distance < 60) {

          canAttack = true;
        }else {

          canAttack = false;
        }
      }

    }

    if(Input.GetKeyDown(attack)) {

      if(selectedUnit != null && canAttack) {

        BasicAttack();
      }
    }
    
    //TODO: Ranged Spell Attack

	}

  void SelectTarget() {

    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;

    if(Physics.Raycast(ray, out hit, 10000)) {

      if(hit.transform.tag == "enemy") {
        selectedUnit = hit.transform.gameObject;

        enemyStatsScript = selectedUnit.transform.gameObject.transform.GetComponent<EnemyStats>();
      }
    }
  }

  void BasicAttack() {

    enemyStatsScript.RecieveDamage(10);
  }
}
