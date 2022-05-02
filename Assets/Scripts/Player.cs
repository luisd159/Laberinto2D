using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ref: https://drive.google.com/file/d/1WiF2LwM-6WvEnas9vw32YrYPly9K0Qrv/view

public class Player : MonoBehaviour
{
    List<Cell> path;
    [SerializeField]
    private float moveSpeed = 2f;
    public delegate void MoveAction();
    public static event MoveAction OnMove;
    

    public Vector2 GetPosition => transform.position;

    // Index of current waypoint from which Enemy walks
    // to the next one
    private int waypointIndex = 0;

    // Update is called once per frame
    void Update()
    {
    
    }

    public void SetPath(List<Cell> path)
    {
        //ResetPosition();
        waypointIndex = 0;
        this.path = path;
    }

    public void ResetPosition()
    {
        transform.position = new Vector2(0, 0);
    }

    public void MovePlayer(Cell cell)
    {
          transform.position = new Vector3(cell.x, cell.y, 0);
        if (OnMove != null)
        {
            OnMove();
        }
    }


}
