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
	string story_1 = "From one day, the monster began \n\n to mass infestation \n\n in the Anomarad Kingdom. \n\n Because of Jellyking, \n\n discharged from the other world, \n Jelly-P was outbreaked.";
	string story_2 = "The kingdom recognized \n\n this situation, and \n\n orderd subjugation command \n\n to Accipiter, \n\n the immediate kingdom guild.";
	string story_3 = "Boris Jinneman, \n\n as an apprentice knight, \n\n obey this order and go \n\n to the front for \n\n defeating Jelly-Ps. ";
	string story_4 = "Let's survive long, \n\n defeat many, \n\n receive more valuable reward, \n\n and train Boris strongly!";
	void changeTile(int level){
		if(level == 0){
			GameObject.Find ("AllTiles").GetComponent<UIPanel>().alpha = 0.23f;
			this.GetComponent<MainLogic>().NowBreaking = true;
			GameObject.Find ("Logic_Message").GetComponent<Message>().Story(3000.0f,5000.0f,story_1);
		}
		else if(level == 1){
			GameObject.Find ("AllTiles").GetComponent<UIPanel>().alpha = 0.23f;
			this.GetComponent<MainLogic>().NowBreaking = true;
			GameObject.Find ("Logic_Message").GetComponent<Message>().Story(3000.0f,5000.0f,story_2);
		}
		else if(level == 2){
			GameObject.Find ("AllTiles").GetComponent<UIPanel>().alpha = 0.23f;
			this.GetComponent<MainLogic>().NowBreaking = true;
			GameObject.Find ("Logic_Message").GetComponent<Message>().Story(3000.0f,5000.0f,story_3);
		}
		else if(level == 3){
			GameObject.Find ("AllTiles").GetComponent<UIPanel>().alpha = 0.23f;
			this.GetComponent<MainLogic>().NowBreaking = true;
			GameObject.Find ("Logic_Message").GetComponent<Message>().Story(3000.0f,5000.0f,story_4);
		}
		else if(level == 4){
			this.GetComponent<MainLogic>().NowBreaking = true;
			for(int i=0;i<MainLogic.TILE_SIZE;i++){
				for(int j=0;j<MainLogic.TILE_SIZE;j++){
					TileStatus nTile = this.GetComponent<MainLogic>().main_Tile[i,j].myStatus;
					nTile.myType = MainLogic.TILETYPE.X;
					nTile.myTurn = 0;
					nTile.myHp = 1;
					this.GetComponent<MainLogic>().main_Tile[i,j].SetTileByStatus();
				}
			}

			int[,] paths = {{0,0},{1,1},{2,2},{3,3},{4,2},{4,3},{5,2}};
			for(int i=0;i<7;i++){
				TileStatus nTile = this.GetComponent<MainLogic>().main_Tile[paths[i,0],paths[i,1]].myStatus;
				nTile.myType = MainLogic.TILETYPE.Enemy;
				nTile.myTurn = 0;
				nTile.myHp = 1;
				this.GetComponent<MainLogic>().main_Tile[paths[i,0],paths[i,1]].SetTileByStatus();
			}
			
			GameObject.Find ("AllTiles").GetComponent<UIPanel>().alpha = 0.23f;
			this.GetComponent<MainLogic>().NowBreaking = true;
			GameObject.Find ("Logic_Message").GetComponent<Message>().Tuto_Message(3000.0f,5000.0f," Monster !");
		}
		else if(level == 5){
			this.GetComponent<MainLogic>().NowBreaking = true;
			for(int i=0;i<MainLogic.TILE_SIZE;i++){
				for(int j=0;j<MainLogic.TILE_SIZE;j++){
					TileStatus nTile = this.GetComponent<MainLogic>().main_Tile[i,j].myStatus;
					nTile.myType = MainLogic.TILETYPE.X;
					nTile.myTurn = 0;
					nTile.myHp = 1;
					this.GetComponent<MainLogic>().main_Tile[i,j].SetTileByStatus();
				}
			}
			
			int[,] paths = {{0,2},{1,1},{2,2},{2,3},{3,2},{4,3},{5,2}};
			for(int i=0;i<7;i++){
				TileStatus nTile = this.GetComponent<MainLogic>().main_Tile[paths[i,0],paths[i,1]].myStatus;
				nTile.myType = MainLogic.TILETYPE.Potion;
				nTile.myTurn = 0;
				nTile.myHp = 1;
				this.GetComponent<MainLogic>().main_Tile[paths[i,0],paths[i,1]].SetTileByStatus();
			}
			
			GameObject.Find ("AllTiles").GetComponent<UIPanel>().alpha = 0.23f;
			this.GetComponent<MainLogic>().NowBreaking = true;
			GameObject.Find ("Logic_Message").GetComponent<Message>().Tuto_Message(3000.0f,5000.0f," Potion !");
		}
		else if(level == 6){
			this.GetComponent<MainLogic>().NowBreaking = true;
			for(int i=0;i<MainLogic.TILE_SIZE;i++){
				for(int j=0;j<MainLogic.TILE_SIZE;j++){
					TileStatus nTile = this.GetComponent<MainLogic>().main_Tile[i,j].myStatus;
					nTile.myType = MainLogic.TILETYPE.X;
					nTile.myTurn = 0;
					nTile.myHp = 1;
					this.GetComponent<MainLogic>().main_Tile[i,j].SetTileByStatus();
				}
			}
			
			int[,] paths = {{0,2},{1,1},{2,2},{2,3},{3,2},{4,3},{5,2}};
			for(int i=0;i<7;i++){
				TileStatus nTile = this.GetComponent<MainLogic>().main_Tile[paths[i,0],paths[i,1]].myStatus;
				nTile.myType = MainLogic.TILETYPE.Coin;
				nTile.myTurn = 0;
				nTile.myHp = 1;
				this.GetComponent<MainLogic>().main_Tile[paths[i,0],paths[i,1]].SetTileByStatus();
			}
			
			GameObject.Find ("AllTiles").GetComponent<UIPanel>().alpha = 0.23f;
			this.GetComponent<MainLogic>().NowBreaking = true;
			GameObject.Find ("Logic_Message").GetComponent<Message>().Tuto_Message(3000.0f,5000.0f," Coin !");
		}
		else if(level == 7){
			this.GetComponent<MainLogic>().NowBreaking = true;
			for(int i=0;i<MainLogic.TILE_SIZE;i++){
				for(int j=0;j<MainLogic.TILE_SIZE;j++){
					this.GetComponent<MainLogic>().main_Tile[i,j].myStatus = new TileStatus(i,j,UserData.Instance.Turn);
					this.GetComponent<MainLogic>().main_Tile[i,j].SetTileByStatus();
				}
			}
			
			GameObject.Find ("AllTiles").GetComponent<UIPanel>().alpha = 0.23f;
			this.GetComponent<MainLogic>().NowBreaking = true;
			GameObject.Find ("Logic_Message").GetComponent<Message>().Tuto_Message(3000.0f,5000.0f," Game Start !");
		}
	}
}
