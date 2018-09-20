using EasyManager.Domain.Core.Commands;

namespace EasyManager.Domain.Commands
{
    public abstract class DepartamentCommand<T> : Command<T>
    {
        public string Name { get; protected set; }
    }
}