using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour {

	public BasicStats[] AllClassStats;
	public bool ClassSelectWindow;
	public GameObject user;

	void Start() {

	}

	void OnGUI() {
		if(ClassSelectWindow) {

			if(GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2 - 150, 200, 40), "CLASS 1")) {
				AssignBaseStats(0);
				ClassSelectWindow = false;
			}

			if(GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2 - 150, 200, 40), "CLASS 2")) {
				AssignBaseStats(1);
				ClassSelectWindow = false;
			}
		}
	}

	void Update() {

	}

	void AssignBaseStats (int classChosen) {
		var Comp = user.GetComponent<UserStats>();

		Comp.userClass = AllClassStats[classChosen].userClass;
		Comp.baseAttackPower = AllClassStats[classChosen].baseAttackPower;
	}
}
