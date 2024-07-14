using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using XO.Context;

namespace XO.Service
{
    public interface IPlayService
    {
        void Play();
        void Select(int nummber);

    }
    public interface IMentalService
    {
        int ChousedNumbeer(Tuple<int, int> Cordinate);
        Tuple<int, int> Think();

    }
    public interface IBoardService
    {
        void UpdateBoard();
        void Print();
    }
    public enum PlayerSign
    {
        PalyerX , PlayerO
    }
    public class Board : IBoardService
    {
        private Guid BoardId;
        private int[,] GameBoard ;
        private XoContext GetXoContext;
        public Board(Guid Player)
        {
           var Selector = GetXoContext.GameBoards.First(x => x.GbPlayer1.Equals(Player) || x.GbPlayer2.Equals(Player));
            if (Selector != null)
            {
                BoardId = Selector.GbId;
                GameBoard = Selector.GameBoard;
            }
            CreateGame();
        }
        private void CreateGame()
        {
            BoardId = Guid.NewGuid();
            GameBoard = HelperExtention.GameBoardDefualt;

        }
 
        public void Print()
        {
            
        }

        public void UpdateBoard()
        {
            throw new NotImplementedException();
        }
    }
    internal static  class HelperExtention
    {
        public static int[,] GameBoardDefualt { get; set; } = new int[3, 3];

        public static string GetUserId()
        {

            //string hostName = Dns.GetHostName();
            //Console.WriteLine(hostName);

            //// Get the IP from GetHostByName method of dns class. 
            //string IP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            var filename = "PlayerID.pdXO";
            var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase) + @"/" + filename;
            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }
            File.WriteAllText(path, Guid.NewGuid().ToString());
            GetUserId();
            return null;
        }
    }
    public abstract class Player
    {
        public Player()
        {
            PlayerID = Guid.Parse(HelperExtention.GetUserId());
        }
        public PlayerType Type { get; set; }
        public Guid PlayerID { get; set; }

    }
    public enum PlayerType
    {
        Cpu,
        Human,
    }
}
