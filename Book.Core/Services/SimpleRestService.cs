using System;
using System.IO;
using System.Net;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;

namespace Books.Core.Services
{
    public class SimpleRestService
        : ISimpleRestService
    {
        private readonly IMvxJsonConverter _jsonConverter;

        public SimpleRestService(IMvxJsonConverter jsonConverter)
        {
            _jsonConverter = jsonConverter;
        }

        public void MakeRequest<T>(string requestUrl, string verb, Action<T> successAction, Action<Exception> errorAction)
        {
            var request = (HttpWebRequest)WebRequest.Create(requestUrl);
            request.Method = verb;
            request.Accept = "application/json";

            MakeRequest(
               request,
               (response) =>
               {
                   if (successAction != null)
                   {
                       T toReturn;
                       try
                       {
                           toReturn = Deserialize<T>(response);
                       }
                       catch (Exception ex)
                       {
                           errorAction(ex);
                           return;
                       }
                       successAction(toReturn);
                   }
               },
               (error) =>
               {
                   if (errorAction != null)
                   {
                       errorAction(error);
                   }
               }
            );
        }

        public void MakeRequest2<T>(string requestUrl, string verb, Action<T> successAction, Action<Exception> errorAction)
        {
            var request = (HttpWebRequest)WebRequest.Create(requestUrl);
            request.Method = verb;
            request.Accept = "application/json";

            MakeRequest2(
               request,
               (response) =>
               {
                   if (successAction != null)
                   {
                       T toReturn;
                       try
                       {
                           toReturn = Deserialize<T>(response);
                       }
                       catch (Exception ex)
                       {
                           errorAction(ex);
                           return;
                       }
                       successAction(toReturn);
                   }
               },
               (error) =>
               {
                   if (errorAction != null)
                   {
                       errorAction(error);
                   }
               }
            );
        }

        private void MakeRequest(HttpWebRequest request, Action<string> successAction, Action<Exception> errorAction)
        {
            /*request.BeginGetResponse(token =>
            {
                try
                {
                    using (var response = request.EndGetResponse(token))
                    {
                        using (var stream = response.GetResponseStream())
                        {
                            var reader = new StreamReader(stream);
                            successAction(reader.ReadToEnd());
                        }
                    }
                }
                catch (WebException ex)
                {
                    Mvx.Error("ERROR: '{0}' when making {1} request to {2}", ex.Message, request.Method, request.RequestUri.AbsoluteUri);
                    errorAction(ex);
                }
            }, null);*/

            successAction(@"{'kind':'books#volumes','totalItems':2,'items':[{'kind':'books#volume','id':'xk45AQAAIAAJ','etag':'VkGyv+WowHw','selfLink':'https://www.googleapis.com/books/v1/volumes/xk45AQAAIAAJ','volumeInfo':{'title':'International Piano Quarterly','subtitle':'IPQ.','publishedDate':'2001','industryIdentifiers':[{'type':'OTHER','identifier':'STANFORD:36105111060161'}],'readingModes':{'text':false,'image':false},'printType':'BOOK','categories':['Piano music'],'maturityRating':'NOT_MATURE','allowAnonLogging':false,'contentVersion':'preview-1.0.0','imageLinks':{'smallThumbnail':'http://books.google.com.ua/books/content?id=xk45AQAAIAAJ&printsec=frontcover&img=1&zoom=5&source=gbs_api','thumbnail':'http://books.google.com.ua/books/content?id=xk45AQAAIAAJ&printsec=frontcover&img=1&zoom=1&source=gbs_api'},'language':'en','previewLink':'http://books.google.com.ua/books?id=xk45AQAAIAAJ&q=Igor+Swann12&dq=Igor+Swann12&hl=&cd=1&source=gbs_api','infoLink':'http://books.google.com.ua/books?id=xk45AQAAIAAJ&dq=Igor+Swann12&hl=&source=gbs_api','canonicalVolumeLink':'http://books.google.com.ua/books/about/International_Piano_Quarterly.html?hl=&id=xk45AQAAIAAJ'},'saleInfo':{'country':'UA','saleability':'NOT_FOR_SALE','isEbook':false},'accessInfo':{'country':'UA','viewability':'NO_PAGES','embeddable':false,'publicDomain':false,'textToSpeechPermission':'ALLOWED','epub':{'isAvailable':false},'pdf':{'isAvailable':false},'webReaderLink':'http://books.google.com.ua/books/reader?id=xk45AQAAIAAJ&hl=&printsec=frontcover&output=reader&source=gbs_api','accessViewStatus':'NONE','quoteSharingAllowed':false},'searchInfo':{'textSnippet':'... Ponti ^Bernard Ringeissen (12 Konstantin Scherbakov) i \u003cb\u003eIgor\u003c/b\u003e Shukov 2 Abbey \u003cbr\u003e\nSimon 1 7 Ronald Smith 5 Trefor Smith 3 ... Speidel a g Kathryn Stott n-Vladimir \u003cbr\u003e\nStoupel effrey \u003cb\u003eSwann 12\u003c/b\u003e Tal &amp; Groethuysen 2-Claudius Tanski io Franz Vorraber\u003cbr\u003e\n&nbsp;...'}},{'kind':'books#volume','id':'xNtBAQAAIAAJ','etag':'ixKYDSugIZU','selfLink':'https://www.googleapis.com/books/v1/volumes/xNtBAQAAIAAJ','volumeInfo':{'title':'German books in print','publishedDate':'1978','industryIdentifiers':[{'type':'OTHER','identifier':'STANFORD:36105026194063'}],'readingModes':{'text':false,'image':false},'printType':'BOOK','categories':['Austria'],'maturityRating':'NOT_MATURE','allowAnonLogging':false,'contentVersion':'0.0.1.0.preview.0','imageLinks':{'smallThumbnail':'http://books.google.com.ua/books/content?id=xNtBAQAAIAAJ&printsec=frontcover&img=1&zoom=5&source=gbs_api','thumbnail':'http://books.google.com.ua/books/content?id=xNtBAQAAIAAJ&printsec=frontcover&img=1&zoom=1&source=gbs_api'},'language':'de','previewLink':'http://books.google.com.ua/books?id=xNtBAQAAIAAJ&q=Igor+Swann12&dq=Igor+Swann12&hl=&cd=2&source=gbs_api','infoLink':'http://books.google.com.ua/books?id=xNtBAQAAIAAJ&dq=Igor+Swann12&hl=&source=gbs_api','canonicalVolumeLink':'http://books.google.com.ua/books/about/German_books_in_print.html?hl=&id=xNtBAQAAIAAJ'},'saleInfo':{'country':'UA','saleability':'NOT_FOR_SALE','isEbook':false},'accessInfo':{'country':'UA','viewability':'NO_PAGES','embeddable':false,'publicDomain':false,'textToSpeechPermission':'ALLOWED','epub':{'isAvailable':false},'pdf':{'isAvailable':false},'webReaderLink':'http://books.google.com.ua/books/reader?id=xNtBAQAAIAAJ&hl=&printsec=frontcover&output=reader&source=gbs_api','accessViewStatus':'NONE','quoteSharingAllowed':false},'searchInfo':{'textSnippet':'10,80 (3-5 18-01016-6) [сЩТШ [A-Ml 1 7 Ramuz, Chartas F: Erinnerungen an \u003cbr\u003e\n\u003cb\u003eIgor\u003c/b\u003e Stravinsky. 8,60 (3-518-0 101 ..... Brudzinski, Wieslaw: Die rote Katz. 7,80 (3-\u003cbr\u003e\n518-01266-5) ЕЯ lA-Mi Bibliothek 267 Proust, Marcel: Eine Liebe von \u003cb\u003eSwann. 12\u003c/b\u003e\u003cbr\u003e\n&nbsp;...'}}]}");
        }

        private void MakeRequest2(HttpWebRequest request, Action<string> successAction, Action<Exception> errorAction)
        {
            successAction(@"{'kind':'books#volume','id':'xk45AQAAIAAJ','etag':'caEmuGgUNjY','selfLink':'https://www.googleapis.com/books/v1/volumes/xk45AQAAIAAJ','volumeInfo':{'title':'International Piano Quarterly','subtitle':'IPQ.','publisher':'Gramophone Publications','publishedDate':'2001','readingModes':{'text':false,'image':false},'pageCount':774,'printedPageCount':774,'dimensions':{'height':'21.00 cm'},'printType':'BOOK','maturityRating':'NOT_MATURE','allowAnonLogging':false,'contentVersion':'preview-1.0.0','imageLinks':{'smallThumbnail':'http://books.google.com.ua/books/content?id=xk45AQAAIAAJ&printsec=frontcover&img=1&zoom=5&imgtk=AFLRE71bE7XF260peQ2zNRMOm8ZuOaVrHQRheCOoc-iJJD7xOxUMgRXDsRXRWfCJyp0QVyFHv8TjJP7dbg9OK-qYB8oVUJNpQqlxey1zoxwt6N1RblVOJ1Q&source=gbs_api','thumbnail':'http://books.google.com.ua/books/content?id=xk45AQAAIAAJ&printsec=frontcover&img=1&zoom=1&imgtk=AFLRE70EBsc1ApP9OBtViIORC0n1ko_xJPQUkslH35b9ERAB6gnogqHYMljOHDaSbJgPyi9gpjSh7ZzHHuGc3P-8ZmTgPnGJULb9qAq5BsFZucvzsK-nHrY&source=gbs_api'},'language':'en','previewLink':'http://books.google.com.ua/books?id=xk45AQAAIAAJ&hl=&source=gbs_api','infoLink':'http://books.google.com.ua/books?id=xk45AQAAIAAJ&hl=&source=gbs_api','canonicalVolumeLink':'http://books.google.com.ua/books/about/International_Piano_Quarterly.html?hl=&id=xk45AQAAIAAJ'},'saleInfo':{'country':'UA','saleability':'NOT_FOR_SALE','isEbook':false},'accessInfo':{'country':'UA','viewability':'NO_PAGES','embeddable':false,'publicDomain':false,'textToSpeechPermission':'ALLOWED','epub':{'isAvailable':false},'pdf':{'isAvailable':false},'webReaderLink':'http://books.google.com.ua/books/reader?id=xk45AQAAIAAJ&hl=&printsec=frontcover&output=reader&source=gbs_api','accessViewStatus':'NONE','quoteSharingAllowed':false}}");
        }

        private T Deserialize<T>(string responseBody)
        {
            var toReturn = _jsonConverter.DeserializeObject<T>(responseBody);
            return toReturn;
        }
    }
}
