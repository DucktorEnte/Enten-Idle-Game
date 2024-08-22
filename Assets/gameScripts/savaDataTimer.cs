using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savaDataTimer : MonoBehaviour
{
    float timer = 0.0f;
    public GameManager gameManager;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        timer = 0.0f;
    }

    

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 10.0f)
        {
            Savesystem.saveGameManager(gameManager);
            timer = 0.0f;
        }
    }
}
