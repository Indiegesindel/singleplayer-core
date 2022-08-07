namespace Sandbox.ui;

using Sandbox.UI;
using Sandbox.UI.Construct;

public class TextGame : Panel
{
	public static TextGame Instance;
	
	public Label TextLabel;
	private string m_Text;

	public TextGame()
	{
		Instance = this;
		
		TextLabel = Add.Label( "", "text" );
	}

	public override void Tick()
	{
		var player = Local.Pawn as DeathmatchPlayer;
		if ( player == null ) return;

		TextLabel.Text = "(" + m_Text + ") LOL TEST";
	}

	public void SetText(string _text)
	{
		Log.Info("Text has Changed");
		m_Text = _text;
	}
}
