using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using NetBooksMVC.Src.Constants;
using NetBooksMVC.Src.DTOs;
using NetBooksMVC.Src.Shared.Errors;
using NetBooksMVC.Src.Shared.Extensions;
using NetBooksMVC.Src.Shared.Handlers;

namespace NetBooksMVC.Src.Services
{
    public class GoogleBooksService
    {
        private readonly string _baseUrl = "https://www.googleapis.com";
        private readonly string _route = "books/v1/volumes";
        private readonly string apiKey = "";

        private SearchBookParams paramters = SearchBookParams.INTITLE;

        public GoogleBooksService()
        {
            apiKey = Environment.GetEnvironmentVariable("APIKEY");
        }

        public async Task<DefaultResult<GoogleBookDTO>> SearchBooks(SearchBookParams searchParams, string searchValue)
        {
            paramters = searchParams;
            string searchUriParam = paramters.ToLowerCaseString();
            string valueUriParam = Uri.EscapeDataString(searchValue);
            DefaultResult<GoogleBookDTO> result;
            HttpClient httpClient = new HttpClient();
            UriBuilder uriBuilder = new UriBuilder(_baseUrl)
            {
                Path = _route,
                Query = $"q={searchUriParam}:{valueUriParam}&key={apiKey}"
            };

            var response = await httpClient.GetAsync(uriBuilder.Uri);
            var jsonString = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonSerializer.Deserialize<GoogleBookDTO>(jsonString);

            if (response.IsSuccessStatusCode)
            {
                result = new DefaultResult<GoogleBookDTO>(jsonObject);
            }
            else
            {
                result = new DefaultResult<GoogleBookDTO>(new DefaultError("Erro ao buscar livro"), jsonObject);
            }

            return result;

        }


    }
}