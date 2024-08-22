using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KuecheLogicScript : SceneLogicScriptWithClickableObjects
{
    public TMP_Text scoreText;
    public TMP_Text goldText;

    public KuecheSpawnerScript spawnscript;
    public EntenLaufScript ente;
    public GameManager gameManager;

    public Button gerichtHinzufugenButton;
    public TMP_Text neuesGerichtButtonText;

    public Button portionButton;
    public TMP_Text portionButtonText;

    public GameObject gericht_1;
    public GameObject gericht_2;
    public GameObject gericht_3;
    public GameObject gericht_4;
    public GameObject gericht_5;
    public GameObject gericht_6;


    // Start is called before the first frame update
    void Start()
    {
        ente = GameObject.FindGameObjectWithTag("Ente").GetComponent<EntenLaufScript>();
        ente.kuecheLogicScript = this;
        spawnscript = GameObject.FindGameObjectWithTag("AllSpawner").GetComponent<KuecheSpawnerScript>();
        spawnscript.spawnKuechentuer();
        gerichtHinzufugenButton.onClick.AddListener(gerichtHinzufugen);
        portionButton.onClick.AddListener(portionAnzahlErhoehen);


        refreshAllText();
        showFreigeschalteteGerichte();

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


    private void scoreTextRefresh()
    {
        scoreText.text = "Lernenergie: " + gameManager.score.ToString();
    }

    private void goldTextRefresh()
    {
        goldText.text = "Gold: " + gameManager.gold.ToString();
    }

    private void gerichtHinzufugenButtonTextRefresh()
    {
        neuesGerichtButtonText.text = "Neues Gericht Kochen \n Gold Kosten: " + gameManager.neueGerichtKosten.ToString();
    }

    private void portionButtonTextRefresh()
    {
        portionButtonText.text = "Portionsanzahl steigern \n Gold Kosten: " + gameManager.portionanzahlerhoehenKosten.ToString();
    }

    

    private void refreshAllText()
    {
        gameManager.berechneAlleaktuellenKosten();
        scoreTextRefresh();
        goldTextRefresh();
        gerichtHinzufugenButtonTextRefresh();
        portionButtonTextRefresh();
    }

    private void gerichtHinzufugen() {
        gameManager.addGericht();
        refreshAllText();
        showFreigeschalteteGerichte();
    }


    private void portionAnzahlErhoehen()
    {
        gameManager.portzionAnzahlErhoehen();
        refreshAllText();
        showFreigeschalteteGerichte();
    }

    private void showFreigeschalteteGerichte() {
        //keine Lust das jetzt richtig zu machen, deswegen nur das hier es geht schneller so

        if (gameManager.aktuelleGerichte.OfType<Gericht>().Count() > 0) {
            gericht_1.GetComponent<SpriteRenderer>().enabled = true;
        }
        else {
            gericht_1.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (gameManager.aktuelleGerichte.OfType<Gericht>().Count() > 1)
        {
            gericht_2.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            gericht_2.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (gameManager.aktuelleGerichte.OfType<Gericht>().Count() > 2)
        {
            gericht_3.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            gericht_3.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (gameManager.aktuelleGerichte.OfType<Gericht>().Count() > 3)
        {
            gericht_4.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            gericht_4.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (gameManager.aktuelleGerichte.OfType<Gericht>().Count() > 4)
        {
            gericht_5.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            gericht_5.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (gameManager.aktuelleGerichte.OfType<Gericht>().Count() > 5)
        {
            gericht_6.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            gericht_6.GetComponent<SpriteRenderer>().enabled = false;
        }
    }


}
