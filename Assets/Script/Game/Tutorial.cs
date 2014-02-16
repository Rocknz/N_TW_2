using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {
	int now_Tutorial;
	void Start () {
		now_Tutorial = UserData.Instance.IsTutorial;
		changeTile(now_Tutorial);
	}

	void Update () {
		if(now_Tutorial != UserData.Instance.IsTutorial){
			now_Tutorial = UserData.Instance.IsTutorial;
			changeTile(now_Tutorial);
		}
	}

	void changeTile(int level){
		if(level == 0){
			this.GetComponent<MainLogic>().NowBreaking = true;
			for(int i=0;i<MainLogic.TILE_SIZE;i++){
				for(int j=0;j<MainLogic.TILE_SIZE;j++){
					TileStatus nTile = this.GetComponent<MainLogic>().main_Tile[i,j].myStatus;
					nTile.myType = MainLogic.TILETYPE.Potion;
					nTile.myTurn = 0;
					nTile.myHp = 1;

					this.GetComponent<MainLogic>().main_Tile[i,j].SetTileByStatus();
				}
			}
			GameObject.Find ("Logic_Message").GetComponent<Message>().Tuto_Message(3000.0f,5000.0f," Potion !");
		}
		else if(level == 1){
			this.GetComponent<MainLogic>().NowBreaking = true;
			for(int i=0;i<MainLogic.TILE_SIZE;i++){
				for(int j=0;j<MainLogic.TILE_SIZE;j++){
					TileStatus nTile = this.GetComponent<MainLogic>().main_Tile[i,j].myStatus;
					nTile.myType = MainLogic.TILETYPE.Coin;
					nTile.myTurn = 0;
					nTile.myHp = 1;

					this.GetComponent<MainLogic>().main_Tile[i,j].SetTileByStatus();
				}
			}
			GameObject.Find ("Logic_Message").GetComponent<Message>().Tuto_Message(3000.0f,5000.0f," Coin !");
		}
		else if(level == 2){
			this.GetComponent<MainLogic>().NowBreaking = true;
			for(int i=0;i<MainLogic.TILE_SIZE;i++){
				for(int j=0;j<MainLogic.TILE_SIZE;j++){
					TileStatus nTile = this.GetComponent<MainLogic>().main_Tile[i,j].myStatus;
					nTile.myType = MainLogic.TILETYPE.Potion;
					nTile.myTurn = 0;
					nTile.myHp = 1;
					
					this.GetComponent<MainLogic>().main_Tile[i,j].SetTileByStatus();
				}
			}
			GameObject.Find ("Logic_Message").GetComponent<Message>().Tuto_Message(3000.0f,5000.0f," Potion !");
		}
		else if(level == 3){

		}
	}
}
