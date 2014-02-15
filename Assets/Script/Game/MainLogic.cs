using UnityEngine;
using System.Collections;

public class MainLogic : MonoBehaviour {
	public enum TILETYPE{ Enemy, Sword, Storm, Potion, Coin};
	public static int TILE_SIZE = 7; 
	GameObject player,monsterAttackSound;
	Queue BfsQ;
	Vector2[] PathQ;
	int PQc;
	bool NowBreaking;
	int FallingCount;
	int Damage_now = 1;

	public Tile[,] main_Tile = new Tile[TILE_SIZE,TILE_SIZE];
	bool[,] touch_Check = new bool[TILE_SIZE,TILE_SIZE];

	void Start () {
		player = GameObject.Find ("Player");
		monsterAttackSound = GameObject.Find ("MonsterAttackSound");
		int i,j;
		for(i=0;i<TILE_SIZE;i++){
			for(j=0;j<TILE_SIZE;j++){
				main_Tile[i,j] = new Tile(i,j,GameObject.Find ("AllTiles"));
				main_Tile[i,j].myStatus.myAttack = UserData.Instance.TS[i,j].myAttack;
				main_Tile[i,j].myStatus.myHp = UserData.Instance.TS[i,j].myHp;
				main_Tile[i,j].myStatus.myTurn = UserData.Instance.TS[i,j].myTurn;
				main_Tile[i,j].myStatus.myX = UserData.Instance.TS[i,j].myX;
				main_Tile[i,j].myStatus.myY = UserData.Instance.TS[i,j].myY;
				main_Tile[i,j].myStatus.myType = UserData.Instance.TS[i,j].myType;
				main_Tile[i,j].SetHp ();
				main_Tile[i,j].SetAtk ();
				main_Tile[i,j].SetTileByStatus();

				touch_Check[i,j] = false;
			}
		}
		UserData.Instance.SaveGame();
		NowBreaking = false;
	}

