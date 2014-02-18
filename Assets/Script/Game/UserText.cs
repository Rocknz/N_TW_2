﻿using UnityEngine;

public class UserText : MonoBehaviour {
	GameObject Atk;
	GameObject Int;
	GameObject Def;
	GameObject Hp,HpDamage;
	GameObject Mp;
	GameObject Coin;
	GameObject DMG;
	GameObject Turn;
	void Start(){
		Atk = GameObject.Find ("Atk Gap");
		Int = GameObject.Find ("Int Gap");
		Def = GameObject.Find ("Def Gap");
		Hp = GameObject.Find ("Hp Gap");
		HpDamage = GameObject.Find ("Hp Damage");
		Mp = GameObject.Find ("Mp Gap");
		Coin = GameObject.Find ("Coin Gap");
		DMG = GameObject.Find ("DMG Gap");
		Turn = GameObject.Find ("Turn Gaps");
		setStat();
	}
	public void BeAttacked(int Damage){
		HpDamage.transform.localPosition = new Vector3(HpDamage.transform.localPosition.x,0,90);
		HpDamage.GetComponent<tk2dTextMesh>().text = "-" + Damage.ToString();
		HpDamage.GetComponent<tk2dTextMesh>().color = new Color(130,130,130);
		HpDamage.GetComponent<tk2dTextMesh>().Commit ();

		iTween.MoveTo(HpDamage, iTween.Hash(
			"x", HpDamage.transform.localPosition.x + HpDamage.transform.parent.localPosition.x,
			"y", HpDamage.transform.localPosition.y + 100 + HpDamage.transform.parent.localPosition.y,
			"easeType", "easeOutQuad",
			"time", 1.0f,
			"oncomplete","UT_End",
			"oncompletetarget",gameObject,
			"oncompleteparams",HpDamage));
	}
	public void UT_End(GameObject x){
		HpDamage.GetComponent<tk2dTextMesh>().text = "";
		HpDamage.GetComponent<tk2dTextMesh>().Commit ();
	}
	public void setStat(){
		Atk.GetComponent<tk2dTextMesh>().text = UserData.Instance.Atk.ToString();
		Atk.GetComponent<tk2dTextMesh>().Commit();
		Int.GetComponent<tk2dTextMesh>().text = UserData.Instance.Int.ToString();
		Int.GetComponent<tk2dTextMesh>().Commit();
		Def.GetComponent<tk2dTextMesh>().text = UserData.Instance.Def.ToString();
		Def.GetComponent<tk2dTextMesh>().Commit();
		Hp.GetComponent<tk2dTextMesh>().text = UserData.Instance.Hp.ToString()+"/"+UserData.Instance.HpMax.ToString();
		Hp.GetComponent<tk2dTextMesh>().Commit();
		Mp.GetComponent<tk2dTextMesh>().text = UserData.Instance.Mp.ToString()+"/"+UserData.Instance.MpMax.ToString();
		Mp.GetComponent<tk2dTextMesh>().Commit();
		Coin.GetComponent<tk2dTextMesh>().text = UserData.Instance.Coin.ToString();
		Coin.GetComponent<tk2dTextMesh>().Commit();
		Turn.GetComponent<tk2dTextMesh>().text = UserData.Instance.Turn.ToString();
		Turn.GetComponent<tk2dTextMesh>().Commit();
	}
	public void setDMG(int Damage){
		DMG.GetComponent<tk2dTextMesh>().text = Damage.ToString();
		DMG.GetComponent<tk2dTextMesh>().Commit();
	}
	void settingUserStatus(){
		setStat ();
	}
	void Update(){
		settingUserStatus();
	}
}
