﻿using System.Text.Json.Serialization;

namespace OpenClickBank.Builder.Models;

public class ImageListResult
{
    public ImageList ImageList { get; set; } = null!;

    [JsonPropertyName("total_record_count")]
    public int TotalRecordCount { get; set; }
}