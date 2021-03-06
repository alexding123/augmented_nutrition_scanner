﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NutritionPage : MonoBehaviour {
	public string nutritionName = "protein";
	public Text valueText;
	public Text maxText;
	public Text nameText;
	public CylinderBar cylinder;

	Image icon;
	private NutritionJSON nutrition;
	// Use this for initialization
	void Start () {
	}
	public void Initialize(NutritionJSON input) {
		nutrition = input;
		icon = nameText.gameObject.GetComponentInChildren<Image>();
		SetValues ();
	}
	public void SetValues() {
		bool isAll = ServingAllButton.CheckState ();
		CylinderHandle (isAll);
		TextHandle (isAll);
		IconHandle ();
	}
	void IconHandle() {
		icon.sprite = Resources.Load<Sprite> ("Sprites/" + nutritionName + "Icon");
	}
	void CylinderHandle(bool isAll) {
		cylinder.Initialize (nutritionName);
		float value = BarInfo.FromNutrition (nutritionName, nutrition);
		if (isAll) {
			cylinder.StepTo (value * nutrition.nf_serving_size_qty);
		} else {
			cylinder.StepTo (value);
		}
	}
	void TextHandle(bool isAll) {
		BarInfo temp;
		Unique.BarInfos.TryGetValue (nutritionName, out temp);
		string unit = temp.unit;
		maxText.text = NutritionMax.GetMax (nutritionName).ToString() + unit;
		nameText.text = Utils.UppercaseFirst (nutritionName);

		float value = BarInfo.FromNutrition (nutritionName, nutrition);
		if (isAll) {
			valueText.text = value + unit;
		} else {
			valueText.text = value / nutrition.nf_serving_size_qty + unit;
		}

	}
	// Update is called once per frame
	void Update () {

	}
}
