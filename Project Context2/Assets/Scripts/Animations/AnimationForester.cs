using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationForester : MonoBehaviour
{
   public Animator charAnimator;
   public void IdleAnimation()
   {
      charAnimator.SetBool("IsTalking",false);
   }
   public void TalkingAnimation()
   {
      charAnimator.SetBool("IsTalking",true);
   }
}
