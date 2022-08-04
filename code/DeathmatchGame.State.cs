


partial class DeathmatchGame : Game
{
	public static GameStates CurrentState => (Current as DeathmatchGame)?.GameState ?? GameStates.Live;

	public GameStates GameState { get; set; } = GameStates.Live;

	public enum GameStates
	{
		Live,
		Dead,
	}

}
