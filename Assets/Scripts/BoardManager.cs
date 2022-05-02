using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    [SerializeField] private Cell CellPrefab;
    [SerializeField] private Player PlayerPrefab;
    [SerializeField] private Enemigo EnemigoPrefab;
    private Grid grid;
    public Player player;
    private Enemigo enemigo;
    [SerializeField]
    private float moveSpeed = 2f;
    

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {

        grid = new Grid(10, 10, 1, CellPrefab);

        Cell cellplayer = grid.GetGridObject(Random.Range(0, 10), Random.Range(0, 10));
        if (cellplayer.isWalkable)
        {
            player = Instantiate(PlayerPrefab, new Vector2(cellplayer.x, cellplayer.y), Quaternion.identity);
        }
        else
        {
            while (!cellplayer.isWalkable)
            {
                cellplayer = grid.GetGridObject(Random.Range(0, 10), Random.Range(0, 10));
            }
            player = Instantiate(PlayerPrefab, new Vector2(cellplayer.x, cellplayer.y), Quaternion.identity);
        }

        Cell enemy = grid.GetGridObject(Random.Range(0, 10), Random.Range(0, 10));
        if (cellplayer.isWalkable)
        {
            enemigo = Instantiate(EnemigoPrefab, new Vector2(enemy.x, enemy.y), Quaternion.identity);
        }
        else
        {
            while (!cellplayer.isWalkable)
            {
                enemy = grid.GetGridObject(Random.Range(0, 10), Random.Range(0, 10));
            }
            enemigo = Instantiate(EnemigoPrefab, new Vector2(enemy.x, enemy.y), Quaternion.identity);
        }
          
    }


    public void CellMouseClick(int x, int y)
    {
        List<Cell> path = PathManager.Instance.FindPath(grid, (int)player.GetPosition.x, (int)player.GetPosition.y, x, y);
        player.SetPath(path);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Cell c = grid.GetGridObject((int)player.GetPosition.x+1, (int)player.GetPosition.y);
            if (c.isWalkable)
            {
                player.MovePlayer(c);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Izquierda");
            Cell c = grid.GetGridObject((int)player.GetPosition.x - 1, (int)player.GetPosition.y);
            if (c.isWalkable)
            {
                player.MovePlayer(c);
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Arriba");
            Cell c = grid.GetGridObject((int)player.GetPosition.x, (int)player.GetPosition.y+1);
            if (c.isWalkable)
            {
                player.MovePlayer(c);
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Abajo");
            Cell c = grid.GetGridObject((int)player.GetPosition.x, (int)player.GetPosition.y-1);
            if (c.isWalkable)
            {
                player.MovePlayer(c);
            }
        }
    }

}
