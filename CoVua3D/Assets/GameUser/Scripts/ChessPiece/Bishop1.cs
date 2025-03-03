using System.Collections.Generic;
using UnityEngine;

public class Bishop1 : ChessPiece
{
    public override List<Vector2Int> GetAvailableMoves(ref ChessPiece[,] board, int tileCountX, int tileCountY)
    {
        List<Vector2Int> r = new List<Vector2Int>();

        //Top right
        for(int x=curentX+1,y=curentY+1;x<tileCountX&&y<tileCountY;x++,y++)
        {
            if (board[x,y] == null)
                r.Add(new Vector2Int(x,y));
            else
            {
                if (board[x,y].team != team)
                    r.Add(new Vector2Int(x,y));

                break;
            }
        }

        //Top left
        for (int x = curentX - 1, y = curentY + 1; x >=0 && y < tileCountY; x--, y++)
        {
            if (board[x, y] == null)
                r.Add(new Vector2Int(x, y));
            else
            {
                if (board[x, y].team != team)
                    r.Add(new Vector2Int(x,y));

                break;
            }
        }

        //Bottom right
        for (int x = curentX + 1, y = curentY - 1; x < tileCountX && y >= 0; x++, y--)
        {
            if (board[x, y] == null)
                r.Add(new Vector2Int(x, y));
            else
            {
                if (board[x, y].team != team)
                    r.Add(new Vector2Int(x,y));

                break;
            }
        }

        //Bottom left
        for (int x = curentX - 1, y = curentY - 1; x >= 0 && y >= 0; x--, y--)
        {
            if (board[x, y] == null)
                r.Add(new Vector2Int(x, y));
            else
            {
                if (board[x, y].team != team)
                    r.Add(new Vector2Int(x,y));

                break;
            }
        }

        return r;
    }
}

