using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class EntenLaufScript : MonoBehaviour
{
    public Vector3 target;
    public float moveSpeed = 5;
    private Vector3 scaleSave;
    public Animator animator;
    private bool isMoving;
    public float xOffset=6;
    public ClickableObject targetObject;
    public bool hasTarget;


    public TigerentenschulSceneLogicScript tigerentenschuleLogicScript;
    public EntenSceneLogicScript entenSceneLogicScript;
    public KuecheLogicScript kuecheLogicScript;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = (float)gameManager.entengeschwindigkeit;
        target = transform.position;
        hasTarget = false;
        if (SceneManager.GetActiveScene().name == "Tigerentenschule")
        {
            findTigerentenschuleLogicScript();

        }
        else if (SceneManager.GetActiveScene().name == "Essensraum")
        {
            findEssensraumSceneLogicScript();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = (float)gameManager.entengeschwindigkeit;
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        if (isMoving && transform.position == target)
        {
            isMoving = false;
            animator.SetBool("isMoving", isMoving);

            if (hasTarget)
            {
                if (targetObject != null && targetObject.GetType() == typeof(TargetScript))
                {
                    animator.Play("piksen_animation");
                    entenSceneLogicScript.enteArrived();
                }
                else if (targetObject != null && targetObject.GetType() == typeof(TigerEntenScript))
                {
                    if (tigerentenschuleLogicScript != null)
                    {
                        tigerentenschuleLogicScript.enteArrived();
                    }

                    else if (entenSceneLogicScript != null)
                    {
                        entenSceneLogicScript.enteArrived();
                    }


                }
                else if (targetObject != null && targetObject.GetType() == typeof(KuechentuerScript)) {
                    Logger.DevTest("test");
                    if (entenSceneLogicScript != null)
                    {
                        
                        SceneManager.LoadScene("Kueche");
                        gameManager.lastSceneName = "Kueche";
                    }
                    else if (kuecheLogicScript != null)
                    {

                        SceneManager.LoadScene("Essensraum");
                        gameManager.lastSceneName = "Essensraum";
                    }

                }
            }
            
            

        }
    }

    //private void findTigerentenschuleSpawnScript() {
    //    tigerentenSpawnscript= GameObject.FindGameObjectWithTag("AllSpawner").GetComponent<TigerentenschuleSpawnScript>();
    //}
    //private void findEntenSceneSpawnScript() {
    //    entenSceneSpawner = GameObject.FindGameObjectWithTag("AllSpawner").GetComponent<EntenSceneSpawner>();
    //}

    public void setNewTarget(Vector3 targetVector) {
        if (targetVector.y > -4)
        {
            target = targetVector;
            target.z = transform.position.z;
            if (target.x < transform.position.x)
            {
                target.x = Math.Min(target.x + xOffset * transform.localScale.y, transform.position.x);
                scaleSave = transform.localScale;
                scaleSave.x = -Math.Abs(transform.localScale.x);
                transform.localScale = scaleSave;
            }
            else if (target.x > transform.position.x)
            {
                target.x = Math.Max(target.x - xOffset * transform.localScale.y, transform.position.x);
                scaleSave = transform.localScale;
                scaleSave.x = Math.Abs(transform.localScale.x);
                transform.localScale = scaleSave;
            }
            isMoving = true;
            animator.SetBool("isMoving", isMoving);
        }
    }

    private void findTigerentenschuleLogicScript()
    {
        tigerentenschuleLogicScript = GameObject.FindGameObjectWithTag("SceneLogicTag").GetComponent<TigerentenschulSceneLogicScript>();
        tigerentenschuleLogicScript.ente = this;
    }

    private void findEssensraumSceneLogicScript()
    {
        entenSceneLogicScript = GameObject.FindGameObjectWithTag("SceneLogicTag").GetComponent<EntenSceneLogicScript>();
    }

    public void deleteEnte() {
        Destroy(gameObject);
    }

}
