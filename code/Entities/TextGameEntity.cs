using Sandbox.ui;
using SandboxEditor;

namespace Sandbox.Entities;

[Library( "text_game" ), HammerEntity]
[EditorSprite( "materials/editor/text_game_icon.vmat" )]
[Title( "Text Game" ), Category( "Text" )]
public class TextGameEntity : Entity
{
	private bool m_Active;
	private bool m_OneShot;

	[Property( Title = "Text" )] public string Text { get; set; } = "";

	[Property( Title = "OneShot Length" )] public float OneShotLength { get; set; } = 3f;

	private float m_OneShotLength;

	public Output OnOneShotStarted;
	public Output OnOneShotEnded;
	public Output OnShow;
	public Output OnHide;

	public TextGameEntity()
	{
	}

	[Event.Tick]
	void Tick()
	{
		DebugOverlay.ScreenText($"IsActive: {m_Active}\nText: {Text}\n\nOneShot?: {m_OneShot}\nOneShotLength: {OneShotLength}\nOneShotStatus: {m_OneShotLength}" );

		// One Shot Timer
		if ( m_OneShotLength > 0f && m_Active && m_OneShot )
		{
			m_OneShotLength -= Time.Delta;
		}
		else if ( m_OneShotLength < 0f && m_Active )
		{
			this.HideInput();
		}
	}

	[Input( Name = "OneShot" )]
	public void OneShotInput()
	{
		m_OneShot = true;
		m_OneShotLength = OneShotLength;
		m_Active = true;

		this.ShowInput();

		TextGame.Instance.SetText( "Test OneShot" );
	}

	[Input( Name = "Show" )]
	public void ShowInput()
	{
		m_OneShot = false;
		m_Active = true;
		Log.Info( "Show" );
		TextGame.Instance.SetText( "Test Show" );
	}

	[Input( Name = "Hide" )]
	public void HideInput()
	{
		m_OneShotLength = OneShotLength;
		m_Active = false;

		Log.Info( "Hide" );
		TextGame.Instance.SetText( "Test Hide" );
	}
}
