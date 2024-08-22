
using UnityEngine;
using TMPro;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Linq;
using static UnityEngine.GraphicsBuffer;

public class EntenSceneLogicScript : SceneLogicScriptWithClickableObjects
{
    public TMP_Text scoreText;
    public TMP_Text goldText;
    public EntenLaufScript ente;
    public EntenSceneSpawner spawnscript;
    private bool hasTigerente;
    public GameManager gameManager;

    private void Start()
    {
        //DontDestroyOnLoad(this);
        ente = GameObject.FindGameObjectWithTag("Ente").GetComponent<EntenLaufScript>();
        ente.moveSpeed = (float)gameManager.entengeschwindigkeit;
        refreshAllText();
        hasTigerente = false;
        spawnscript = GameObject.FindGameObjectWithTag("AllSpawner").GetComponent<EntenSceneSpawner>();
        spawnNewTarget();
        if (gameManager.gold != 0) {
            spawnscript.spawnKuechentuer();
        }
        gameManager.berechneAlleaktuellenKosten();
    }



    public void addScore(int scoreMulti)
    {
        gameManager.addScore(scoreMulti);
        refreshAllText();
        if (hasTigerente == false && gameManager.score >= 10)
        {
            spawnscript.spawnTigerente();
            hasTigerente = true;
        }
    }






    // Alle Texte Refreshen:

    private void scoreTextRefresh()
    {
        scoreText.text = "Lernenergie: " + gameManager.score.ToString();
    }

    private void goldTextRefresh()
    {
        goldText.text = "Gold: " + gameManager.gold.ToString();
    }


    private void refreshAllText()
    {
        scoreTextRefresh();
        goldTextRefresh();
    }

    private void spawnNewTarget()
    {

        for (int i= clickableObjects.OfType<TargetScript>().Count(); i < gameManager.maxTarget; i++) 
        {
            spawnscript.spawnGerichtTarget();
        }
        
    }




    override protected void leftMousButtonClick()
    {
        base.leftMousButtonClick();
        if (targetHit == true)
        {
            ente.hasTarget = true;
            ente.targetObject = targetObject;
        }
        else
        {
            if (ente != null)
            {
                ente.hasTarget = false;
                ente.targetObject = null;
            }

            ente.hasTarget = false;
            ente.targetObject = null;
        }
        if (ente != null)
        {
            ente.setNewTarget(targetVector);
        }
    }


    public void enteArrived() {
        ente.hasTarget = false;
        ente.targetObject.delete_Target();
        if (ente.targetObject.GetType() == typeof(TigerEntenScript))
        {
            deleteEnteSpawnTigerenteEnte();
        }
        else if (ente.targetObject.GetType() == typeof(TargetScript)) {
            spawnNewTarget();
        }
        ente.targetObject = null;
    }

    private void deleteEnteSpawnTigerenteEnte() {
        ente.deleteEnte();
        spawnscript.spawnTigernenteMitEnte();
    }
}