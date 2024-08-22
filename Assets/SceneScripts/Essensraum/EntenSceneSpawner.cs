using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class EntenSceneSpawner : SceneSpawner
{
    public GameObject targetObject_prototyp;
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
        targetObject = Instantiate(targetObject_prototyp, new Vector3(Random.Range(-7f, 7f), Random.Range(-3.5f, 3.5f), transform.position.z), transform.rotation);
        targetObject.GetComponent<TargetScript>().setGericht(allGerichte[Random.Range(0, allGerichte.Length)]);
    }


    public void spawnKuechentuer()
    {
        Instantiate(kuechentuer, transform.position + new Vector3(-9.2f, 4, 0), transform.rotation);
    }

}
