using System;
using UnityEngine;

public class UnitSelectedVisual : MonoBehaviour
{
    [SerializeField] Unit unit;

    MeshRenderer unitSelectedVisualMeshRenderer;

    void Awake()
    {
        unitSelectedVisualMeshRenderer = GetComponent<MeshRenderer>();
    }

    void Start()
    {
        UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanged;
        UpdateVisual();
    }

    void OnDestroy()
    {
        UnitActionSystem.Instance.OnSelectedUnitChanged -= UnitActionSystem_OnSelectedUnitChanged;
    }

    void UnitActionSystem_OnSelectedUnitChanged(object sender, EventArgs e)
    {
        UpdateVisual();
    }

    void UpdateVisual()
    {
        if (UnitActionSystem.Instance.GetSelectedUnit() == unit)
        {
            unitSelectedVisualMeshRenderer.enabled = true;
        }
        else
        {
            unitSelectedVisualMeshRenderer.enabled = false;
        }
    }

}
