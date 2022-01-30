using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{

public sealed class CommandController : MonoBehaviour
    {
    // --- Properties:

    public Scenes CurrentScene { get; private set; }

    // --- Initialization:

    public void Awake()
        {
        CurrentScene = Scenes.Initial;
        }

    // --- External Behaviours:

    #region Game State

    public void ChangeScene(Scenes targetScene)
        {

        loadScene(targetScene);
        }

    public void CloseApplication()
        {

        Application.Quit();
        }

    #endregion

    #region Gameplay

    public bool ApplyAbility(IAbility sourceAbility, ITarget targetObject)
        {
        Abilities ability = sourceAbility.Type;
        Targets target = targetObject.Type;

        bool success = triggerEffect(ability,target);

        return(success);
        }

    #endregion

    // --- Internal Procedures:

    private void loadScene(Scenes targetScene)
        {
        SceneManager.LoadScene((int)targetScene);

        CurrentScene = targetScene;
        }

    private bool triggerEffect(Abilities ability, Targets target)
        {
        Func<bool> effectDelegate;

        switch (ability)
            {
            case(Abilities.Fire): effectDelegate = fireEffects(target); break;
            case(Abilities.Ice): effectDelegate = iceEffects(target); break;

            default: effectDelegate = elementFizzles; break;
            }

        bool success = effectDelegate.Invoke();

        return(success);
        }

    #region Elemental Functions 

    private Func<bool> fireEffects(Targets target)
        {
        Func<bool> effectDelegate;

        switch(target)
            {
            case(Targets.Barrel): effectDelegate = fireAffectsBarrel; break;
            case(Targets.Vines): effectDelegate = fireAffectsVines; break;
            case(Targets.Rope): effectDelegate = fireAffectsRopes; break;

            case(Targets.FireEnemy): effectDelegate = fireOnResistantEnemy; break;
            case(Targets.IceEnemy): effectDelegate = fireOnVulnerableEnemy; break;

            default: effectDelegate = elementFizzles; break;
            }

        return(effectDelegate);
        }

    private Func<bool> iceEffects(Targets target)
        {
        Func<bool> effectDelegate;

        switch(target)
            {
            case(Targets.Vines): effectDelegate = iceAffectsVines; break;
            case(Targets.Leak): effectDelegate = iceAffectsLeak; break;
            case(Targets.Waterfall): effectDelegate = iceAffectsWaterfall; break;

            case(Targets.FireEnemy): effectDelegate = iceOnVulnerableEnemy; break;
            case(Targets.IceEnemy): effectDelegate = iceOnResistantEnemy; break;

            default: effectDelegate = elementFizzles; break;
            }

        return(effectDelegate);
        }

    #endregion

    #region Combination Effects

    private bool elementFizzles()
        {
        // wrong spell/object combination

        // TODO perform player feedback

        return false;
        }

    private bool fireAffectsBarrel()
        {
        // fires explodes barrel

        // TODO

        return true;
        }

    private bool iceAffectsWaterfall()
        {
        // ice freezes~shatters waterfall

        // TODO

        return true;
        }

    private bool iceAffectsVines()
        {
        // ice shatters vines

        // TODO

        return true;
        }

    private bool fireAffectsVines()
        {
        // fire burns vines

        // TODO

        return true;
        }

    private bool fireAffectsRopes()
        {
        // fire burns bridge ropes

        GameObject bridgeObject = GameObject.FindGameObjectWithTag("PuzzleOneTransformTarget");

        if (bridgeObject != null)
           {
           //MasterController.Commands.ChangeScene(Scenes.Menu); // TEST

           //Reactor_RopeObstacle puzzleStatus = bridgeObject.GetComponent<Reactor_RopeObstacle>();

           //if (puzzleStatus != null && !puzzleStatus.Solved) ~redudant test, skipped at obstacle itself
              {
              StartCoroutine(lowerBridge(bridgeObject));
              return(true);
              }
           }

        return(false);
        }

    private IEnumerator lowerBridge(GameObject transformTarget)
        {
        Vector3 originalAngles = transformTarget.transform.localEulerAngles;

        float elapsedTime = 0.0f;
        float effectTime = 2.2f;

        float timeFraction = 0;

        float startAngle = -60f;
        float endAngle = -26f;

        float totalShift = startAngle - endAngle;

        while (elapsedTime < effectTime)
            {
            yield return null;

            elapsedTime += Time.deltaTime;

            timeFraction = elapsedTime/effectTime;

            float instantX = totalShift * timeFraction;

            //transformTarget.transform.Rotate(Vector3.left,increment);
            transformTarget.transform.localEulerAngles = new Vector3(instantX,originalAngles.y,originalAngles.z);
            }

        yield break;
        }

    private bool iceAffectsLeak()
        {
        // ice freezes leak

        // TODO

        return true;
        }

    private bool fireOnVulnerableEnemy()
        {
        // fire spell on ice enemy

        // TODO

        return true;
        }

    private bool fireOnResistantEnemy()
        {
        // fire spell on fire enemy

        // TODO

        return true;
        }

    private bool iceOnVulnerableEnemy()
        {
        // ice spell on fire enemy

        // TODO

        return true;
        }

    private bool iceOnResistantEnemy()
        {
        // ice spell on ice enemy

        // TODO

        return true;
        }

    #endregion

    }

}

