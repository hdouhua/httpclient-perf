﻿using System.Text.Json;

namespace JOSHttpClient.Version9
{
    public static class DefaultJsonSerializerOptions
    {
        public static JsonSerializerOptions Options => new JsonSerializerOptions {PropertyNameCaseInsensitive = true};
    }
}
