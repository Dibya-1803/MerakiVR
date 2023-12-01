using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set; }
    //public AudioManager AudioManager { get; private set; }
    public UI_manager UIManager { get; private set; }
    public GameManager gameManager { get; private set; }
    public DataManager dataManager { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
       // AudioManager = GetComponentInChildren<AudioManager>();
        UIManager = GetComponentInChildren<UI_manager>();
        gameManager = GetComponentInChildren<GameManager>();
        dataManager = GetComponentInChildren<DataManager>();
    }
}
