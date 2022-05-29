﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using JOSHttpClient.Common;
using Utf8Json;
using Utf8Json.Resolvers;

namespace JOSHttpClient.Version10
{
    public class GitHubClient : IGitHubClient
    {
        private readonly HttpClient _httpClient;
        // private readonly Utf8JsonSerializer _jsonSerializer;

        // public GitHubClient(HttpClient httpClient, Utf8JsonSerializer jsonSerializer)
        public GitHubClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            // _jsonSerializer = jsonSerializer ?? throw new ArgumentNullException(nameof(jsonSerializer));
        }

        public async Task<IReadOnlyCollection<GitHubRepositoryDto>> GetRepositories(CancellationToken cancellationToken)
        {
            var request = CreateRequest();
            // using (var st = File.OpenRead("./repositories.10.json"))
            // {
            //     using (var sr = new StreamReader(st, System.Text.Encoding.UTF8))
            //     {
            //         Console.WriteLine("length: {0}", st.Length);
            //         return await this._jsonSerializer.DeserializeAsync<List<GitHubRepositoryDto>>(st);
            //     }
            // }
            using (var result = await _httpClient
                       .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                       .ConfigureAwait(false))
            {
                using (var contentStream = await result.Content.ReadAsStreamAsync())
                {
                    return await JsonSerializer.DeserializeAsync<List<GitHubRepositoryDto>>(contentStream,
                        StandardResolver.CamelCase);
                }
            }
        }

        private static HttpRequestMessage CreateRequest()
        {
            return new HttpRequestMessage(HttpMethod.Get, GitHubConstants.RepositoriesPath);
        }

        private static async Task<string> StreamToStringAsync(Stream stream)
        {
            string content = null;

            if (stream != null)
                using (var sr = new StreamReader(stream))
                    content = await sr.ReadToEndAsync();

            return content;
        }
    }
}