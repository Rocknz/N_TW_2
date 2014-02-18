using UnityEngine;
using System.Collections;
public class Ending : MonoBehaviour {
	GameObject EndingView;
	GameObject ending;
	GameObject Turn;
	GameObject Enemy;
	GameObject Cube;
	GameObject GoMenu;
	int TurnGap;
	int EnemyGap;
	bool Gotcha = false;
	int[] Got = new int[2];
	void Start(){
		EndingView = GameObject.Find ("EndingView");
		ending = GameObject.Find ("Ending");
		Turn = GameObject.Find ("Turn Gap");
		Enemy = GameObject.Find ("Enemy Gap");
		Cube = GameObject.Find ("Cube");
		GoMenu = GameObject.Find ("Go Menu");
	}
	public void NowEnding(Tile[,] mTiles,int Turn,int DeadEnemyCount){
		EndingView.transform.localScale = new Vector3(0,0,0);
		EndingView.transform.localPosition = new Vector3(0,0,10);
		iTween.ScaleTo(EndingView, iTween.Hash(
			"x", 3000,
			"y", 5000,
			"easeType", "easeInCubic",
			"time", 1.0f,
			"oncomplete","LoadingStart",
			"oncompletetarget",gameObject,
			"oncompleteparams",EndingView));

		foreach(Tile thisTile in mTiles){
			thisTile.myHp.GetComponent<UILabel>().fontSize = 0;
			thisTile.myAttack.GetComponent<UILabel>().fontSize = 0;
		}
		TurnGap = Turn;
		EnemyGap = DeadEnemyCount;
	}
	public void LoadingStart(){
		ending.transform.localPosition = new Vector3(0,0,1);
		Turn.GetComponent<UILabel>().text = TurnGap.ToString();
		Enemy.GetComponent<UILabel>().text = EnemyGap.ToString();
		Gotcha = true;
		StartCoroutine("StartGotcha");
	}
	public void setCube(){
		string item_name = "";
		for(int i =0; i<4;i++){
			for(int j=0;j<4;j++){
				switch(i){
				case 0: item_name = "Head";break;
				case 1: item_name = "Body";break;
				case 2: item_name = "Helmet";break;
				case 3: item_name = "Sword";break;
				}
				
				switch(j){
				case 0: item_name += "1";break;
				case 1: item_name += "2";break;
				case 2: item_name += "3";break;
				case 3: item_name += "4";break;
				}
				GameObject item = GameObject.Find ("C_"+item_name);
				item.transform.localPosition = new Vector3(item.transform.localPosition.x,
				                                                         item.transform.localPosition.y,
				                                                         1000.0f);
			}
		}
		do{
			Got[0] = (int)(Random.value * 4.0f);
		}while(Got[0] == 4);

		do{
			Got[1] = (int)(Random.value * 4.0f);
		}while(Got[1] == 4);

		float depth = 0.0f; // Boris

		switch(Got[0]){
		case 0: item_name = "Head"; break;
		case 1: item_name = "Body"; depth = 1.0f; break;
		case 2: item_name = "Helmet"; break;
		case 3: item_name = "Sword"; break;
		}

		switch(Got[1]){
		case 0: item_name += "1";break;
		case 1: item_name += "2";break;
		case 2: item_name += "3";break;
		case 3: item_name += "4";break;
		}

		GameObject item1 = GameObject.Find ("C_"+item_name);
		item1.transform.localPosition = new Vector3(item1.transform.localPosition.x,
		                                           item1.transform.localPosition.y,
		                                           depth);

	}
	public IEnumerator StartGotcha(){
		while(Gotcha){
			setCube();
			yield return new WaitForSeconds(0.01f);
		}
	}
	void Update(){
		if(Input.GetButtonDown("Fire1")){
			Vector2 V2 = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();
			if(Physics.Raycast(ray, out hit)) {
				if(hit.transform == GoMenu.transform){
					Gotcha = false;
					StartCoroutine("GOTCHA");
				}
			}
		}
	}
	public IEnumerator GOTCHA(){
		iTween.ScaleTo (Cube, iTween.Hash(
			"x", 400.0f,
			"y", 400.0f,
			"z", 0.1f,
			"easeType", "easeOutQuad",
			"delay", 0.3f,
			"time", 1.0f));
		yield return new WaitForSeconds(1.0f);
		string item_name = "";

		switch(Got[0]){
		case 0: item_name = "HeadExists";break;
		case 1: item_name = "BodyExists";break;
		case 2: item_name = "HelmetExists";break;
		case 3: item_name = "SwordExists";break;
		}
		
		switch(Got[1]){
		case 0: item_name += "0";break;
		case 1: item_name += "1";break;
		case 2: item_name += "2";break;
		case 3: item_name += "3";break;
		}

		PlayerPrefs.SetInt (item_name,1);
		UserData.Instance.GetItemExists();

		Application.LoadLevel(1);
	}
}
