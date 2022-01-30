using System;

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

    public void ApplyAbility(IAbility sourceAbility, ITarget targetObject)
        {
        Abilities ability = sourceAbility.Type;
        Targets target = targetObject.Type;

        triggerEffect(ability,target);
        }

    #endregion

    // --- Internal Procedures:

    private void loadScene(Scenes targetScene)
        {
        SceneManager.LoadScene((int)targetScene);

        CurrentScene = targetScene;
        }

    private void triggerEffect(Abilities ability, Targets target)
        {
        Action effectDelegate = null;

        switch (ability)
            {
            case(Abilities.Fire): effectDelegate = fireEffects(target); break;
            case(Abilities.Ice): effectDelegate = iceEffects(target); break;

            default: effectDelegate = elementFizzles; break;
            }

        effectDelegate.Invoke();
        }

    #region Elemental Functions 

    private Action fireEffects(Targets target)
        {
        Action effectDelegate;

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

    private Action iceEffects(Targets target)
        {
        Action effectDelegate;

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

    private void elementFizzles()
        {
        // wrong spell/object combination

        // TODO
        }

    private void fireAffectsBarrel()
        {
        // fires explodes barrel

        // TODO
        }

    private void iceAffectsWaterfall()
        {
        // ice freezes~shatters waterfall

        // TODO
        }

    private void iceAffectsVines()
        {
        // ice shatters vines

        // TODO
        }

    private void fireAffectsVines()
        {
        // fire burns vines

        // TODO
        }

    private void fireAffectsRopes()
        {
        // fire burns bridge ropes

        // TODO
        }

    private void iceAffectsLeak()
        {
        // ice freezes leak

        // TODO
        }

    private void fireOnVulnerableEnemy()
        {
        // fire spell on ice enemy

        // TODO
        }

    private void fireOnResistantEnemy()
        {
        // fire spell on fire enemy

        // TODO
        }

    private void iceOnVulnerableEnemy()
        {
        // ice spell on fire enemy

        // TODO
        }

    private void iceOnResistantEnemy()
        {
        // ice spell on ice enemy

        // TODO
        }

    #endregion

    }

}

