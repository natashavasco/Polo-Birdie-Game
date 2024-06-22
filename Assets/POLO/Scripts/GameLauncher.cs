using System;
using System.Collections;
using System.Collections.Generic;
using Fusion;
using Fusion.Sockets;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ConnectionStatus
{
	Disconnected,
	Connecting,
	Failed,
	Connected
}

public class GameLauncher : Singleton<GameLauncher>, INetworkRunnerCallbacks
{
	[SerializeField] private GameStateMachine m_GameStateMachine;
	private NetworkRunner _runner;
	private GameMode _gameMode;
	
	
	public static ConnectionStatus ConnectionStatus = ConnectionStatus.Disconnected;

	public void SetCreateLobby() => _gameMode = GameMode.Host;
	public void SetJoinLobby() => _gameMode = GameMode.Client;
	public async void CreateSession(string sessionName)
	{
		if (_runner == null)
		{
			_runner = gameObject.AddComponent<NetworkRunner>();
		}

		await _runner.StartGame(new StartGameArgs
		{
			GameMode = _gameMode,
			SessionName = sessionName,
			PlayerCount = 5,
			//DisableClientSessionCreation = true,
			SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>()
		});
	}
	
	public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
	{
		//Debug.Log($"Player joined //{player}// with session name //{runner.SessionInfo.Name}//");
		
		// Create a unique position for the player
		//Vector3 spawnPosition = new Vector3((player.RawEncoded%runner.Config.Simulation.DefaultPlayers)*3,1,0);
		//NetworkObject networkPlayerObject = runner.Spawn(_playerPrefab, spawnPosition, Quaternion.identity, player);
		// Keep track of the player avatars so we can remove it when they disconnect
		//_spawnedCharacters.Add(player, networkPlayerObject);
		m_GameStateMachine.ChangeState(m_GameStateMachine.InitState);
	}

	public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
	{
	}

	public void OnInput(NetworkRunner runner, NetworkInput input)
	{
	}

	public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
	{
	}

	public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
	{
	}

	public void OnConnectedToServer(NetworkRunner runner)
	{
	}

	public void OnDisconnectedFromServer(NetworkRunner runner)
	{
	}

	public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
	{
	}

	public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
	{
	}

	public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
	{
	}

	public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
	{
		foreach (SessionInfo session in sessionList)
		{
			Debug.Log($"New session create  {session.Name}");
		}
	}

	public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
	{
	}

	public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
	{
	}

	public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
	{
	}

	public void OnSceneLoadDone(NetworkRunner runner)
	{
	}

	public void OnSceneLoadStart(NetworkRunner runner)
	{
	}
}
