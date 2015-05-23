namespace Pong.Models.Game.Models
{
    /// <summary>
    /// Player class, used for the individual players.
    /// </summary>
    class Player
    {
        public int Lifes { get; set; }
        public string Name { get; set; }

        public Player(int lifes, string name = "Player One")
        {
            this.Lifes = lifes;
            this.Name = name;
        }
    }
}
