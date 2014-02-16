using UnityEngine;
using System.Collections;

public class Message : MonoBehaviour {
	GameObject mYes;
	GameObject mNo;
	GameObject mMessage;
	GameObject mMbox;
	int M_Type = 0;
	void Start () {
		mYes = GameObject.Find ("M_Yes");
		mNo = GameObject.Find ("M_No");
		mMessage = GameObject.Find ("M_Message");
		mMbox = GameObject.Find ("Logic_Message");
		DontDestroyOnLoad(this);	
	}
	public void Set_YN_Message(float x,float y){
		M_Type = 1;
		this.transform.localPosition = new Vector3 (0,0,3);
		mMessage.transform.localPosition = new Vector3 (0,0.2f,-1.0f);
		mYes.transform.localPosition = new Vector3 (-0.2f,0,-1.0f);
		mNo.transform.localPosition = new Vector3 (0.2f,0,-1.0f);

		this.transform.localScale = new Vector3(x,y,0.1f);
		mYes.transform.localScale = new Vector3(1f,0.5f,0.1f);
		mNo.transform.localScale = new Vector3(1f,0.5f,0.1f);
		mMessage.transform.localScale = new Vector3(1f,0.5f,0.1f);

		mMessage.GetComponent<tk2dTextMesh>().text = "Tutorial ?";
		mMessage.GetComponent<tk2dTextMesh>().Commit();
	}
	public void Tuto_Message(float x,float y,string msg){
		M_Type = 2;
		this.transform.localPosition = new Vector3 (0,0,3);
		mMessage.transform.localPosition = new Vector3 (0,0,-1.0f);

		mYes.transform.localPosition = new Vector3 (-0.2f,0,-1.0f);
		mNo.transform.localPosition = new Vector3 (0.2f,0,-1.0f);
		
		this.transform.localScale = new Vector3(x,y,0.1f);
		mYes.transform.localScale = new Vector3(0,0,0);
		mNo.transform.localScale = new Vector3(0,0,0);
		mMessage.transform.localScale = new Vector3(1f,0.5f,0.1f);
		
		mMessage.GetComponent<tk2dTextMesh>().text = msg;
		mMessage.GetComponent<tk2dTextMesh>().Commit();
	}
	void Update () {
		if(Input.GetButtonUp("Fire1")){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();

			if(Physics.Raycast(ray, out hit)) {
				if(hit.transform == mYes.transform && M_Type == 1){
					UserData.Instance.IsTutorial = 0;
					this.transform.localPosition = new Vector3 (0,0,-50);
					Application.LoadLevel(2);
				}
				else if(hit.transform == mNo.transform && M_Type == 1){
					UserData.Instance.IsTutorial = -1;
					this.transform.localPosition = new Vector3 (0,0,-50);
					Application.LoadLevel(2);
				}
				else if(hit.transform == mMbox.transform && M_Type == 2){
					this.transform.localPosition = new Vector3 (0,0,-50);
					GameObject.Find ("Main Camera").GetComponent<MainLogic>().NowBreaking = false;
				}
			}
		}
	}
}
