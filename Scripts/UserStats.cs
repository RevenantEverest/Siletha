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

    //Auto Attack
    public float autoAttackCooldown;
    public float autoAttackCurrentTime;
    public bool canAutoAttack;

    //Deselect Enemy
    public float doubleClickTimer;
    public bool didDoubleClick;

    //Line of Sight
    public LayerMask RaycastLayers;
    public bool inLineOfSight;

    //KeyCodes
    public KeyCode attack;

	void Start () {

	}

  void OnGUI() {

    //TODO: Display tooltip on hover
    //TODO: Inventory UI
    //TODO: Inventory item image hover on drag

  }

	void Update () {
    if(Input.GetMouseButtonDown(0)) {

      SelectTarget(0);
    }

    if(Input.GetMouseButtonDown(1)) {

      SelectTarget(1);
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
        autoAttackCurrentTime = 0;
      }else {

        if(distance < 60) {

          canAttack = true;
        }else {

          canAttack = false;
          autoAttackCurrentTime = 0;
        }
      }

      //Line of Sight
      RaycastHit hit;
      if(Physics.Linecast(selectedUnit.transform.position, transform.position, out hit, RaycastLayers)) {

        print("Enemy is not in line of sight");
        inLineOfSight = false;
      }else {

        inLineOfSight = true;
      }

      //Double click detect
      if(doubleClickTimer > 0) {

        doubleClickTimer -= Time.deltaTime;
      }else {

        didDoubleClick = false;
      }
    }

    //Auto Attack
    if(selectedUnit != null && canAttack && canAutoAttack == true) {

      if(autoAttackCurrentTime < autoAttackCooldown) {

        autoAttackCurrentTime += Time.deltaTime;
      }else {

        BasicAttack();
        autoAttackCurrentTime = 0;
      }
    }

    //Attacks
    if(Input.GetKeyDown(attack)) {

      if(selectedUnit != null && canAttack && inLineOfSight) {

        BasicAttack();
        canAutoAttack = true;
      }
    }

    //TODO: Ranged Spell Attack

	}

  void SelectTarget(int selectedNum) {

    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;

    if(Physics.Raycast(ray, out hit, 10000)) {

      if(hit.transform.tag == "enemy") {
        selectedUnit = hit.transform.gameObject;

        enemyStatsScript = selectedUnit.transform.gameObject.transform.GetComponent<EnemyStats>();

        if(selectedNum == 0 && selectedUnit == null) {

          canAutoAttack = false;
        }else if(selectedNum == 1) {

          canAutoAttack = true;
        }
      }else {

        if(selectedUnit != null) {

          if(didDoubleClick == false) {

            didDoubleClick = true;
            doubleClickTimer = 0.3f;
          }else {

            print("Deselect");
            selectedUnit = null;
            didDoubleClick = false;
            doubleClickTimer = 0;
            autoAttackCurrentTime = 0;
          }
        }
      }
    }
  }

  void BasicAttack() {

    enemyStatsScript.RecieveDamage(10);
  }
}
