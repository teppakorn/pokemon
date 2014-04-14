using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
	public GameObject Green;
	public GameObject Rock;
	public GameObject Selected;
	public Node pos = new Node();

	public enum TILE{GREEN,ROCK,SELECTED};
	private TILE type = TILE.GREEN;

	public void SetTile(TILE a){
		if(TILE.GREEN==a){
			SetAllInvisible();
			Green.SetActive(true);
			type = TILE.GREEN;
		}else if(TILE.ROCK==a){
			SetAllInvisible();
			Green.SetActive(true);
			Rock.SetActive(true);
			type = TILE.ROCK;
		}else{
			SetAllInvisible();
			Selected.SetActive(true);
			type = TILE.SELECTED;
		}
	}

	public void  SetPos(int i,int j){
		pos.i = i;
		pos.j = j;
	}

	public void SelectTile(){
		if(!isPass())return;
		SetTile(TILE.SELECTED);
	}
	public void UnSelectTile(){
		if(!isPass())return;
		SetTile(TILE.GREEN);
	}

	public bool isPass(){
		if(type==TILE.ROCK){
			return false;
		}
		return true;
	}


	private void SetAllInvisible(){
		Green.SetActive(false);
		Rock.SetActive(false);
		Selected.SetActive(false);
	}
}
