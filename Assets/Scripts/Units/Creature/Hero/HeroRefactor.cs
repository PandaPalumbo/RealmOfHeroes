using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRefactor : MonoBehaviour
{
    public Creature heroCreature;
    public BaseHeroClass heroClass;
    public EHeroClass heroClassName;

    // Start is called before the first frame update
    void Start()
    {
        getHeroClass();
        Debug.Log(heroClass.ClassDescription);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void getHeroClass()
    {
        if(heroClassName == EHeroClass.Monk)
        {
            heroClass = new BaseMonkClass(heroCreature, heroCreature.level);
        }
        else
        {
            heroClass = new BaseWizardClass(heroCreature, heroCreature.level);
        }
    }

    void Attack()
    {
       
    }

}
