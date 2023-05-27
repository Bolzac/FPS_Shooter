using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator animator;

    public void PlayTargetAnimation(string targetAnim, int layerIndex)
    {
        animator.CrossFade(targetAnim,0,layerIndex);
    }
}