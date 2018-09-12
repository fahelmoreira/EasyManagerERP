using System;

namespace EasyManager.Domain.Commands
{
    public class RemoveManufactureCommand : ManufactureCommand
    {
        public RemoveManufactureCommand(Guid id)
        {
            id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}