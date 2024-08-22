using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "gericht", menuName = "neues Gericht")]
public class Gericht : ScriptableObject
{
    public new string name;
    public Sprite artwork;

    public AnimationClip idleAnimationClip;
    public AnimationClip onDestroyAnimationClip;
    public AnimationClip destroeyedAnimationClip;

    public int lernenergie_basis_punkte;
    public int nummer;
}
