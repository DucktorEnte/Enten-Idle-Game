using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerentenschuleSpawnScript : MonoBehaviour
{
    public GameObject ente;
    public GameObject tigerente;
    public GameObject tigerenteMitEnte;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(tigerenteMitEnte, transform.position+new Vector3(0,10,0), Quaternion.Euler(0, 0, 270));
        
    }

    // Update is called once per frame
    private void spawnEnte() {
        Instantiate(ente, transform.position + new Vector3(0, -1, 0), transform.rotation);
    }

    private void spawnTigerente()
    {
        Instantiate(tigerente, transform.position + new Vector3(0, 2, 0),transform.rotation);
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

}
