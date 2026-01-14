using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;

namespace Aveva.Platform.EntityMgmt.Tests.Benchmarks.Serialization.CustomSerializers;

/// <summary>
/// Custom JsonSerializationWriter using ArrayPool for byte array reuse.
/// Based on Microsoft.Kiota.Serialization.Json.JsonSerializationWriter but with array pooling.
/// </summary>
public class JsonSerializationWriterArrayPool : ISerializationWriter
{
    private readonly ArrayBufferWriter<byte> _bufferWriter;
    private readonly Utf8JsonWriter _writer;
    private bool _disposed;

    public JsonSerializationWriterArrayPool()
    {
        // Use ArrayBufferWriter which internally uses ArrayPool
        _bufferWriter = new ArrayBufferWriter<byte>();
        _writer = new Utf8JsonWriter(_bufferWriter, new JsonWriterOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        });
    }

    public Action<IParsable>? OnBeforeObjectSerialization { get; set; }
    public Action<IParsable>? OnAfterObjectSerialization { get; set; }
    public Action<IParsable, ISerializationWriter>? OnStartObjectSerialization { get; set; }

    public void WriteStringValue(string? key, string? value)
    {
        if (value == null) return;
        if (!string.IsNullOrEmpty(key))
            _writer.WriteString(key, value);
        else
            _writer.WriteStringValue(value);
    }

    public void WriteBoolValue(string? key, bool? value)
    {
        if (value == null) return;
        if (!string.IsNullOrEmpty(key))
            _writer.WriteBoolean(key, value.Value);
        else
            _writer.WriteBooleanValue(value.Value);
    }

    public void WriteByteValue(string? key, byte? value)
    {
        if (value == null) return;
        if (!string.IsNullOrEmpty(key))
            _writer.WriteNumber(key, value.Value);
        else
            _writer.WriteNumberValue(value.Value);
    }

    public void WriteSbyteValue(string? key, sbyte? value)
    {
        if (value == null) return;
        if (!string.IsNullOrEmpty(key))
            _writer.WriteNumber(key, value.Value);
        else
            _writer.WriteNumberValue(value.Value);
    }

    public void WriteIntValue(string? key, int? value)
    {
        if (value == null) return;
        if (!string.IsNullOrEmpty(key))
            _writer.WriteNumber(key, value.Value);
        else
            _writer.WriteNumberValue(value.Value);
    }

    public void WriteFloatValue(string? key, float? value)
    {
        if (value == null) return;
        if (!string.IsNullOrEmpty(key))
            _writer.WriteNumber(key, value.Value);
        else
            _writer.WriteNumberValue(value.Value);
    }

    public void WriteDoubleValue(string? key, double? value)
    {
        if (value == null) return;
        if (!string.IsNullOrEmpty(key))
            _writer.WriteNumber(key, value.Value);
        else
            _writer.WriteNumberValue(value.Value);
    }

    public void WriteDecimalValue(string? key, decimal? value)
    {
        if (value == null) return;
        if (!string.IsNullOrEmpty(key))
            _writer.WriteNumber(key, value.Value);
        else
            _writer.WriteNumberValue(value.Value);
    }

    public void WriteLongValue(string? key, long? value)
    {
        if (value == null) return;
        if (!string.IsNullOrEmpty(key))
            _writer.WriteNumber(key, value.Value);
        else
            _writer.WriteNumberValue(value.Value);
    }

    public void WriteGuidValue(string? key, Guid? value)
    {
        if (value == null) return;
        if (!string.IsNullOrEmpty(key))
            _writer.WriteString(key, value.Value);
        else
            _writer.WriteStringValue(value.Value);
    }

    public void WriteDateTimeOffsetValue(string? key, DateTimeOffset? value)
    {
        if (value == null) return;
        if (!string.IsNullOrEmpty(key))
            _writer.WriteString(key, value.Value);
        else
            _writer.WriteStringValue(value.Value);
    }

    public void WriteTimeSpanValue(string? key, TimeSpan? value)
    {
        if (value == null) return;
        var stringValue = value.Value.ToString();
        if (!string.IsNullOrEmpty(key))
            _writer.WriteString(key, stringValue);
        else
            _writer.WriteStringValue(stringValue);
    }

    public void WriteDateValue(string? key, Date? value)
    {
        if (value == null) return;
        var stringValue = value.Value.ToString();
        if (!string.IsNullOrEmpty(key))
            _writer.WriteString(key, stringValue);
        else
            _writer.WriteStringValue(stringValue);
    }

    public void WriteTimeValue(string? key, Time? value)
    {
        if (value == null) return;
        var stringValue = value.Value.ToString();
        if (!string.IsNullOrEmpty(key))
            _writer.WriteString(key, stringValue);
        else
            _writer.WriteStringValue(stringValue);
    }

    public void WriteNullValue(string? key)
    {
        if (!string.IsNullOrEmpty(key))
            _writer.WriteNull(key);
        else
            _writer.WriteNullValue();
    }

    public void WriteObjectValue<T>(string? key, T? value, params IParsable?[] additionalValuesToMerge) where T : IParsable
    {
        var filteredAdditionalValuesToMerge = (IParsable[])Array.FindAll(additionalValuesToMerge, static x => x is not null);
        if(value != null || filteredAdditionalValuesToMerge.Length > 0)
        {
            // Check if serializing UntypedNode
            var serializingUntypedNode = value is UntypedNode;
            if(!serializingUntypedNode && !string.IsNullOrEmpty(key))
                _writer.WritePropertyName(key);
            
            if(value != null)
                OnBeforeObjectSerialization?.Invoke(value);

            if(serializingUntypedNode)
            {
                var untypedNode = value as UntypedNode;
                OnStartObjectSerialization?.Invoke(untypedNode!, this);
                WriteUntypedValue(key, untypedNode);
                OnAfterObjectSerialization?.Invoke(untypedNode!);
            }
            else
            {
                _writer.WriteStartObject();
                if(value != null)
                {
                    OnStartObjectSerialization?.Invoke(value, this);
                    value.Serialize(this);
                }
                foreach(var additionalValueToMerge in filteredAdditionalValuesToMerge)
                {
                    OnBeforeObjectSerialization?.Invoke(additionalValueToMerge!);
                    OnStartObjectSerialization?.Invoke(additionalValueToMerge!, this);
                    additionalValueToMerge!.Serialize(this);
                    OnAfterObjectSerialization?.Invoke(additionalValueToMerge);
                }
                _writer.WriteEndObject();
            }
            if(value != null)
                OnAfterObjectSerialization?.Invoke(value);
        }
    }

    public void WriteCollectionOfObjectValues<T>(string? key, IEnumerable<T>? values) where T : IParsable
    {
        if (values == null) return;

        if (!string.IsNullOrEmpty(key))
            _writer.WritePropertyName(key);

        _writer.WriteStartArray();
        foreach (var item in values)
        {
            WriteObjectValue(null, item);
        }
        _writer.WriteEndArray();
    }

    public void WriteCollectionOfPrimitiveValues<T>(string? key, IEnumerable<T>? values)
    {
        if (values == null) return;

        if (!string.IsNullOrEmpty(key))
            _writer.WritePropertyName(key);

        _writer.WriteStartArray();
        foreach (var item in values)
        {
            WriteAnyValue(null, item);
        }
        _writer.WriteEndArray();
    }

    public void WriteCollectionOfEnumValues<T>(string? key, IEnumerable<T?>? values) where T : struct, Enum
    {
        if (values == null) return;

        if (!string.IsNullOrEmpty(key))
            _writer.WritePropertyName(key);

        _writer.WriteStartArray();
        foreach (var item in values)
        {
            if (item.HasValue)
                _writer.WriteStringValue(item.Value.ToString());
        }
        _writer.WriteEndArray();
    }

    public void WriteEnumValue<T>(string? key, T? value) where T : struct, Enum
    {
        if (value == null) return;
        var stringValue = value.Value.ToString();
        if (!string.IsNullOrEmpty(key))
            _writer.WriteString(key, stringValue);
        else
            _writer.WriteStringValue(stringValue);
    }

    public void WriteByteArrayValue(string? key, byte[]? value)
    {
        if (value == null) return;
        var base64 = Convert.ToBase64String(value);
        if (!string.IsNullOrEmpty(key))
            _writer.WriteString(key, base64);
        else
            _writer.WriteStringValue(base64);
    }

    public void WriteAdditionalData(IDictionary<string, object>? value)
    {
        if (value == null) return;
        foreach (var item in value)
        {
            WriteAnyValue(item.Key, item.Value);
        }
    }

    private void WriteAnyValue(string? key, object? value)
    {
        if (value == null)
        {
            WriteNullValue(key);
            return;
        }

        switch (value)
        {
            case string s:
                WriteStringValue(key, s);
                break;
            case bool b:
                WriteBoolValue(key, b);
                break;
            case byte by:
                WriteByteValue(key, by);
                break;
            case sbyte sby:
                WriteSbyteValue(key, sby);
                break;
            case int i:
                WriteIntValue(key, i);
                break;
            case long l:
                WriteLongValue(key, l);
                break;
            case float f:
                WriteFloatValue(key, f);
                break;
            case double d:
                WriteDoubleValue(key, d);
                break;
            case decimal dec:
                WriteDecimalValue(key, dec);
                break;
            case Guid g:
                WriteGuidValue(key, g);
                break;
            case DateTimeOffset dto:
                WriteDateTimeOffsetValue(key, dto);
                break;
            case TimeSpan ts:
                WriteTimeSpanValue(key, ts);
                break;
            case UntypedNode node:
                WriteUntypedValue(key, node);
                break;
            case IParsable p:
                WriteObjectValue(key, p);
                break;
            default:
                throw new InvalidOperationException($"Unsupported type: {value.GetType()}");
        }
    }

    /// <summary>
    /// Writes a untyped value for the specified key.
    /// </summary>
    /// <param name="key">The key to be used for the written value. May be null.</param>
    /// <param name="value">The untyped node.</param>
    private void WriteUntypedValue(string? key, UntypedNode? value)
    {
        switch(value)
        {
            case UntypedString untypedString:
                WriteStringValue(key, untypedString.GetValue());
                break;
            case UntypedBoolean untypedBoolean:
                WriteBoolValue(key, untypedBoolean.GetValue());
                break;
            case UntypedInteger untypedInteger:
                WriteIntValue(key, untypedInteger.GetValue());
                break;
            case UntypedLong untypedLong:
                WriteLongValue(key, untypedLong.GetValue());
                break;
            case UntypedDecimal untypedDecimal:
                WriteDecimalValue(key, untypedDecimal.GetValue());
                break;
            case UntypedFloat untypedFloat:
                WriteFloatValue(key, untypedFloat.GetValue());
                break;
            case UntypedDouble untypedDouble:
                WriteDoubleValue(key, untypedDouble.GetValue());
                break;
            case UntypedObject untypedObject:
                WriteUntypedObject(key, untypedObject);
                break;
            case UntypedArray array:
                WriteUntypedArray(key, array);
                break;
            case UntypedNull:
                WriteNullValue(key);
                break;
        }
    }

    /// <summary>
    /// Write a untyped object for the specified key.
    /// </summary>
    /// <param name="key">The key to be used for the written value. May be null.</param>
    /// <param name="value">The untyped object.</param>
    private void WriteUntypedObject(string? key, UntypedObject? value)
    {
        if(value != null)
        {
            if(!string.IsNullOrEmpty(key))
                _writer.WritePropertyName(key);
            _writer.WriteStartObject();
            foreach(var item in value.GetValue())
                WriteUntypedValue(item.Key, item.Value);
            _writer.WriteEndObject();
        }
    }

    /// <summary>
    /// Writes the specified collection of untyped values.
    /// </summary>
    /// <param name="key">The key to be used for the written value. May be null.</param>
    /// <param name="array">The collection of untyped values.</param>
    private void WriteUntypedArray(string? key, UntypedArray? array)
    {
        if(array != null)
        {
            if(!string.IsNullOrEmpty(key))
                _writer.WritePropertyName(key);
            _writer.WriteStartArray();
            foreach(var item in array.GetValue())
                WriteUntypedValue(null, item);
            _writer.WriteEndArray();
        }
    }

    public Stream GetSerializedContent()
    {
        _writer.Flush();
        // Convert ArrayBufferWriter to MemoryStream
        var buffer = _bufferWriter.WrittenMemory;
        return new MemoryStream(buffer.ToArray());
    }

    public void Dispose()
    {
        if (_disposed) return;
        _writer?.Dispose();
        _disposed = true;
        GC.SuppressFinalize(this);
    }
}
