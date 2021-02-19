using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSlider : MonoBehaviour
{
    [SerializeField] Slider slider;

    [SerializeField] Transform deathTransform;
    [SerializeField] GameObject deathVFX;

    private void Update()
    {
        if (slider.value < 100)
            slider.value += Time.deltaTime * 10;
        else
        {
            slider.value = 0f;
            StartCoroutine(SendWater());
        }           
    }

    IEnumerator SendWater()
    {
        GameObject go = Instantiate(deathVFX, deathTransform.position, Quaternion.identity);

        yield return new WaitForSeconds(2f);
        Destroy(go);
    }
}
