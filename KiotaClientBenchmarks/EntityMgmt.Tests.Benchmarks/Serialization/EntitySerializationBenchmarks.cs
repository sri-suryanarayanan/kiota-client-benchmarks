using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Aveva.Platform.EntityMgmt.Client.Api.Models;
using Aveva.Platform.EntityMgmt.Tests.Benchmarks.Helpers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Serialization.Json;

namespace Aveva.Platform.EntityMgmt.Tests.Benchmarks.Serialization;

/// <summary>
/// Benchmarks comparing entity serialization performance between Kiota and System.Text.Json.
/// </summary>
[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.Default)]
[RankColumn]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
public class EntitySerializationBenchmarks
{
    private Entity _simpleEntity = null!;
    private Entity _complexEntity = null!;
    private BulkEntities _bulkEntities10 = null!;
    private BulkEntities _bulkEntities100 = null!;
    private JsonSerializerOptions _systemTextJsonOptions = null!;

    [GlobalSetup]
    public void Setup()
    {
        ApiClientBuilder.RegisterDefaultSerializer<JsonSerializationWriterFactory>();
        _systemTextJsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = false,
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
        };

        _simpleEntity = new EntityBuilder()
            .WithId("simple-entity")
            .WithName("Simple Test Entity")
            .BuildEntityRequest();

        _complexEntity = new EntityBuilder()
            .FullyPopulated()
            .WithAllPropertyTypes()
            .BuildEntityRequest();

        _bulkEntities10 = new BulkEntities
        {
            Items = [.. Enumerable.Range(0, 10).Select(i =>
            new EntityBuilder().WithId($"bulk-entity-{i}").WithName($"Bulk Entity {i}").BuildEntityRequest())],
        };

        _bulkEntities100 = new BulkEntities
        {
            Items = [.. Enumerable.Range(0, 100).Select(i =>
            new EntityBuilder().WithId($"bulk-entity-{i}").WithName($"Bulk Entity {i}").BuildEntityRequest())],
        };
    }

    #region Simple Entity Benchmarks

    [Benchmark(Description = "Simple Entity - System.Text.Json")]
    [BenchmarkCategory("Simple")]
    public string SerializeSimpleEntity_SystemTextJson()
    {
        return JsonSerializer.Serialize(_simpleEntity, _systemTextJsonOptions);
    }

    [Benchmark(Description = "Simple Entity - Kiota")]
    [BenchmarkCategory("Simple")]
    public async Task<string> SerializeSimpleEntity_Kiota()
    {
        return await KiotaJsonSerializer.SerializeAsStringAsync(_simpleEntity);
    }

    #endregion

    #region Complex Entity Benchmarks

    [Benchmark(Description = "Complex Entity - System.Text.Json")]
    [BenchmarkCategory("Complex")]
    public string SerializeComplexEntity_SystemTextJson()
    {
        return JsonSerializer.Serialize(_complexEntity, _systemTextJsonOptions);
    }

    [Benchmark(Description = "Complex Entity - Kiota")]
    [BenchmarkCategory("Complex")]
    public async Task<string> SerializeComplexEntity_Kiota()
    {
        return await KiotaJsonSerializer.SerializeAsStringAsync(_complexEntity);
    }

    #endregion

    #region Bulk Entity Benchmarks

    [Benchmark(Description = "Bulk Entities (10) - System.Text.Json")]
    [BenchmarkCategory("Bulk-10")]
    public string SerializeBulkEntities10_SystemTextJson()
    {
        return JsonSerializer.Serialize(_bulkEntities10, _systemTextJsonOptions);
    }

    [Benchmark(Description = "Bulk Entities (10) - Kiota")]
    [BenchmarkCategory("Bulk-10")]
    public async Task<string> SerializeBulkEntities10_Kiota()
    {
        return await KiotaJsonSerializer.SerializeAsStringAsync(_bulkEntities10);
    }

    [Benchmark(Description = "Bulk Entities (100) - System.Text.Json")]
    [BenchmarkCategory("Bulk-100")]
    public string SerializeBulkEntities100_SystemTextJson()
    {
        return JsonSerializer.Serialize(_bulkEntities100, _systemTextJsonOptions);
    }

    [Benchmark(Description = "Bulk Entities (100) - Kiota")]
    [BenchmarkCategory("Bulk-100")]
    public async Task<string> SerializeBulkEntities100_Kiota()
    {
        return await KiotaJsonSerializer.SerializeAsStringAsync(_bulkEntities100);
    }

    #endregion
}
