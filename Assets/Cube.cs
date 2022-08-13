using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public Vector3 ChildPos => childTr.position;
    public Quaternion ChildRot => childTr.rotation;
    public Vector3 ChildScale => childTr.localScale;

    Transform childTr;
    void Awake()
    {
        Animator childAnimator = GetComponentInChildren<Animator>();
        childTr = childAnimator.transform;
    }
}
