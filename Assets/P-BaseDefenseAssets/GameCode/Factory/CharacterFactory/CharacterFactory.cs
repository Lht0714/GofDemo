using UnityEngine;
using System.Collections;

// 生成游戏角色工厂
public class CharacterFactory : ICharacterFactory
{
    // 角色建立指导者
    private CharacterBuilderSystem m_BuilderDirector = new CharacterBuilderSystem(PBaseDefenseGame.Instance);
    // 建立Soldier
    public override ISoldier CreateSoldier(ENUM_Soldier emSoldier, ENUM_Weapon emWeapon, int Lv, Vector3 SpawnPosition)
    {
        // 生成Soldier的参数
        SoldierBuildParam SoldierParam = new SoldierBuildParam();

        // 生成对应的Character
        switch (emSoldier)
        {
            case ENUM_Soldier.Rookie:
                SoldierParam.NewCharacter = new SoldierRookie();
                break;
            case ENUM_Soldier.Sergeant:
                SoldierParam.NewCharacter = new SoldierSergeant();
                break;
            case ENUM_Soldier.Captain:
                SoldierParam.NewCharacter = new SoldierCaptain();
                break;
            default:
                Debug.LogWarning("CreateSoldier:无法建立[" + emSoldier + "]");
                return null;
        }

        if (SoldierParam.NewCharacter == null)
            return null;

        // 设置共用参数
        SoldierParam.emWeapon = emWeapon;
        SoldierParam.SpawnPosition = SpawnPosition;
        SoldierParam.Lv = Lv;


        ///通过建造者设置数据
        //  生成对应的Builder及设置参数
        SoldierBuilder theSoldierBuilder = new SoldierBuilder();
        theSoldierBuilder.SetBuildParam(SoldierParam);

        // 生成   然后调用指挥者来进行角色个组件设计

        m_BuilderDirector.Construct(theSoldierBuilder);
        return SoldierParam.NewCharacter as ISoldier;
    }

    // 建立Enemy
    public override IEnemy CreateEnemy(ENUM_Enemy emEnemy, ENUM_Weapon emWeapon, Vector3 SpawnPosition, Vector3 AttackPosition)
    {
        // 生成Enemy的參數
        EnemyBuildParam EnemyParam = new EnemyBuildParam();

        // 生成对应的Character
        switch (emEnemy)
        {
            case ENUM_Enemy.Elf:
                EnemyParam.NewCharacter = new EnemyElf();
                break;
            case ENUM_Enemy.Troll:
                EnemyParam.NewCharacter = new EnemyTroll();
                break;
            case ENUM_Enemy.Ogre:
                EnemyParam.NewCharacter = new EnemyOgre();
                break;
            default:
                Debug.LogWarning("无法建立[" + emEnemy + "]");
                return null;
        }

        if (EnemyParam.NewCharacter == null)
            return null;

        // 设置共用参数
        EnemyParam.emWeapon = emWeapon;
        EnemyParam.SpawnPosition = SpawnPosition;
        EnemyParam.AttackPosition = AttackPosition;

        //  生成对应的Builder及设置参数
        EnemyBuilder theEnemyBuilder = new EnemyBuilder();
        theEnemyBuilder.SetBuildParam(EnemyParam);

        // 生成
        m_BuilderDirector.Construct(theEnemyBuilder);
        return EnemyParam.NewCharacter as IEnemy;
    }
}


