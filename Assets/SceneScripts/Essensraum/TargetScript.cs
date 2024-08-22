using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class TargetScript : ClickableObject
{
    public EntenSceneLogicScript sceneLogicScript;
    public Animator animator;
    public Gericht gericht;
    public AnimatorOverrideController animatorOverrideController;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        sceneLogicScript = GameObject.FindGameObjectWithTag("SceneLogicTag").GetComponent<EntenSceneLogicScript>();
    }


    public override void delete_Target(){
        if (isDestroyed) return;

        sceneLogicScript.addScore(gericht.lernenergie_basis_punkte);
        sceneLogicScript.removeClickableObject(this);
        isDestroyed = true;
        animator.Play("CustomOnDestroyAnimation");
        Destroy(gameObject,0.5f);
    }


    public void setGericht(Gericht newGericht)
    {
        gericht = newGericht;
        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);

        animatorOverrideController["CustomIdleAnimation"] = gericht.idleAnimationClip;
        animatorOverrideController["CustomOnDestroyAnimation"] = gericht.onDestroyAnimationClip;
        animatorOverrideController["CustomDestroyedAnimation"] = gericht.destroeyedAnimationClip;
        animator.runtimeAnimatorController = animatorOverrideController;
    }

    public override bool checkIfPointInCollider(Vector3 vector)
    {
        return gameObject.GetComponent<BoxCollider2D>().bounds.Contains(vector);
    }

    //public override void gotClicked()
    //{
    //    sceneLogicScript.setEntentarget(this);
    //}

}
