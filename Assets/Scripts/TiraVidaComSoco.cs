using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiraVidaComSoco : MonoBehaviour
{
    public float RangeSoco;
    public Camera mainCamera;
    public int damageSoco = 10;
    public void TiraVidaSoco()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        if (Physics.Raycast(ray, out hit, RangeSoco))
        {
            var t = hit.transform.GetComponent<Vida>();
            if (t != null)
            { t.retiraVida(damageSoco); }    
        }
    }
}
