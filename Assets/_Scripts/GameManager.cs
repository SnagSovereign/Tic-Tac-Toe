using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[Header("Player Turn Symbols")]
	[SerializeField] GameObject crossSymbol;
	[SerializeField] GameObject noughtSymbol;

	public static bool crossTurn = true;

	int [] grid = new int[9];

	int crossScore;
	int noughtScore;

	void Start()
    {
		for(int index = 0; index < grid.Length; index++)
        {
			grid[index] = 0;
        }
    }

	public void UpdateCell(Vector2 gridPos)
    {
		int cellValue = -1;
        if (crossTurn) { cellValue = Mathf.Abs(cellValue); }

		int index = ((int)gridPos.y * 3) + (int)gridPos.x;
		grid[index] = cellValue;
		//print(gridPos + " / grid[" + index + "] is " + cellValue);
    }

	public void SwitchTurn()
	{
		crossTurn = !crossTurn;
		crossSymbol.SetActive(!crossSymbol.activeSelf);
		noughtSymbol.SetActive(!noughtSymbol.activeSelf);
	}

	public void WinCheck()
    {
		int sum = 0;

		// vertical check
		for (int remainder = 0; remainder <= 2; remainder++)
        {
			for (int index = 0; index < 8; index++)
            {
				if (index % 3 == remainder)
                {
					sum += grid[index];
                }
            }
			if (PlayerWins(sum)) { return; }
			sum = 0;
        }

		// horizontal check
    }

	bool PlayerWins(int sum)
    {
		switch (sum)
		{
			case 3:
				crossScore++;
				print("cross wins: " + sum);
				break;
			case -3:
				noughtScore++;
				print("nought wins: " + sum);
				break;
			default:
				return false;
		}
		return true;
	}
}
