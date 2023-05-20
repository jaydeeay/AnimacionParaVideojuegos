using UnityEngine;
using UnityEngine.Animations.Rigging;
<<<<<<< Updated upstream

public class IKSnappers : MonoBehaviour
{
    [SerializeField][Range(0,1)] private float proceduralInfluence;
    [SerializeField] private MultiParentConstraint[] animatedBones;
    [SerializeField] private MultiParentConstraint[] proceduralBones;

    private void UpdateInfluence(float weight)
    {
        if (animatedBones == null) return;
        
=======
using System.Collections;

public class IKSnappers : MonoBehaviour
{
    [SerializeField][Range(0, 1)] private float proceduralInfluence;
    [SerializeField] private MultiParentConstraint[] animatedBones;
    [SerializeField] private MultiParentConstraint[] proceduralBones;
    [SerializeField] private AnimationCurve activationAnimation;
    [SerializeField] private AnimationCurve deactivationAnimation;

    private bool currentOverride;
    private void UpdateInfluence(float weight)
    {
        if (animatedBones == null) return;

>>>>>>> Stashed changes
        foreach (MultiParentConstraint multiParentConstraint in animatedBones)
        {
            if (multiParentConstraint == null) continue;
            multiParentConstraint.weight = weight;
        }

        if (proceduralBones == null) return;
<<<<<<< Updated upstream
        
=======

>>>>>>> Stashed changes
        foreach (MultiParentConstraint proceduralConstraint in proceduralBones)
        {
            if (proceduralConstraint == null) continue;
            proceduralConstraint.weight = 1 - weight;
        }
    }
<<<<<<< Updated upstream
    
=======

>>>>>>> Stashed changes
    private void OnValidate()
    {
        UpdateInfluence(proceduralInfluence);
    }
<<<<<<< Updated upstream
=======

    public void OverrideIK(bool state)
    {
        if (state != currentOverride)
        {
            currentOverride = state;
            StartCoroutine(AnimateInfluence());
        }
    }
    IEnumerator AnimateInfluence()
    {
        //actualizacion las influencias

        AnimationCurve curve = currentOverride ? activationAnimation : deactivationAnimation;
        for (float time = 0; time < 1f; time += Time.deltaTime)
        {
            proceduralInfluence = curve.Evaluate(time);
            UpdateInfluence(proceduralInfluence);

            yield return null;
        }
    }
>>>>>>> Stashed changes
}
