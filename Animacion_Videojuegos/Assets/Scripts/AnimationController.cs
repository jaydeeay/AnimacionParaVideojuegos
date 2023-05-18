using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{

    public void setMotionValue(float value)
    {
        GetComponent<Animator>().SetFloat("Speed",value);
    }
    public void setAttactkTrigger()
    {
        GetComponent<Animator>().SetTrigger("Attack");
    }
    public void SetDamageTrigger()
    {
        GetComponent<Animator>().SetTrigger("Damage");
    }
}
