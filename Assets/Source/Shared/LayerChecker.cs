using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Collider2D _colider;

    public bool IsToucningLayer { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        IsToucningLayer = _colider.IsTouchingLayers(_layerMask);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsToucningLayer = _colider.IsTouchingLayers(_layerMask);
    }

}
