using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityIconHandler : MonoBehaviour
{
    Image icon;
    Image coolIcon;
    public bool active;
    public int abilityNumber;
	// Use this for initialization
	void Start ()
    {
        icon = GetComponent<Image>();
        coolIcon = icon.transform.GetChild(0).GetComponent<Image>();
        //Dim();
	}

    public void Dim(bool down, float cooldown)
    {
        if(down)
        {
            GameManager.gm.canUse[abilityNumber] = true;
            icon.color = new Color(1, 1, 1, .5f);
            StartCoroutine(CoolDown(cooldown));
            active = true;
        }
        else
        {
            icon.color = new Color(1, 1, 1, 1);
            active = false;
            GameManager.gm.canUse[abilityNumber] = false;
        }
    }

    IEnumerator CoolDown(float timer)
    {
        float size = 100;
        float totalTimer = timer;
        coolIcon.rectTransform.sizeDelta = new Vector2(size, size);
        while(timer > 0)
        {
            timer -= 1 * Time.deltaTime;
            size = Size(timer, totalTimer);
            coolIcon.rectTransform.sizeDelta = new Vector2(100, size);
            yield return null;
        }
        Dim(false, 0);
    }

    float Size(float currentTime, float totalTime)
    {
        float f;
        f = currentTime * 100 / totalTime;
        return f;
    }
}
