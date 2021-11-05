using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {

            }
            return instance;
        }
    }

    public int score { get; set; }

    public Player player { get; private set; }

    private void Awake()
    {
        score = 0;
        instance = this;

        player = GameObject.FindWithTag("Player").GetComponent<Player>();

    }

}