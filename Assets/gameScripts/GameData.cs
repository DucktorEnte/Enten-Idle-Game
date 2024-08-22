using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public double score;
    public double gold;
    public double punkteJeTarget;
    public double entengeschwindigkeit;
    public string lastSceneName;
    public double maxTarget;
    public int freigeschalteteGerichte;

    public GameData(GameManager gameManager)
    {
        this.score = gameManager.score;
        this.gold = gameManager.gold;
        this.punkteJeTarget = gameManager.punkteJeTarget;
        this.entengeschwindigkeit = gameManager.entengeschwindigkeit;
        this.lastSceneName = gameManager.lastSceneName;
        this.maxTarget = gameManager.maxTarget;
        this.freigeschalteteGerichte = gameManager.freigeschalteteGerichte;
    }

    public GameData()
    {
        this.score = 0;
        this.gold = 0;
        this.punkteJeTarget = 1;
        this.entengeschwindigkeit = 5;
        this.lastSceneName = "Essensraum";
        this.maxTarget = 1;
        this.freigeschalteteGerichte = 1;
    }


    public GameManager loadDataToGameManager(GameManager gameManager) {

        gameManager.score = this.score;
        gameManager.gold = this.gold;
        gameManager.punkteJeTarget = this.punkteJeTarget;
        gameManager.entengeschwindigkeit = this.entengeschwindigkeit;
        gameManager.lastSceneName = this.lastSceneName;
        gameManager.maxTarget = this.maxTarget;
        gameManager.freigeschalteteGerichte = this.freigeschalteteGerichte;

        gameManager.berechneAlleaktuellenKosten();
        return gameManager;
    }
}
