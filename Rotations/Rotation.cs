using System.Threading.Tasks;

namespace ShinraCo.Rotations
{
    public interface IRotation
    {
        Task<bool> Combat();
        Task<bool> CombatBuff();
        Task<bool> Heal();
        Task<bool> PreCombatBuff();
        Task<bool> Pull();
        Task<bool> CombatPVP();
    }

    public abstract class Rotation : IRotation
    {
        public abstract Task<bool> Combat();
        public abstract Task<bool> CombatBuff();
        public abstract Task<bool> Heal();
        public abstract Task<bool> PreCombatBuff();
        public abstract Task<bool> Pull();
        public abstract Task<bool> CombatPVP();
    }
}