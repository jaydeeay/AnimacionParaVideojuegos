using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

[Serializable]
public struct MultiparentConstraintConfig
{
    public MultiParentConstraint constraint;
    public int[] directInfluenceSources;
    public int[] invertedInfluenceSources;
}

[RequireComponent(typeof(Animator))]
public class AnimationDrivenConstraintStreamer : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private string parameterName;
    [SerializeField] private MultiparentConstraintConfig[] constraints;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float value = anim.GetFloat(parameterName);
        foreach (MultiparentConstraintConfig multiParentConstraint in constraints)
        {
            WeightedTransformArray array = multiParentConstraint.constraint.data.sourceObjects;
            foreach (int i in multiParentConstraint.directInfluenceSources)
            {
                array.SetWeight(i,value);
            }

            foreach (int i in multiParentConstraint.invertedInfluenceSources)
            {
                array.SetWeight(i,1-value);
            }

            multiParentConstraint.constraint.data.sourceObjects = array;
        }
    }
}
