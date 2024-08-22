using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TigerentenschulSceneLogicScript : SceneLogicScriptWithClickableObjects
{
    public TMP_Text scoreText;
    public TMP_Text goldText;
    public Button punkteVerbessernButton;
    public TMP_Text punkteVerbessernButtonText;
    public Button geschwindigkeitErhohenbutton;
    public TMP_Text geschwindigkeitErhohenbuttonText;
    public EntenLaufScript ente;
    public TMP_Text punkteJeTargetText;
    public TMP_Text aktuelleGeschwindigkeitText;
    public TigerentenschuleSpawnScript spawnscript;
    public GameManager gameManager;
    public Button wettbewerbButton1;
    public Button wettbewerbButton2;
    public Button wettbewerbButton3;
    public Button wettbewerbButton4;
    public Button wettbewerbButton5;
    // Start is called before the first frame update
    void Start()
    {
        punkteVerbessernButton.onClick.AddListener(scoreAddErhohen);
        geschwindigkeitErhohenbutton.onClick.AddListener(enteGeschwindigkeitErhohen);
        wettbewerbButton1.onClick.AddListener(wettbewerbStartenButton1);
        wettbewerbButton2.onClick.AddListener(wettbewerbStartenButton2);
        wettbewerbButton3.onClick.AddListener(wettbewerbStartenButton3);
        wettbewerbButton4.onClick.AddListener(wettbewerbStartenButton4);
        wettbewerbButton5.onClick.AddListener(wettbewerbStartenButton5);

        spawnscript = GameObject.FindGameObjectWithTag("AllSpawner").GetComponent<TigerentenschuleSpawnScript>();
        refreshAllText();
        gameManager.berechneAlleaktuellenKosten();
    }

    private void scoreAddErhohen()
    {
        if (gameManager.scoreAddErhohen())
        {
            refreshAllText();
        }

    }



    private void enteGeschwindigkeitErhohen()
    {
        if (gameManager.enteGeschwindigkeitErhohen())
        {
            refreshAllText();
        }
    }

    //sehr schlecht so aber egal
    private void wettbewerbStartenButton1()
    {
        wettbewerbStartenButton(0);
    }

    //sehr schlecht so aber egal
    private void wettbewerbStartenButton2()
    {
        wettbewerbStartenButton(1);
    }
    //sehr schlecht so aber egal
    private void wettbewerbStartenButton3()
    {
        wettbewerbStartenButton(2);
    }
    //sehr schlecht so aber egal
    private void wettbewerbStartenButton4()
    {
        wettbewerbStartenButton(3);
    }

    private void wettbewerbStartenButton5()
    {
        wettbewerbStartenButton(4);
    }
    private void wettbewerbStartenButton(int stufe) {
        gameManager.wettbewerbsstufe = stufe;
        if (gameManager.wettbewerbBetreten())
        {
            SceneManager.LoadScene("Wettbewerbsscene");
            gameManager.lastSceneName = "Wettbewerbsscene";
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

    private void punkteJeTargetTextRefresh()
    {
        punkteJeTargetText.text = "Lernenergie \nMultiplikator \n" + gameManager.punkteJeTarget.ToString();
    }

    private void aktuelleGeschwindigkeitTextRefresh()
    {
        aktuelleGeschwindigkeitText.text = "akt. Geschwindigkeit: " + gameManager.entengeschwindigkeit.ToString();
    }

    private void buttonTextRefresh() {
        punkteVerbessernButtonText.text = "Besser Essen \nLernenergie Kosten: " + gameManager.punkteVerbessernKosten.ToString();
        geschwindigkeitErhohenbuttonText.text= "Geschwindigkeit erhöhen \nLernenergie Kosten: " + gameManager.geschwindigkeitVerbessernKosten.ToString();
    }


    private void refreshAllText()
    {
        scoreTextRefresh();
        goldTextRefresh();
        punkteJeTargetTextRefresh();
        aktuelleGeschwindigkeitTextRefresh();
        buttonTextRefresh();
    }

    public void enteArrived()
    {
        ente.hasTarget = false;
        ente.targetObject.delete_Target();
        deleteEnteSpawnTigerenteEnte();
        ente.targetObject = null;

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
        }
        if (ente != null)
        {
            ente.setNewTarget(targetVector);
        }
    }

    private void deleteEnteSpawnTigerenteEnte()
    {
        ente.deleteEnte();
        spawnscript.spawnTigernenteMitEnte();
    }
}
