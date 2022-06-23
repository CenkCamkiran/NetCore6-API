namespace DotNetCoreFirstproject.Helpers.APIExceptionHelper
{
    public class APIExceptionHelper : Exception
    {

        private readonly HttpResponseMessage httpResponseMessage;
        public HttpResponseMessage HttpResponseMessage => httpResponseMessage;

        public APIExceptionHelper(HttpResponseMessage httpResponseMessage, string message, Exception ex) : base(message)
        {
            this.httpResponseMessage = httpResponseMessage;
        }

        public APIExceptionHelper(HttpResponseMessage httpResponseMessage, string message)
        {
            this.httpResponseMessage = httpResponseMessage;
        }

    }
}
