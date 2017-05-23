namespace Dgi.Host.Controllers
{
    public static class DgiResponse
    {
        public static DgiResponse<object> Tom
        {
            get { return new DgiResponse<object>(new object()); }
        }
    }

    public class DgiResponse<T>
    {
        public T Data;

        public DgiResponse(T data)
        {
            Data = data;
        }
    }
}