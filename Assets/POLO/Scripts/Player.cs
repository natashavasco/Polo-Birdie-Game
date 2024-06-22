using Fusion;

namespace POLO.Scripts
{
	public class Player
	{
		public PlayerRef PlayerRef;
		
		private string m_Name;

		public string Name => m_Name;

		public void SetPlayerName(string name)
		{
			m_Name = name;
		}
	}
}