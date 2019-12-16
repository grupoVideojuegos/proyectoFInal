using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trayectoria : MonoBehaviour
{
    [SerializeField] Transform salida;
    [SerializeField] Transform llegada;

    private void OnDrawGizmosSelected()
    {
        if(salida != null && llegada != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(salida.position, llegada.position);
            Gizmos.DrawSphere(salida.position, 0.15f);
            Gizmos.DrawSphere(llegada.position, 0.15f);
        }
    }

}
