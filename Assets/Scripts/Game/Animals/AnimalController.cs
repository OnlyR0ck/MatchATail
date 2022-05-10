using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Spine;
using Spine.Unity;
using UnityEngine;

public class AnimalController : MonoBehaviour
{

    public void Method()
    {
        SkeletonAnimation animation = gameObject.AddComponent<SkeletonAnimation>();
    }
}
