using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Tilemaps;

public partial class CursorController : MonoBehaviour {
    public DualGridTilemap dualGridTilemap;

    private Vector3 offset = new Vector3(0.5f, 0.5f, -1);
    private Camera mainCamera;

    void Awake() {
        mainCamera = Camera.main;
    }
        
    
    void Update() {
        var mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector3Int tilePos = GetWorldPosTile(mouseWorldPos);
        transform.position = tilePos + offset;

        if (Input.GetMouseButton(0)) {
            dualGridTilemap.SetCell(tilePos, dualGridTilemap.dirtPlaceholderTile);
        } else if (Input.GetMouseButton(1)) {
            dualGridTilemap.SetCell(tilePos, dualGridTilemap.grassPlaceholderTile);
        }
    }

    public static Vector3Int GetWorldPosTile(Vector3 worldPos) {
        int xInt = Mathf.FloorToInt(worldPos.x);
        int yInt = Mathf.FloorToInt(worldPos.y);
        return new(xInt, yInt, 0);
    }
}
