using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// 战斗状态
/// </summary>
public class BattleState : ISceneState
{
    public BattleState(SceneStateController Controller) : base(Controller)
    {
        this.StateName = "BattleState";
    }

    // 开始
    public override void StateBegin()
    {
        PBaseDefenseGame.Instance.Initinal();
    }

    // 結束
    public override void StateEnd()
    {
        PBaseDefenseGame.Instance.Release();
    }

    // 更新
    public override void StateUpdate()
    {
        // 游戏逻辑
        PBaseDefenseGame.Instance.Update();
        // Render由Unity负责

        // 游戏是否結束
        if (PBaseDefenseGame.Instance.ThisGameIsOver())
            m_Controller.SetState(new MainMenuState(m_Controller), "MainMenuScene");
    }
}
