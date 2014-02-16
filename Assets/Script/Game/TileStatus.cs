using UnityEngine;
using System.Collections;

public class TileStatus : MonoBehaviour {
	public MainLogic.TILETYPE myType;
	public int myX,myY;
	public int myHp,myAttack;
	public int myTurn;
	public int onClick;
	public TileStatus(int y,int x,int Turn){
		// ㅅㅐㄹㅗ ㅅㅓㄴ ㅇㅓㄴ 
		myY = y;
		myX = x;
		myTurn = 0;
		myHp = 1;
		myAttack = 1;
		NewType ();
		if(myType == MainLogic.TILETYPE.Enemy){
			myHp = (int)(Random.value * Turn/2.0f) + 5+(int)(Turn/3.0f);
			myAttack = (int)(Random.value * Turn/2.0f) + 5+(int)(Turn/5.0f);
		}
	}
	public void NewType(){
		int t;
		do{
			t = (int)(Random.value * 5.0f);
		}while(t == 5);
		
		switch(t){
		case 0: myType = MainLogic.TILETYPE.Enemy; break;
		case 1: myType = MainLogic.TILETYPE.Sword; break;
		case 2: myType = MainLogic.TILETYPE.Storm; break;
		case 3: myType = MainLogic.TILETYPE.Coin; break;
		case 4: myType = MainLogic.TILETYPE.Potion; break;
		}
	}
	public static bool EqualType(MainLogic.TILETYPE fType,MainLogic.TILETYPE sType){
		if(fType == sType){
			return true;
		}
		else if(fType == MainLogic.TILETYPE.Sword && sType == MainLogic.TILETYPE.Enemy){
			return true;
		}
		else if (fType == MainLogic.TILETYPE.Enemy && sType == MainLogic.TILETYPE.Sword){
			return true;
		}
		return false;
	}
}
