
using Sandbox.UI;
using Sandbox.UI.Construct;

internal class GameHud : Panel
{
	public Label Timer;
	public Label State;

	public GameHud()
	{
		State = Add.Label( string.Empty, "game-state" );
	}

	public override void Tick()
	{
		base.Tick();

		var game = Game.Current as DeathmatchGame;
		if ( !game.IsValid() ) return;
	}

}

