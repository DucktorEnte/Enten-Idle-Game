using Unity.VisualScripting;
using UnityEngine;

public class TargetScript : ClickableObject
{
    public EntenSceneLogicScript sceneLogicScript;
    public Gericht gericht;
    public Animator targetAnimator;
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
        //animator.Play(gericht.onDestroyAnimationClip.name);
        //var foodAnimator = gericht.food.GetComponent<Animator>();
        targetAnimator.Play(gericht.onDestroyAnimationClip.name);
        Destroy(gameObject,0.4f);
    }


    public void setGericht(Gericht newGericht)
    {
        gericht = newGericht;
        gericht.food.sprite = newGericht.food.sprite;
        //animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);

        //animatorOverrideController["CustomIdleAnimation"] = gericht.idleAnimationClip;
        //animatorOverrideController["CustomOnDestroyAnimation"] = gericht.onDestroyAnimationClip;
        //animatorOverrideController["CustomDestroyedAnimation"] = gericht.destroeyedAnimationClip;
        //animator.runtimeAnimatorController = animatorOverrideController;
    }

    public void SetAnimator(Animator animator)
    {
        targetAnimator = animator;
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
