namespace Roulette.Core.Interfaces
{
    public interface IUserInputManager
    {
        string Name { get; }
        string Strategy { get; }
        int Cycles { get; }
        int? MinimumBid { get; }
        int? MaximumBid { get; }
        int Budget { get; }
        int StartBet { get; }

        void InterpretArguments(string[] args);
        bool RestartStrategy();
    }
}