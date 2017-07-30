﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class PopUpManagement : MonoBehaviour {
	static public GameObject samplePopUp;
	// Use this for initialization
	void Start () {
		samplePopUp = GameObject.Find ("PopUp");
		samplePopUp.SetActive (false);
		NewPopUp ("1231231");
		NewPopUp ("12321", new Vector3 (400, 400, 0), new Vector3 (24, 1, 2));
	}
    static public PopUp NewPopUp(string Upc) {
        if (Unique.PopUps.Contains(Upc)) {
            return (PopUp)Unique.PopUps[Upc];
        }
		GameObject newPopUp = GameObject.Instantiate (samplePopUp);
		GameObject jsonManagement = newPopUp.transform.GetChild (1).gameObject;
		jsonManagement.GetComponent<JSONManagement>().upc = Upc;
        newPopUp.transform.GetChild(0).GetComponent<PopUp>().upc = Upc;
		newPopUp.SetActive (true);

		Unique.PopUps.Add (Upc, newPopUp.transform.GetChild(0).GetComponent<PopUp>());

		return newPopUp.transform.GetChild(0).GetComponent<PopUp>();
    }

	static public PopUp NewPopUp(string Upc, Vector3 spaceCoor, Vector3 orientation) {
        if (Unique.PopUps.Contains(Upc)) {
            return (PopUp)Unique.PopUps[Upc];
        }
        GameObject newPopUp = GameObject.Instantiate (samplePopUp);
		GameObject jsonManagement = newPopUp.transform.GetChild (1).gameObject;
		jsonManagement.GetComponent<JSONManagement>().upc = Upc;
		RectTransform rect = newPopUp.GetComponent<RectTransform> ();
		rect.position = spaceCoor;
		rect.eulerAngles = orientation;
        newPopUp.transform.GetChild(0).GetComponent<PopUp>().upc = Upc;
        newPopUp.SetActive (true);

		Unique.PopUps.Add (Upc, newPopUp.transform.GetChild(0).GetComponent<PopUp>());

        return newPopUp.transform.GetChild(0).GetComponent<PopUp>();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
