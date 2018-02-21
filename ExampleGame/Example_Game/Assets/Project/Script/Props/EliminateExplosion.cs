using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EliminateExplosion : MonoBehaviour {

    public void Call()
    {
        StartCoroutine(Deactive());
    }

	public IEnumerator Deactive()
    {
        yield return new WaitForSeconds(0.7f);
        gameObject.SetActive(false);
    }
}
