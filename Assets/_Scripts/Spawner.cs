using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour 
{
    GameManager GM;

    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
    }

    private void OnMouseDown()
    {
        Spawn(GetSquareClicked());
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return SnapToGrid(worldPos);
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        return new Vector2(Mathf.RoundToInt(rawWorldPos.x), Mathf.RoundToInt(rawWorldPos.y));
    }

    private void Spawn(Vector2 gridPos)
    {
        string symbol;
        if (GameManager.crossTurn) { symbol = "cross"; }
        else { symbol = "nought"; }

        Instantiate(Resources.Load<GameObject>(symbol), new Vector3(gridPos.x, gridPos.y, -0.5f), transform.rotation);
        GM.UpdateCell(gridPos);
        GM.WinCheck();
        GM.SwitchTurn();
    }
}
