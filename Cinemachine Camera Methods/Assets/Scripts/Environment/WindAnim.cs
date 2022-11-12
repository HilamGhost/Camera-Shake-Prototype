using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace HilamPrototype
{
    public class WindAnim : MonoBehaviour
    {
        [SerializeField, Tooltip("This variable determines of animation power")] float smallAmount;
        [SerializeField,Tooltip("This variable determines of animation lenght")] float smallTime;
        private void Start()
        {
            MakeSmallObject();
        }
        void MakeSmallObject() 
        {
            transform.DOScaleX(smallAmount, smallTime).OnComplete(MakeNormalObject);
        }
        void MakeNormalObject() 
        {
            transform.DOScaleX(1, smallTime).OnComplete(MakeSmallObject);
        }
    }
}
