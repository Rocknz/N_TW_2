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
			string msgs = "When you push a tile, \n every tile linked with 8-direction \n is chosen. \nIf you take away your finger \n on the tile you pushed,\n every chosen tile disappear.";
			for(int i=0;i<MainLogic.TILE_SIZE;i++){
				for(int j=0;j<MainLogic.TILE_SIZE;j++){
					TileStatus nTile = this.GetComponent<MainLogic>().main_Tile[i,j].myStatus;
					nTile.myType = MainLogic.TILETYPE.X;
					nTile.myTurn = 0;
					nTile.myHp = 1;
					this.GetComponent<MainLogic>().main_Tile[i,j].SetTileByStatus();
				}
			}
			
			int[,] paths = {{2,0},{3,1},{2,2},{1,3},{2,4},{2,5},{2,6}};
			for(int i=0;i<7;i++){
				TileStatus nTile = this.GetComponent<MainLogic>().main_Tile[paths[i,0],paths[i,1]].myStatus;
				nTile.myType = MainLogic.TILETYPE.Coin;
				nTile.myTurn = 0;
				nTile.myHp = 1;
				this.GetComponent<MainLogic>().main_Tile[paths[i,0],paths[i,1]].SetTileByStatus();
			}
			
			
			GameObject.Find ("AllTiles").GetComponent<UIPanel>().alpha = 0.23f;
			this.GetComponent<MainLogic>().NowBreaking = true;
			GameObject.Find ("Logic_Message").GetComponent<Message>().Tuto_Message(3000.0f,5000.0f,msgs);
		}
		else if(level == 5){
			string msgs = "Each Jelly-P attacks you every turn.\n Jelly-P tiles can be linked with \n  sword tiles. \n Sword tiles increase \n your damage in proportion to \n ATK and the number of sword tiles.";
			for(int i=0;i<MainLogic.TILE_SIZE;i++){
				for(int j=0;j<MainLogic.TILE_SIZE;j++){
					TileStatus nTile = this.GetComponent<MainLogic>().main_Tile[i,j].myStatus;
					nTile.myType = MainLogic.TILETYPE.X;
					nTile.myTurn = 0;
					nTile.myHp = 1;
					this.GetComponent<MainLogic>().main_Tile[i,j].SetTileByStatus();
				}
			}
			
			int[,] paths = {{0,2},{2,2},{2,3},{3,2},{4,3},{5,2}};
			for(int i=0;i<6;i++){
				TileStatus nTile = this.GetComponent<MainLogic>().main_Tile[paths[i,0],paths[i,1]].myStatus;
				nTile.myType = MainLogic.TILETYPE.Enemy;
				nTile.myTurn = 0;
				nTile.myHp = 1;
				this.GetComponent<MainLogic>().main_Tile[paths[i,0],paths[i,1]].SetTileByStatus();
			}
			
			TileStatus n2Tile = this.GetComponent<MainLogic>().main_Tile[1,1].myStatus;
			n2Tile.myType = MainLogic.TILETYPE.Sword;
			n2Tile.myTurn = 0;
			n2Tile.myHp = 1;
			this.GetComponent<MainLogic>().main_Tile[1,1].SetTileByStatus();


			GameObject.Find ("AllTiles").GetComponent<UIPanel>().alpha = 0.23f;
			this.GetComponent<MainLogic>().NowBreaking = true;
			GameObject.Find ("Logic_Message").GetComponent<Message>().Tuto_Message_2(3000.0f,5000.0f,msgs);
		}
		else if(level == 6){
			string msgs = "For pushing a tile, \n your damage appear on top of screen. \n If your damage is more than or equal to \n the HP of a Jelly-P, \n there appear \"X\" mark, \n and Jelly-p disappear.";
			GameObject.Find ("AllTiles").GetComponent<UIPanel>().alpha = 0.23f;
			this.GetComponent<MainLogic>().NowBreaking = true;
			GameObject.Find ("Logic_Message").GetComponent<Message>().Tuto_Message_2(3000.0f,5000.0f,msgs);
		}
		else if(level == 7){
			string msgs = "\n If your damage is less than \n the HP of a Jelly-P, \n it decrease as your damage, \nbut Jelly-P doesn't disappear.";
			GameObject.Find ("AllTiles").GetComponent<UIPanel>().alpha = 0.23f;
			this.GetComponent<MainLogic>().NowBreaking = true;
			GameObject.Find ("Logic_Message").GetComponent<Message>().Tuto_Message(3000.0f,5000.0f,msgs);
		}
		else if(level == 8){
			string msgs = "Each potion tile \n restore 3% of your max HP. ";
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
				nTile.myType = MainLogic.TILETYPE.Potion;
				nTile.myTurn = 0;
				nTile.myHp = 1;
				this.GetComponent<MainLogic>().main_Tile[paths[i,0],paths[i,1]].SetTileByStatus();
			}


			GameObject.Find ("AllTiles").GetComponent<UIPanel>().alpha = 0.23f;
			this.GetComponent<MainLogic>().NowBreaking = true;
			GameObject.Find ("Logic_Message").GetComponent<Message>().Tuto_Message(3000.0f,5000.0f,msgs);
		}
		else if(level == 9){
			string msgs = "Each coin tile give you 1 coin. \n Received coins can be used for \n upgrading your ability parameter, \n on the scene of STATUS, \n on top right of the screen. ";
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
			GameObject.Find ("Logic_Message").GetComponent<Message>().Tuto_Message(3000.0f,5000.0f,msgs);
		}
		else if(level == 10){
			string msgs = "You receive the storms in proportion \n to INT and the number of storm tiles.\n If you reach max storm,\n every tile on the screen disappear.\n In this time, the effects of every tile \n are applied.";

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
				nTile.myType = MainLogic.TILETYPE.Storm;
				nTile.myTurn = 0;
				nTile.myHp = 1;
				this.GetComponent<MainLogic>().main_Tile[paths[i,0],paths[i,1]].SetTileByStatus();
			}
			
			GameObject.Find ("AllTiles").GetComponent<UIPanel>().alpha = 0.23f;
			this.GetComponent<MainLogic>().NowBreaking = true;
			GameObject.Find ("Logic_Message").GetComponent<Message>().Tuto_Message(3000.0f,5000.0f,msgs);
		}
		else if(level == 11){
			string msgs = "If you complete the combo \n on bottom of the screen in order, \n you can receive additional coins.\n If your HP \n (on bottom left of the screen) \n becomes 0 by Jelly-Ps' attack,\n Game Over.";
			
			for(int i=0;i<MainLogic.TILE_SIZE;i++){
				for(int j=0;j<MainLogic.TILE_SIZE;j++){
					TileStatus nTile = this.GetComponent<MainLogic>().main_Tile[i,j].myStatus;
					nTile.myType = MainLogic.TILETYPE.X;
					nTile.myTurn = 0;
					nTile.myHp = 1;
					this.GetComponent<MainLogic>().main_Tile[i,j].SetTileByStatus();
				}
			}
			GameObject.Find ("AllTiles").GetComponent<UIPanel>().alpha = 0.23f;
			this.GetComponent<MainLogic>().NowBreaking = true;
			GameObject.Find ("Logic_Message").GetComponent<Message>().Tuto_Message_2(3000.0f,5000.0f,msgs);
		}
		else if(level == 12){
			string msgs = "On the scene of game over, \n if you push \"menu\" you receive \n an equipment by gatcha. \n You can equip that on the scene \n of STATUS of title screen. \n The ability parameter of an equipment \n apply in game.";
			
			for(int i=0;i<MainLogic.TILE_SIZE;i++){
				for(int j=0;j<MainLogic.TILE_SIZE;j++){
					TileStatus nTile = this.GetComponent<MainLogic>().main_Tile[i,j].myStatus;
					nTile.myType = MainLogic.TILETYPE.X;
					nTile.myTurn = 0;
					nTile.myHp = 1;
					this.GetComponent<MainLogic>().main_Tile[i,j].SetTileByStatus();
				}
			}
			GameObject.Find ("AllTiles").GetComponent<UIPanel>().alpha = 0.23f;
			this.GetComponent<MainLogic>().NowBreaking = true;
			GameObject.Find ("Logic_Message").GetComponent<Message>().Tuto_Message_2(3000.0f,5000.0f,msgs);
		}
		else if(level == 13){
			for(int i=0;i<MainLogic.TILE_SIZE;i++){
				for(int j=0;j<MainLogic.TILE_SIZE;j++){
					this.GetComponent<MainLogic>().main_Tile[i,j].myStatus = new TileStatus(i,j,UserData.Instance.Turn);
					this.GetComponent<MainLogic>().main_Tile[i,j].SetTileByStatus();
				}
			}
			
			GameObject.Find ("AllTiles").GetComponent<UIPanel>().alpha = 0.23f;
			this.GetComponent<MainLogic>().NowBreaking = true;
			GameObject.Find ("Logic_Message").GetComponent<Message>().Tuto_Message(3000.0f,5000.0f," Game Start !");

			UserData.Instance.IsTutorial = -1;
		}
	}
}
