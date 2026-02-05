using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Aveva.Platform.EntityMgmt.Client.Api.Models;
using Aveva.Platform.EntityMgmt.Tests.Benchmarks.Helpers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Order;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Serialization.Json;

namespace Aveva.Platform.EntityMgmt.Tests.Benchmarks.Serialization;

/// <summary>
/// Benchmarks comparing entity serialization performance between different serialization strategies.
/// Tests System.Text.Json, standard Kiota, Kiota with RecyclableMemoryStream, and Kiota with ArrayPool.
/// </summary>
[MemoryDiagnoser]
[EventPipeProfiler(EventPipeProfile.GcVerbose)] // Detailed GC and allocation info
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
    private ISerializationWriterFactory _writerFactory = null!;


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

        _writerFactory = new JsonSerializationWriterFactory();
    }

    #region Simple Entity Benchmarks

    [Benchmark(Description = "Simple - System.Text.Json", Baseline = true)]
    [BenchmarkCategory("Simple")]
    public string SerializeSimpleEntity_SystemTextJson()
    {
        return JsonSerializer.Serialize(_simpleEntity, _systemTextJsonOptions);
    }

    [Benchmark(Description = "Simple - Kiota (Standard)")]
    [BenchmarkCategory("Simple")]
    public async Task<string> SerializeSimpleEntity_Kiota()
    {
        // Make synchronous to avoid async overhead variations
        return await KiotaJsonSerializer.SerializeAsStringAsync(_simpleEntity).ConfigureAwait(false);
    }


    [Benchmark(Description = "Simple - Kiota (writer only)")]
    [BenchmarkCategory("Simple")]
    public string SerializeSimpleEntity_WithKiotaJsonWriter()
    {
        using var writer = new JsonSerializationWriter();
        writer.WriteObjectValue(null, _simpleEntity);
        using var stream = writer.GetSerializedContent();
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }

    [Benchmark(Description = "Simple - Kiota (with writer factory)")]
    [BenchmarkCategory("Simple")]
    public string SerializeSimpleEntity_WithKiotaJsonWriterFactory()
    {
        using var writer = _writerFactory.GetSerializationWriter("application/json");
        writer.WriteObjectValue(null, _simpleEntity);
        using var stream = writer.GetSerializedContent();
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }

    #endregion

    #region Complex Entity Benchmarks

    [Benchmark(Description = "Complex - System.Text.Json", Baseline = true)]
    [BenchmarkCategory("Complex")]
    public string SerializeComplexEntity_SystemTextJson()
    {
        return JsonSerializer.Serialize(_complexEntity, _systemTextJsonOptions);
    }

    [Benchmark(Description = "Complex - Kiota (Standard)")]
    [BenchmarkCategory("Complex")]
    public async Task<string> SerializeComplexEntity_Kiota()
    {
        return await KiotaJsonSerializer.SerializeAsStringAsync(_complexEntity);
    }

    [Benchmark(Description = "Complex - Kiota (writer only)")]
    [BenchmarkCategory("Complex")]
    public string SerializeComplexEntity_KiotaJsonWriter()
    {
        using var writer = new JsonSerializationWriter();
        writer.WriteObjectValue(null, _complexEntity);
        using var stream = writer.GetSerializedContent();
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }

    [Benchmark(Description = "Complex - Kiota (with writer factory)")]
    [BenchmarkCategory("Complex")]
    public string SerializeComplexEntity_KiotaJsonWriterFactory()
    {
        using var writer = _writerFactory.GetSerializationWriter("application/json");
        writer.WriteObjectValue(null, _complexEntity);
        using var stream = writer.GetSerializedContent();
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }

    #endregion

    #region Bulk Entity 10 Benchmarks

    [Benchmark(Description = "Bulk(10) - System.Text.Json", Baseline = true)]
    [BenchmarkCategory("Bulk-10")]
    public string SerializeBulkEntities10_SystemTextJson()
    {
        return JsonSerializer.Serialize(_bulkEntities10, _systemTextJsonOptions);
    }

    [Benchmark(Description = "Bulk(10) - Kiota (Standard)")]
    [BenchmarkCategory("Bulk-10")]
    public async Task<string> SerializeBulkEntities10_Kiota()
    {
        return await KiotaJsonSerializer.SerializeAsStringAsync(_bulkEntities10).ConfigureAwait(false);
    }

    [Benchmark(Description = "Bulk(10) - Kiota (writer only)")]
    [BenchmarkCategory("Bulk-10")]
    public string SerializeBulkEntities10_KiotaJsonWriter()
    {
        using var writer = new JsonSerializationWriter();
        writer.WriteObjectValue(null, _bulkEntities10);
        using var stream = writer.GetSerializedContent();
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }

    [Benchmark(Description = "Bulk(10) - Kiota (with writer factory)")]
    [BenchmarkCategory("Bulk-10")]
    public string SerializeBulkEntities10_KiotaJsonWriterFactory()
    {
        using var writer = _writerFactory.GetSerializationWriter("application/json");
        writer.WriteObjectValue(null, _bulkEntities10);
        using var stream = writer.GetSerializedContent();
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }

    #endregion

    #region Bulk Entity 100 Benchmarks

    [Benchmark(Description = "Bulk(100) - System.Text.Json", Baseline = true)]
    [BenchmarkCategory("Bulk-100")]
    public string SerializeBulkEntities100_SystemTextJson()
    {
        return JsonSerializer.Serialize(_bulkEntities100, _systemTextJsonOptions);
    }

    [Benchmark(Description = "Bulk(100) - Kiota (Standard)")]
    [BenchmarkCategory("Bulk-100")]
    public async Task<string> SerializeBulkEntities100_Kiota()
    {
        return await KiotaJsonSerializer.SerializeAsStringAsync(_bulkEntities100).ConfigureAwait(false);
    }

    [Benchmark(Description = "Bulk(100) - Kiota (writer only)")]
    [BenchmarkCategory("Bulk-100")]
    public string SerializeBulkEntities100_KiotaJsonWriter()
    {
        using var writer = new JsonSerializationWriter();
        writer.WriteObjectValue(null, _bulkEntities100);
        using var stream = writer.GetSerializedContent();
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }

    [Benchmark(Description = "Bulk(100) - Kiota (with writer factory)")]
    [BenchmarkCategory("Bulk-100")]
    public string SerializeBulkEntities100_KiotaJsonWriterFactory()
    {
        using var writer = _writerFactory.GetSerializationWriter("application/json");
        writer.WriteObjectValue(null, _bulkEntities100);
        using var stream = writer.GetSerializedContent();
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }

    #endregion
}
