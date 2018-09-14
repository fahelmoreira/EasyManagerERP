using System.Threading.Tasks;
using MediatR;

namespace EasyManager.Domain.Core.Units
{
    public abstract class UnitClass
    {
        public static readonly UnitClass Value;
        public static readonly Task<UnitClass> Task;
    }

    public class UnitClass<T> : UnitClass
    {
        public static readonly new T Value;
        public static readonly new  Task<T> Task;
    }
}