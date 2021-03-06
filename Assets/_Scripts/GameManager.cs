﻿using System.Collections;
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
			for (int index = 0; index <= 8; index++)
            {
				if (index % 3 == remainder)
                {
					sum += grid[index];
                }
            }
			if (CheckSum(sum)) { return; } //if a win is detected: exit the method
			sum = 0;
        }

		// horizontal check
		for(int maxIndex = 2; maxIndex <= 8; maxIndex += 3)
        {
			for (int index = 0; index <= 8; index++)
			{
				if (index >= maxIndex - 3 && index <= maxIndex)
				{
					sum += grid[index];
				}
			}
			if (CheckSum(sum)) { return; } //if a win is detected: exit the method
			sum = 0;
		}

		// diagonal check
		sum = grid[0] + grid[4] + grid[8]; //add up the grid values from bottom left to top right
		if (CheckSum(sum)) { return; } //if a win is detected: exit the method
		sum = grid[2] + grid[4] + grid[6]; //add up the grid values from bottom right to top left
		CheckSum(sum);
	}

	bool CheckSum(int sum)
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
