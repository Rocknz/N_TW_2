using UnityEngine;
using System.Collections;
using LitJson;


public class Player : MonoBehaviour {
	
	GameObject[,] ViewItemLevel = new GameObject[4,4];
	
	// Use this for initialization
	void Start () {        
		initViewItemLevel ();
		SetViewItemLevel ();
	}
	// Update is called once per frame
	void Update () {
		SetViewItemLevel ();
	}

	public void initViewItemLevel() {
		for ( int i = 0 ; i < 4 ; i++ ) {
			ViewItemLevel[0,i] = GameObject.Find ("Helmet"+(i+1).ToString());
			ViewItemLevel[1,i] = GameObject.Find ("Head"+(i+1).ToString());
			ViewItemLevel[2,i] = GameObject.Find ("Sword"+(i+1).ToString ());
			ViewItemLevel[3,i] = GameObject.Find ("Body"+(i+1).ToString ());
		}
	}

	public void SetViewItemLevel() {
		for ( int i = 0 ; i < 4 ; i++ ) 
		for ( int j = 0 ; j < UserData.ITEM_SIZE ; j++ ) {
			ViewItemLevel[i,j].transform.localPosition = new Vector3(ViewItemLevel[i,j].transform.localPosition.x,
			                                                    ViewItemLevel[i,j].transform.localPosition.y,
			                                                    1000.0f);
		}

		if ( UserData.Instance.HelmetLevel != -1 ) 
			ViewItemLevel [0, UserData.Instance.HelmetLevel].transform.localPosition = new Vector3 (
				ViewItemLevel [0, UserData.Instance.HelmetLevel].transform.localPosition.x,
				ViewItemLevel [0, UserData.Instance.HelmetLevel].transform.localPosition.y,
				-1.2f);
		if ( UserData.Instance.HeadLevel != -1 ) 
			ViewItemLevel[1,UserData.Instance.HeadLevel].transform.localPosition = new Vector3(
				ViewItemLevel[1,UserData.Instance.HeadLevel].transform.localPosition.x,
				ViewItemLevel[1,UserData.Instance.HeadLevel].transform.localPosition.y,
				-1.2f);
		if ( UserData.Instance.SwordLevel != -1 ) 
			ViewItemLevel [2, UserData.Instance.SwordLevel].transform.localPosition = new Vector3 (
				ViewItemLevel [2, UserData.Instance.SwordLevel].transform.localPosition.x,
				ViewItemLevel [2, UserData.Instance.SwordLevel].transform.localPosition.y,
				-1.2f);
		if ( UserData.Instance.BodyLevel != -1 ) 
			ViewItemLevel[3,UserData.Instance.BodyLevel].transform.localPosition = new Vector3(
				ViewItemLevel[3,UserData.Instance.BodyLevel].transform.localPosition.x,
				ViewItemLevel[3,UserData.Instance.BodyLevel].transform.localPosition.y,
				0.01f);
	}
}