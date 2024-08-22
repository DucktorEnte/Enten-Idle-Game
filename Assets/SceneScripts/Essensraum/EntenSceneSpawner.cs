using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class EntenSceneSpawner : SceneSpawner
{
    private GameObject targetObject;
    public EntenLaufScript entenScript;
    public GameObject ente;
    public GameObject tigerente;
    public GameObject tigerenteMitEnte;
    public Gericht[] allGerichte;
    public GameObject kuechentuer;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        //allGerichte = Resources.LoadAll<Gericht>("ScriptableObjectsEntities/Gerichte/GerichtObjects");
        allGerichte = gameManager.aktuelleGerichte.ToArray();

    }



    private void spawnEnte()
    {
        Instantiate(ente, transform.position + new Vector3(0, -1, 0), transform.rotation);
    }

    public void spawnTigerente()
    {
        Instantiate(tigerente, transform.position + new Vector3(0, 2, 0), transform.rotation);
    }


    public void spawnEnteundTigerenteSeperat()
    {
        spawnEnte();
        spawnTigerente();
    }
    public void spawnTigernenteMitEnte()
    {
        Instantiate(tigerenteMitEnte, transform.position + new Vector3(0, 10, 0), transform.rotation);
    }



    public void spawnGerichtTarget() {
        var gericht = allGerichte[Random.Range(0, allGerichte.Length)];
        targetObject = Instantiate(gericht.food.gameObject, new Vector3(Random.Range(-7f, 7f), Random.Range(-3.5f, 3.5f), transform.position.z), transform.rotation);
        var target = targetObject.AddComponent<TargetScript>();
        target.setGericht(gericht);
        target.SetAnimator(targetObject.GetComponent<Animator>());
        targetObject.AddComponent<BoxCollider2D>();
        //targetObject.GetComponent<SpriteRenderer>().sprite = targetObject_prototyp.
    }


    public void spawnKuechentuer()
    {
        Instantiate(kuechentuer, transform.position + new Vector3(-9.2f, 4, 0), transform.rotation);
    }

}
