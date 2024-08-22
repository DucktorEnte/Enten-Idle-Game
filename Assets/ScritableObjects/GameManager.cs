using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

[CreateAssetMenu(fileName ="neuer Spielstand",menuName = "neuer Spielstand")]
public class GameManager : ScriptableObject
{
    //this data needs to be saved
    public double score;
    public double gold;
    public double punkteJeTarget;
    public double entengeschwindigkeit;
    public string lastSceneName;
    public double maxTarget;
    public int freigeschalteteGerichte;


    //this data is always the same, or it is calculated
    public double punkteVerbessernKosten;
    public double punkteVerbessernKostenBase;
    public double geschwindigkeitVerbessernKosten;
    public double geschwindigkeitVerbessernKostenBase;
    public double portionanzahlerhoehenKosten;
    public double portionanzahlerhoehenKostenBase;
    public double wettbewerbsErtragBase;
    public double wettbewerbsKostenBase;
    public int wettbewerbsstufe;



    public List<Gericht> alleGerichte = new List<Gericht>();
    public List<Gericht> aktuelleGerichte = new List<Gericht>();
    public double neueGerichtKosten;
    public void addScore(int scoreMulti)
    {
        score = score + punkteJeTarget* scoreMulti;
    }


    public bool scoreAddErhohen()
    {
        Logger.Normal(score.ToString());
        if (score >= punkteVerbessernKosten)
        {
            score -= punkteVerbessernKosten;
            punkteJeTarget += 1;
            berechneAlleaktuellenKosten();
            return true;
        }
        return false;
    }



    public bool enteGeschwindigkeitErhohen()
    {
        if (score >= geschwindigkeitVerbessernKosten)
        {
            score -= geschwindigkeitVerbessernKosten;
            entengeschwindigkeit += 1;
            berechneAlleaktuellenKosten();
            return true;
        }
        return false;
        
    }

    public void addGold() {

        gold += Math.Ceiling(wettbewerbsErtragBase * Math.Pow(50, wettbewerbsstufe));
        //Logger.DevTest(Math.Ceiling(wettbewerbsErtragBase * Math.Pow(10, wettbewerbsstufe)).ToString());
    }

    public bool wettbewerbBetreten()
    {
        double wk = Math.Ceiling(wettbewerbsKostenBase * Math.Pow(100, wettbewerbsstufe));
        Logger.DevTest(wk.ToString());
        if (score >= wk)
        {

            score -= wk;
            return true;
        }
        return false;
    }

    public void addGericht() {
        if (gold >= neueGerichtKosten) {
            if (alleGerichte.OfType<Gericht>().Count() > aktuelleGerichte.OfType<Gericht>().Count())
            {
                aktuelleGerichte = alleGerichte.Take(aktuelleGerichte.OfType<Gericht>().Count() + 1).ToList();
                gold = gold - neueGerichtKosten;
                freigeschalteteGerichte = aktuelleGerichte.OfType<Gericht>().Count();
            }
            
        }
        berechneAlleaktuellenKosten();
    }

    public void portzionAnzahlErhoehen()
    {
        if (gold >= portionanzahlerhoehenKosten)
        {
            maxTarget = maxTarget + 1;
            gold = gold - portionanzahlerhoehenKosten;

        }
        berechneAlleaktuellenKosten();
    }

    public void berechneAlleaktuellenKosten()
    {
        berechneNeueGerichtKosten();
        berechnepunkteVerbessernKostenNeu();
        berechnegeschwindigkeitVerbessernKostenNeu();
        berechneFreigeschalteteGerichteNeu();
        berechnePortionanzahlerhoehenKostenNeu();
    }

    private void berechneNeueGerichtKosten()
    {
        if (aktuelleGerichte.OfType<Gericht>().Count() == 1) 
        {
            neueGerichtKosten = 10;
        }
        if (aktuelleGerichte.OfType<Gericht>().Count() == 2)
        {
            neueGerichtKosten = 100;
        }
        if (aktuelleGerichte.OfType<Gericht>().Count() == 3)
        {
            neueGerichtKosten = 1200;
        }
        if (aktuelleGerichte.OfType<Gericht>().Count() == 4)
        {
            neueGerichtKosten = 30000;
        }
        if (aktuelleGerichte.OfType<Gericht>().Count() == 5)
        {
            neueGerichtKosten = 1000000;
        }

        if (aktuelleGerichte.OfType<Gericht>().Count() >5)
        {
            neueGerichtKosten = 999999999999;
        }
    }

    private void berechnepunkteVerbessernKostenNeu() {
        punkteVerbessernKosten= Math.Ceiling(punkteVerbessernKostenBase * Math.Pow(1.1f, punkteJeTarget-1)) ;
    }

    private void berechnegeschwindigkeitVerbessernKostenNeu()
    {
        geschwindigkeitVerbessernKosten = Math.Ceiling(geschwindigkeitVerbessernKostenBase * Math.Pow(1.8f, entengeschwindigkeit - 5));
    }

    private void berechneFreigeschalteteGerichteNeu() {
        aktuelleGerichte = alleGerichte.Take(freigeschalteteGerichte).ToList();
    }

    private void berechnePortionanzahlerhoehenKostenNeu()
    {
        portionanzahlerhoehenKosten = Math.Ceiling(portionanzahlerhoehenKostenBase * Math.Pow(2.7f, maxTarget-1));
    }
}
