using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[Header("Player Turn Symbols")]
	[SerializeField] GameObject crossSymbol;
	[SerializeField] GameObject noughtSymbol;

	public static bool crossTurn = true;

	enum CellState { empty, cross, nought }
	CellState[] grid = new CellState[9];

	int crossScore;
	int noughtScore;

	void Start()
    {
		for(int index = 0; index < grid.Length; index++)
        {
			grid[index] = CellState.empty;
        }
    }

	public void UpdateCell(Vector2 gridPos)
    {
		CellState currentSymbol;
        if (crossTurn) { currentSymbol = CellState.cross; }
		else { currentSymbol = CellState.nought; }

		int index = ((int)gridPos.y * 3) + (int)gridPos.x;
		grid[index] = currentSymbol;
		//print(gridPos + " / grid[" + index + "] is a " + currentSymbol);
    }

	public void SwitchTurn()
	{
		crossTurn = !crossTurn;
		crossSymbol.SetActive(!crossSymbol.activeSelf);
		noughtSymbol.SetActive(!noughtSymbol.activeSelf);
	}

	public void WinCheck()
    {
		// currently only checks horizontally for a win
		// NEEDS fixing and more efficiency
		for (int index = 0; index < grid.Length - 2; index += 3)
        {
			if (grid[index] == grid[index + 1] && grid[index] == grid[index + 2])
			{
				if (grid[index] == CellState.cross)
                {
					print("cross wins!");
                }
				else if (grid[index] == CellState.nought)
				{
					print("nought wins!");
				}
            }
        }
    }
}
