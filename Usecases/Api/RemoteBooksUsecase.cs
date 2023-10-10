using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetBooksMVC.Src.Constants;
using NetBooksMVC.Src.DTOs;
using NetBooksMVC.Src.Services;
using NetBooksMVC.Src.Shared.Handlers;

namespace NetBooksMVC.Usecases.Api
{
    public class RemoteBooksUsecase
    {
        private readonly GoogleBooksService _service;

        public RemoteBooksUsecase(GoogleBooksService service)
        {
            _service = service;
        }

        public async Task<DefaultResult<GoogleBookDTO>> GetRemoteBooks(SearchBookParams searchParams = SearchBookParams.INTITLE, string searchValue = "")
        {
            return await _service.SearchBooks(searchParams, searchValue);
        }
    }
}