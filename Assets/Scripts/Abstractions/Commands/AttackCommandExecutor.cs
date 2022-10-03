using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
public class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
{
    public override void ExecuteSpecificCommand(IAttackCommand command)
    {
        Debug.Log("Attack");
    }
}