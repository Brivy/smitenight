﻿namespace Smitenight.Persistence.Data.Contracts.Models
{
    public record CreatePatchDto
    {
        public string Version { get; init; } = null!;
        public DateTimeOffset ReleaseDate { get; init; }
    }
}
