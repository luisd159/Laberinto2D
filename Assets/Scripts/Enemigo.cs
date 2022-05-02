using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public Vector2 GetPosition => transform.position;
    public Player player = BoardManager.Instance.player;

    void Start()
    {
        
    }

    public void OnEnable()
    {
        Player.OnMove += Chasing;
    }

    public void OnDisable()
    {
        Player.OnMove += Chasing;
    }

    public void Chasing()
    {
        Debug.Log("HOLAA");
        transform.position = new Vector3(player.GetPosition.x, player.GetPosition.y,0);
    }
    
}
