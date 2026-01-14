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
/// Benchmarks comparing entity deserialization performance between Kiota and System.Text.Json.
/// </summary>
[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.Default)]
[RankColumn]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
public class EntityDeserializationBenchmarks
{
    private string _simpleEntityJson = null!;
    private string _complexEntityJson = null!;
    private string _bulkEntities10Json = null!;
    private string _bulkEntities100Json = null!;
    private JsonSerializerOptions _systemTextJsonOptions = null!;

    [GlobalSetup]
    public void Setup()
    {
        // Setup Kiota deserializers (register globally)
        ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();

        _systemTextJsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
        };

        // Prepare JSON strings for deserialization
        var simpleEntity = new EntityBuilder()
            .WithId("simple-entity")
            .WithName("Simple Test Entity")
            .BuildEntityRequest();
        _simpleEntityJson = JsonSerializer.Serialize(simpleEntity, _systemTextJsonOptions);

        var complexEntity = new EntityBuilder()
            .FullyPopulated()
            .WithAllPropertyTypes()
            .BuildEntityRequest();
        _complexEntityJson = JsonSerializer.Serialize(complexEntity, _systemTextJsonOptions);

        var bulkEntities10 = new BulkEntities
        {
            Items = [.. Enumerable.Range(0, 10)
                .Select(i => new EntityBuilder()
                    .WithId($"bulk-entity-{i}")
                    .WithName($"Bulk Entity {i}")
                    .BuildEntityRequest())],
        };
        _bulkEntities10Json = JsonSerializer.Serialize(bulkEntities10, _systemTextJsonOptions);

        var bulkEntities100 = new BulkEntities
        {
            Items = [.. Enumerable.Range(0, 100)
                .Select(i => new EntityBuilder()
                    .WithId($"bulk-entity-{i}")
                    .WithName($"Bulk Entity {i}")
                    .BuildEntityRequest())],
        };
        _bulkEntities100Json = JsonSerializer.Serialize(bulkEntities100, _systemTextJsonOptions);
    }

    #region Simple Entity Benchmarks

    [Benchmark(Description = "Simple Entity - System.Text.Json", Baseline = true)]
    [BenchmarkCategory("Simple")]
    public Entity DeserializeSimpleEntity_SystemTextJson()
    {
        return JsonSerializer.Deserialize<Entity>(_simpleEntityJson, _systemTextJsonOptions)!;
    }

    [Benchmark(Description = "Simple Entity - Kiota")]
    [BenchmarkCategory("Simple")]
    public async Task<Entity> DeserializeSimpleEntity_Kiota()
    {
        return (await KiotaJsonSerializer.DeserializeAsync(_simpleEntityJson, Entity.CreateFromDiscriminatorValue))!;
    }

    #endregion

    #region Complex Entity Benchmarks

    [Benchmark(Description = "Complex Entity - System.Text.Json", Baseline = true)]
    [BenchmarkCategory("Complex")]
    public Entity DeserializeComplexEntity_SystemTextJson()
    {
        return JsonSerializer.Deserialize<Entity>(_complexEntityJson, _systemTextJsonOptions)!;
    }

    [Benchmark(Description = "Complex Entity - Kiota")]
    [BenchmarkCategory("Complex")]
    public async Task<Entity> DeserializeComplexEntity_Kiota()
    {
        return (await KiotaJsonSerializer.DeserializeAsync(_complexEntityJson, Entity.CreateFromDiscriminatorValue))!;
    }

    #endregion

    #region Bulk Entity Benchmarks

    [Benchmark(Description = "Bulk Entities (10) - System.Text.Json", Baseline = true)]
    [BenchmarkCategory("Bulk-10")]
    public BulkEntities DeserializeBulkEntities10_SystemTextJson()
    {
        return JsonSerializer.Deserialize<BulkEntities>(_bulkEntities10Json, _systemTextJsonOptions)!;
    }

    [Benchmark(Description = "Bulk Entities (10) - Kiota")]
    [BenchmarkCategory("Bulk-10")]
    public async Task<BulkEntities> DeserializeBulkEntities10_Kiota()
    {
        return (await KiotaJsonSerializer.DeserializeAsync(_bulkEntities10Json, BulkEntities.CreateFromDiscriminatorValue))!;
    }

    [Benchmark(Description = "Bulk Entities (100) - System.Text.Json", Baseline = true)]
    [BenchmarkCategory("Bulk-100")]
    public BulkEntities DeserializeBulkEntities100_SystemTextJson()
    {
        return JsonSerializer.Deserialize<BulkEntities>(_bulkEntities100Json, _systemTextJsonOptions)!;
    }

    [Benchmark(Description = "Bulk Entities (100) - Kiota")]
    [BenchmarkCategory("Bulk-100")]
    public async Task<BulkEntities> DeserializeBulkEntities100_Kiota()
    {
        return (await KiotaJsonSerializer.DeserializeAsync(_bulkEntities100Json, BulkEntities.CreateFromDiscriminatorValue))!;
    }

    #endregion

    #region Response Type Benchmarks

    [Benchmark(Description = "EntityResponse - System.Text.Json", Baseline = true)]
    [BenchmarkCategory("Response")]
    public EntityResponse DeserializeEntityResponse_SystemTextJson()
    {
        return JsonSerializer.Deserialize<EntityResponse>(_complexEntityJson, _systemTextJsonOptions)!;
    }

    [Benchmark(Description = "EntityResponse - Kiota")]
    [BenchmarkCategory("Response")]
    public async Task<EntityResponse> DeserializeEntityResponse_Kiota()
    {
        return (await KiotaJsonSerializer.DeserializeAsync(_complexEntityJson, EntityResponse.CreateFromDiscriminatorValue))!;
    }

    #endregion
}
