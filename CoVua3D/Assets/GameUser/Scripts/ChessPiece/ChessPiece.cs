﻿using System.Collections.Generic;
using UnityEngine;


public enum ChessPieceType
{
    None1=0,
    Pawn1=1, //Tốt
    Rook1=2, //Xe
    Knight1=3,//Mã
    Bishop1=4,//Tượng
    Queen1=5,// Hậu
    King1=6 //Vua
}
public class ChessPiece : MonoBehaviour
{
    public int team;
    public int curentX;
    public int curentY;
    public ChessPieceType type;

    private Vector3 desiredPosition;
    private Vector3 desiredScale=Vector3.one;

    private void Start()
    {
        //transform.rotation = Quaternion.Euler((team == 0) ? Vector3.one : new Vector3(0, 90, 0));

    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 10);
        transform.localScale = Vector3.Lerp(transform.localScale, desiredScale, Time.deltaTime * 10);

    }

    public virtual List<Vector2Int> GetAvailableMoves(ref ChessPiece[,] board, int tileCountX,int tileCountY)
    {
        List<Vector2Int> r= new List<Vector2Int>();

        r.Add(new Vector2Int(3, 3));
        r.Add(new Vector2Int(3, 4));
        r.Add(new Vector2Int(4, 3));
        r.Add(new Vector2Int(4, 4));


        return r;
    }

    public virtual SpecialMove GetSpecialMoves(ref ChessPiece[,] board, ref List<Vector2Int[]> moveList, ref List<Vector2Int > availableMoves)
    {
        return SpecialMove.None;
    }

    public virtual void SetPosition(Vector3 position, bool force = false)
    {
        desiredPosition = position;
        if (force)
            transform.position = desiredPosition;
    }
    public virtual void SetScale(Vector3 scale, bool force = false)
    {
        desiredScale = scale;
        if (force)
            transform.localScale = desiredScale;
    }
}
