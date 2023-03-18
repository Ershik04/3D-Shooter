using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMMO : MonoBehaviour
{
    [SerializeField]
    private int _ammoCount;
    [SerializeField]
    private int _ammoIncrace;

    public int GetCurentAMMO()
    {
        return _ammoCount;
    }

    public void ReduceCurrentAMMO()
    {
        _ammoCount--;
    }

    public void IncraceCurrentAMMO()
    {
        _ammoCount += _ammoIncrace;
    }
}
