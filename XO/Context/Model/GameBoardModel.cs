using System;

namespace XO.Context.Model
{
    class GameBoardModel
    {
        public Guid GbId { get; set; }
        public int[,] GameBoard { get; set; }
        public Guid GbPlayer1 { get; set; }
        public Guid GbPlayer2 { get; set; }
        public GameStatus GbStatus { get; set; }
        public Guid GbWinner { get; set; }
        public GameType GbType { get; set; }

    }
    public enum GameStatus
    {
        Tie,Win
    }
    public enum GameType
    {
        CpuVsCpu , HumanVsHuman , HumanVsCpu
    }
}
