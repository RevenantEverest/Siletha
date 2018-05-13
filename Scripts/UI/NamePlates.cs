using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamePlates : MonoBehaviour {

	public GameObject textName;
	public GameObject parentObject;

	public bool isSelected;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if(textName != null) {

			textName.transform.LookAt(Camera.main.transform.position);
			textName.transform.Rotate(0, 180, 0);

			if(parentObject.GetComponent<UserStats>()) {
				textName.GetComponent<TextMesh>().text = parentObject.GetComponent<UserStats>().characterName;
			}else if(parentObject.GetComponent<EnemyStats>()) {
				textName.GetComponent<TextMesh>().text = parentObject.GetComponent<EnemyStats>().enemyName;
			}

			if(parentObject.transform.tag == "enemy") {
				textName.GetComponent<TextMesh>().color = Color.red;
			}else {
				textName.GetComponent<TextMesh>().color = Color.cyan;
			}
		}
	}
}
