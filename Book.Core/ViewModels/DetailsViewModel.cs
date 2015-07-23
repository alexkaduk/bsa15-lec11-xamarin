using Books.Core.Services;
using Cirrious.MvvmCross.ViewModels;

namespace Books.Core.ViewModels
{
    /// <summary>
    /// TODO implement Details view model to download and hold detail information about the book
    /// Also you need to implement views for each platform for this model
    /// </summary>
    public class DetailsViewModel 
        : MvxViewModel
    {
        private readonly IBooksService _books;
        public BookSearchItem book;

        public BookSearchItem Book
        {get
            { return book; }
            set { book = value; RaisePropertyChanged(() => Book); }
        }

        public DetailsViewModel(IBooksService books)
        {
            _books = books;
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            // TODO get and cast incomming bundle to the parameter passed from FirstViewModel
            // details here
            // https://github.com/MvvmCross/MvvmCross/wiki/ViewModel--to-ViewModel-navigation

            var bookId = parameters.Data["BookId"];

            _books.StartSearchBookAsync(bookId,
                result => Book = result,
                error => { });

            base.InitFromBundle(parameters);
        }
    }
}
