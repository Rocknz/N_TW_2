using UnityEngine;
using System.Collections;
public class TW_Start : MonoBehaviour {
	GameObject NewGame;
	GameObject Status;
	GameObject Continue;
	GameObject Quit;
	void Start () {
		NewGame = GameObject.Find("NewGame");	
		Status = GameObject.Find ("Status");
		Continue = GameObject.Find ("Continue");
		Quit = GameObject.Find ("Quit");
	}
	void Update () {
		if(Input.GetButtonDown ("Fire1")) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();
			if(Physics.Raycast(ray, out hit)) {
				if(NewGame.transform == hit.transform){
					GameObject.Find ("Logic_Message").GetComponent<Message>().Set_YN_Message(30.0f,50.0f);
					UserData.Instance.IsTutorial = 0;
					UserData.Instance.NewStat();
//					Application.LoadLevel(2);
				}
				else if(Continue.transform == hit.transform){
					UserData.Instance.LoadGameData();
					if(UserData.Instance.haveGameData == 1){
						Application.LoadLevel(2);
					}
				}
				else if(Status.transform == hit.transform){
					Application.LoadLevel(3);
				}
				else if(Quit.transform == hit.transform){
					Application.Quit();
				}
			}
		}
		else if (Input.GetKeyDown(KeyCode.Escape)){ 
			Application.Quit(); 
		}
	}
}