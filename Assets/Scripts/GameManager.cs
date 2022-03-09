using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ActiveEffects
{
    public string kcorp_rekkless;
    public string kcorp_alderiate;
    public string kcorp_kotei;
    public string kcorp_kamet0;
    public string kcorp_sardoche;
    public string amongus_antoinedaniel;
    public string amongus_baghera;
    public string amongus_gomart;
    public string amongus_jdg;
    public string amongus_ponce;
    public string zevent_zerator;
    public string zevent_boblennon;
    public string zevent_maghla;
    public string zevent_moman;
    public string zevent_ultia;
}
public struct PassiveEffects
{
    public string kcorp;
    public string amongus;
    public string zevent;
}
public struct AllyPosition
{
    public bool pos1;
    public bool pos2;
    public bool pos3;
    public bool pos4;
    public bool pos5;
    public bool pos6;
}
public struct EnemyPosition
{
    public bool enemyPos1;
    public bool enemyPos2;
    public bool enemyPos3;
    public bool enemyPos4;
    public bool enemyPos5;
    public bool enemyPos6;
}

public class GameManager : MonoBehaviour
{
    #region Variable

    public GameObject[] allyStarz;
    public GameObject[] enemyStarz;

    public ActiveEffects activeEffects = new ActiveEffects();
    public PassiveEffects passiveEffects = new PassiveEffects();
    public AllyPosition allyPos = new AllyPosition();
    public EnemyPosition enemyPos = new EnemyPosition();

    #endregion



    public void AddStarzToPosition(int pos)
    {
        switch (pos)
        {
            case 1:
                allyPos.pos1 = true;
                break;
            case 2:
                allyPos.pos2 = true;
                break;
            case 3:
                allyPos.pos3 = true;
                break;
            case 4:
                allyPos.pos4 = true;
                break;
            case 5:
                allyPos.pos5 = true;
                break;
            case 6:
                allyPos.pos6 = true;
                break;
        }
    }
}
