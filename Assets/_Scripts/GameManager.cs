using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[Header("Player Turn Symbols")]
	[SerializeField] GameObject crossSymbol;
	[SerializeField] GameObject noughtSymbol;

	public static bool crossTurn = true;

	public void SwitchTurn()
	{
		crossTurn = !crossTurn;
		crossSymbol.SetActive(!crossSymbol.activeSelf);
		noughtSymbol.SetActive(!noughtSymbol.activeSelf);
	}

	void Start () {
		
	}
	
	void Update () {
		
	}
}
