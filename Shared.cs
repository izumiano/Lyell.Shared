// ReSharper disable once RedundantUsingDirective <required for dotnet8>

using System.Collections.Generic;
using System.Text.Json.Serialization;

// ReSharper disable once CheckNamespace
namespace Lyell.Shared;

public enum GameState
{
	Closed,
	Opening,
	AlreadyOpening,
	Open,
	Closing,
	Restarting,
}

public record LoadingMod
{
	public required string Name { get; set; }
};

public enum ModUpdateState
{
	Unset,
	Downloading,
	Downloaded,
	Failed
}

public record ModUpdate
{
	public required string Name { get; set; }
	public required string CurrentVersion { get; set; }
	public required string NewVersion { get; set; }
	public required int LatestUpdateTime { get; set; }

	[JsonConverter(typeof(JsonStringEnumConverter))]
	public ModUpdateState UpdateState { get; set; } = ModUpdateState.Unset;
}

public record ModLoadingState
{
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public LoadingMod? Mod { get; set; }

	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public int? CurrentCount { get; set; }

	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public int? TotalCount { get; set; }

	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? Finalizing { get; set; }
}

public record ModUpdates
{
	public bool Initial { get; set; } = false;
	public required List<ModUpdate> Updates { get; set; }
}

public enum AcceptedAction
{
	UpdatingMods,
	Closing,
	Restarting
}

public record CelesteState
{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public GameState? GameState { get; set; }

	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public ModLoadingState? LoadingState { get; set; }

	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public ModUpdates? ModUpdates { get; set; }

	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? EverestUpdateAvailable { get; set; }

	[JsonConverter(typeof(JsonStringEnumConverter))]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public AcceptedAction? AcceptedAction { get; set; }

	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? PlayedMap { get; set; }
}