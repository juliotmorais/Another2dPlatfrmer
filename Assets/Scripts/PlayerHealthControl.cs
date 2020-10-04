using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerHealthControl : MonoBehaviour
{
    public static PlayerHealthControl instance;
    public int currentHealth;
    [SerializeField] int maxHealth;
    public float invincibleLength;
    private float invincibleCounter;
    private SpriteRenderer mySpriteRenderer;

    private void Awake()
    {
        instance = this;

    }


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;
            if (invincibleCounter <= 0)
            {
                mySpriteRenderer.color = new Color(mySpriteRenderer.color.r, mySpriteRenderer.color.g, mySpriteRenderer.color.b, 1f);
            }
        }
    }

    public void DealDamage()
    {
        if(invincibleCounter <= 0)
        {
            currentHealth--;
            if (currentHealth <= 0)
            {
                gameObject.SetActive(false);
            }
            else
            {
                invincibleCounter = invincibleLength;

                //cause player to fade out when damaged
                mySpriteRenderer.color = new Color(mySpriteRenderer.color.r, mySpriteRenderer.color.g, mySpriteRenderer.color.b, .5f);

                Player.instance.KnockBack();
            }

            UIcontroller.instance.UpdateHealthDisplay();
        }

        
    }

}