	GameObject before = null;
	void Update () {
		if(!NowBreaking){
			if(Input.GetButtonUp("Fire1")){
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit = new RaycastHit();

				int what = 0;
				if(Physics.Raycast(ray, out hit)) {
					foreach(Tile tiles in main_Tile){
						if(tiles.myTile.transform == hit.transform &&
						   before == tiles.myTile){
							PathQ = new Vector2[50];
							PQc = 0;
							Add(new Vector2(tiles.myStatus.myX,tiles.myStatus.myY));
							what = 1;
						}
					}
				}
				tk2dTextMesh DMG_Text = GameObject.Find ("DMG Text").GetComponent<tk2dTextMesh>();
				tk2dTextMesh DMG_Gap = GameObject.Find("DMG Gap").GetComponent<tk2dTextMesh>();
				DMG_Text.text = "";
				DMG_Gap.text = "";
				DMG_Text.Commit ();
				DMG_Gap.Commit ();

				for(int i=0;i<TILE_SIZE;i++){
					for(int j=0;j<TILE_SIZE;j++){
						main_Tile[i,j].SetScale (1.0f);
					}
				}

				before = null;

				if(what == 1){
					int count = PQc;
					TILETYPE type = new TILETYPE();
					while(PQc != 0){
						Vector2 now = (Vector2)PathQ[PQc-1];
						PQc--;
						int nx,ny;
						nx = (int)now.x;
						ny = (int)now.y;
						main_Tile[ny,nx].SetScale (1.0f);
						if(count >= 3){
							if(!(type == TILETYPE.Sword && main_Tile[ny,nx].myStatus.myType == TILETYPE.Enemy)){
								type = main_Tile[ny,nx].myStatus.myType;
							}
							main_Tile[ny,nx].BeAttacked (Damage_now);
						}
					}
					DestroyTile();
					if(count >= 3){
						GameObject.Find ("ComboBox").GetComponent<ComboLogic>().AddCombo(type);
						if(type == TILETYPE.Coin){
							UserData.Instance.Coin += count;
						}
						else if(type == TILETYPE.Potion){
							UserData.Instance.Hp += count;
						}
						else if(type == TILETYPE.Storm){
							UserData.Instance.Mp += count;
						}
						GameObject.Find ("UserText").GetComponent<UserText>().setStat();
					}
				}
			}
			if(Input.GetButtonDown("Fire1")){	
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit = new RaycastHit();
				if(Physics.Raycast(ray, out hit)) {
					if(player.transform == hit.transform){
						Application.LoadLevel(4);
					}
				}
				int what = 0;
				if(Physics.Raycast(ray, out hit)) {
					foreach(Tile tiles in main_Tile){
						if(tiles.myTile.transform == hit.transform){
							before = tiles.myTile;
							PathQ = new Vector2[50];
							PQc = 0;
							Add(new Vector2(tiles.myStatus.myX,tiles.myStatus.myY));
							what = 1;
						}
					}
				}
				if(what == 1 && PQc >= 3){
					int count = PQc;

					int upcount = 0;
					TILETYPE type = main_Tile[(int)PathQ[0].y,(int)PathQ[0].x].myStatus.myType;
					tk2dTextMesh DMG_Text = GameObject.Find ("DMG Text").GetComponent<tk2dTextMesh>();
					tk2dTextMesh DMG_Gap = GameObject.Find("DMG Gap").GetComponent<tk2dTextMesh>();
					for(int i=0;i<PQc;i++){
						Vector2 now = (Vector2)PathQ[i];
						int nx,ny;
						nx = (int)now.x;
						ny = (int)now.y;
						main_Tile[ny,nx].SetScale(1.3f);
					}

					if(type == TILETYPE.Coin){
						DMG_Text.text = "CNT";
						upcount = count;
					}
					else if(type == TILETYPE.Potion){
						DMG_Text.text = "CNT";
						upcount = count;
					}
					else if(type == TILETYPE.Storm){
						DMG_Text.text = "CNT" ;
						upcount = count * UserData.Instance.Int;
					}
					else{
						upcount = 1;
						for(int i=0 ; i<PQc ; i++){
							Vector2 now = (Vector2)PathQ[i];
							int nx,ny;
							nx = (int)now.x;
							ny = (int)now.y;
							if(main_Tile[ny,nx].myStatus.myType == TILETYPE.Sword){
								upcount += UserData.Instance.Atk;
							}
						}
						Damage_now = upcount;
						DMG_Text.text = "DMG";
					}
					DMG_Gap.text = upcount.ToString();

					DMG_Text.Commit ();
					DMG_Gap.Commit ();

				}
			}
			
			if (Input.GetKeyDown(KeyCode.Escape)){ 
				Application.LoadLevel(1); 
			}
		}
	}
	private void DestroyTile(){
		// hP ㄱㅏ 0ㅂㅗㄷㅏ ㅈㅏㄱㅇㅡㄴ ㅌㅏㅇㅣㄹ ㅈㅔㄱㅓ
		int i,j,cnt=0;
		for(i=0;i<TILE_SIZE;i++){
			for(j=0;j<TILE_SIZE;j++){
				if(main_Tile[i,j].myStatus.myHp <= 0){
					cnt ++;
					if(main_Tile[i,j].myStatus.myType == TILETYPE.Enemy){
						UserData.Instance.DeadEnemyCount ++;
					}
				}
			}
		}

		if(cnt != 0){
			NowBreaking = true;

			//MonsterAttackTurn.
			for(i=0;i<TILE_SIZE;i++){
				for(j=0;j<TILE_SIZE;j++){
					main_Tile[i,j].myStatus.myTurn ++;
				}
			}

			for(i=0;i<TILE_SIZE;i++){
				for(j=0;j<TILE_SIZE;j++){
					if(main_Tile[i,j].myStatus.myHp <= 0){
						//ㅈㅔㄱㅓ
						cnt --;
						if(cnt != 0){
							iTween.ScaleTo(main_Tile[i,j].myTile, iTween.Hash(
								"x", 0,
								"y", 0,
								"easeType", "easeInCubic",
								"time", 0.2f));
						}
						else{
							iTween.ScaleTo(main_Tile[i,j].myTile, iTween.Hash(
								"x", 0,
								"y", 0,
								"easeType", "easeInCubic",
								"time", 0.2f,
								"oncomplete","FallingTile",
								"oncompletetarget",gameObject,
								"oncompleteparams",main_Tile[i,j]));
						}
					}
				}
			}
		}
	}
	private void FallingTile(){
		int i,j,y;
		for(j=0;j<TILE_SIZE;j++){
			y = 0;
			for(i=0;i<TILE_SIZE;i++){
				while(true){
					if(y >= TILE_SIZE){
						main_Tile[i,j].myStatus = new TileStatus(y,j,UserData.Instance.Turn);
						y ++;
						break;
					}
					else{
						if(main_Tile[y,j].myStatus.myHp <= 0){
							y++;
						}
						else{
							main_Tile[i,j].myStatus = main_Tile[y,j].myStatus;
							y++;
							break;
						}
					}
				}
				main_Tile[i,j].SetTileByStatus();
			}
		}
		FallingCount = 0;
		for(i=0;i<TILE_SIZE;i++){
			for(j=0;j<TILE_SIZE;j++){
				if(main_Tile[i,j].myStatus.myY != i){
					main_Tile[i,j].myStatus.myY = i;
					FallingCount ++;
					Vector3 v3 = Tile.Position(i,j,0);
					iTween.MoveTo(main_Tile[i,j].myTile, iTween.Hash(
						"x", v3.x,
						"y", v3.y,
						"easeType", "easeOutQuad",
						"speed", 2000,
						"oncomplete","FallingEnd",
						"oncompletetarget",gameObject,
						"oncompleteparams",main_Tile[i,j]));
				}
			}
		}
	}
	public void FallingEnd(Tile tile){
		FallingCount --;
		tile.SetTileByStatus();
		if(FallingCount == 0){
			// Effect
			if(UserData.Instance.Mp == UserData.Instance.MpMax){
				UserData.Instance.Mp = 0;
				GameObject.Find ("UserText").GetComponent<UserText>().setStat();
				StormEffect();
			}
			else{
				MonsterAttack();
			}
		}
	}
	public void StormEffect(){
		for(int i=0;i<TILE_SIZE;i++){
			for(int j=0;j<TILE_SIZE;j++){
				main_Tile[i,j].myStatus.myHp = 0;
			}
		}
		DestroyTile ();
	}
	public void MonsterAttack(){
		// ㅁㅗㄴㅅㅡㅌㅓ ㄱㅗㅇㄱㅕㄱ
		FallingCount = 1;

		int i,j;
		int total = 0;
		for(i=0;i<TILE_SIZE;i++){
			for(j=0;j<TILE_SIZE;j++){
				if(main_Tile[i,j].myStatus.myType == TILETYPE.Enemy && 
				   main_Tile[i,j].myStatus.myTurn != 0){

					FallingCount ++;
					iTween.ScaleFrom(main_Tile[i,j].myTile, iTween.Hash(
						"x", 3.0f,
						"y", 3.0f,
						"z", 3.0f,
						"easeType", "easeOutQuad",
						"time", 0.5f,
						"oncomplete","MonsterAttackEnd",
						"oncompletetarget",gameObject,
						"oncompleteparams",main_Tile[i,j]));
					iTween.ScaleTo (main_Tile[i,j].AttackEffect, iTween.Hash(
						"x", 100.0f,
						"y", 100.0f,
						"z", 0.1f,
						"easeType", "easeOutQuad",
						"delay", 0.3f,
						"time", 0.5f));
					iTween.ScaleTo (main_Tile[i,j].AttackEffect, iTween.Hash(
						"x", 0.0f,
						"y", 0.0f,
						"z", 0.1f,
						"easeType", "easeOutQuad",
						"delay", 0.8f,
						"time", 0.4f));

					if(UserData.Instance.Def <= main_Tile[i,j].myStatus.myAttack){
						UserData.Instance.Hp -= (main_Tile[i,j].myStatus.myAttack - UserData.Instance.Def);
						total += (main_Tile[i,j].myStatus.myAttack - UserData.Instance.Def);
						main_Tile[i,j].AttackEffect.GetComponent<tk2dTextMesh>().text = (UserData.Instance.Def - main_Tile[i,j].myStatus.myAttack).ToString();
					}
					else{
						main_Tile[i,j].AttackEffect.GetComponent<tk2dTextMesh>().text = "0";
					}
					
					main_Tile[i,j].AttackEffect.GetComponent<tk2dTextMesh>().color = new Color(255,0,0);
					main_Tile[i,j].AttackEffect.GetComponent<tk2dTextMesh>().Commit();


					if(UserData.Instance.Hp < 0) UserData.Instance.Hp = 0;
					GameObject.Find ("UserText").GetComponent<UserText>().setStat();
				}
			}
		}
		GameObject.Find ("UserText").GetComponent<UserText>().BeAttacked(total);
		if(FallingCount != 1){
			StartCoroutine("MonsterAttackAction");
		}
		MonsterAttackEnd();
	}
	private IEnumerator MonsterAttackAction(){
		// Moving Camera
		Camera camera = Camera.main;
		camera.GetComponent<Camera>().orthographicSize = 2150.0f;
		monsterAttackSound.GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(0.1f);
		camera.GetComponent<Camera>().orthographicSize = 2200.0f;
		yield return null;
	}
	public void MonsterAttackEnd(){
		FallingCount --;
		if(FallingCount == 0){
			UserData.Instance.Turn ++;
			if(UserData.Instance.Hp <= 0){
				GameObject.Find("Ending").GetComponent<Ending>().NowEnding(main_Tile,UserData.Instance.Turn,UserData.Instance.DeadEnemyCount);
				UserData.Instance.haveGameData = 0;
				SaveGame();
			}
			else{
				NowBreaking = false;
				SaveGame();
			}
		}
	}
	public void SaveGame(){
		int i,j;
		for(i=0;i<TILE_SIZE;i++){
			for(j=0;j<TILE_SIZE;j++){
				UserData.Instance.TS[i,j].myAttack = main_Tile[i,j].myStatus.myAttack;
				UserData.Instance.TS[i,j].myHp = main_Tile[i,j].myStatus.myHp;
				UserData.Instance.TS[i,j].myTurn = main_Tile[i,j].myStatus.myTurn;
				UserData.Instance.TS[i,j].myX = main_Tile[i,j].myStatus.myX;
				UserData.Instance.TS[i,j].myY = main_Tile[i,j].myStatus.myY;
				UserData.Instance.TS[i,j].myType = main_Tile[i,j].myStatus.myType;
			}
		}
		UserData.Instance.SaveGame();
	}
	private void Add(Vector2 newSelectedTile){

		// Path ㅇㅔ ㅍㅛ ㅅㅣ!
		for(int i=0;i<TILE_SIZE;i++){
			for(int j=0;j<TILE_SIZE;j++){
				touch_Check[i,j] = false;
			}
		}

		int nx,ny;
		nx = (int)newSelectedTile.x;
		ny = (int)newSelectedTile.y;
		BfsQ = new Queue();
		BfsQ.Enqueue(new Vector2(nx,ny));
		touch_Check[ny,nx] = true;
		while(BfsQ.Count != 0){
			Vector2 nowSelectedTile = (Vector2)BfsQ.Dequeue();
			PathQ[PQc++] = nowSelectedTile;

			int nx1,ny1;
			nx = (int)nowSelectedTile.x;
			ny = (int)nowSelectedTile.y;

			for(nx1 = nx-1; nx1 <= nx+1; nx1 ++){
				for(ny1 = ny-1;ny1 <= ny+1; ny1 ++){
					if(nx1 >= 0 && ny1 >= 0 && nx1 < TILE_SIZE && ny1 < TILE_SIZE){
						if(!touch_Check[ny1,nx1]){
							if(TileStatus.EqualType(main_Tile[ny,nx].myStatus.myType,
							                        main_Tile[ny1,nx1].myStatus.myType)){
								
								touch_Check[ny1,nx1] = true;
								BfsQ.Enqueue(new Vector2(nx1,ny1));
							}
						}
					}
				}
			}
		}
	}
}
