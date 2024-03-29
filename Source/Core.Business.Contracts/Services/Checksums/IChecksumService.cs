﻿namespace Smitenight.Application.Core.Business.Contracts.Services.Checksums;

public interface IChecksumService
{
    string CalculateChecksum<T>(T @object);
    bool IsChecksumDifferent<TCompare>(string checksum, TCompare comparisonObject);
}
