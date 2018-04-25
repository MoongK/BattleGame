using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHpBar : MonoBehaviour {

    Image Bg, Fg;
    float hp;
    bool Started;

	void Start () {
        Started = false;
        Bg = transform.Find("BG").GetComponent<Image>();
        Fg = transform.Find("FG").GetComponent<Image>();
    }

    void Update()
    {

        if (GameObject.Find("Boss") != null)
        {
            if (GameObject.Find("Boss").GetComponent<Animator>().GetBool("isStarted"))
                Started = true;

            if (Started)
            {
                hp = GameObject.Find("Boss").GetComponent<EnemyHp>().currentHp / GameObject.Find("Boss").GetComponent<EnemyHp>().maxHp;

                Fg.rectTransform.localScale = new Vector3(hp, 1f, 1f);
                float dist = Mathf.Abs(Fg.rectTransform.localScale.x - Bg.rectTransform.localScale.x);
                Bg.rectTransform.localScale = Vector3.Lerp(Bg.rectTransform.localScale, Fg.rectTransform.localScale, 0.5f * Time.deltaTime / dist);
            }
        }
    }
}
