using System;

namespace Books.Core.Services
{
    public class BooksService
        : IBooksService
    {
        private readonly ISimpleRestService _simpleRestService;

        public BooksService(ISimpleRestService simpleRestService)
        {
            _simpleRestService = simpleRestService;
        }

        public void StartSearchAsync(string whatFor, Action<BookSearchResult> success, Action<Exception> error)
        {
            string address = string.Format("https://www.googleapis.com/books/v1/volumes?q={0}",
                                            Uri.EscapeDataString(whatFor));
            _simpleRestService.MakeRequest<BookSearchResult>(address,
                "GET", success, error);
        }

        public void StartSearchBookAsync(string bookId, Action<BookSearchItem> success, Action<Exception> error)
        {
            string address = string.Format("https://www.googleapis.com/books/v1/volumes/{0}",
                                            Uri.EscapeDataString(bookId));
            _simpleRestService.MakeRequest2<BookSearchItem>(address,
                "GET", success, error);
        }
    }
}
