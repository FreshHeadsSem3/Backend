namespace FreshHeadBackend.Interfaces
{
    public interface IKvKService
    {
        Task<bool> VerifyKvKNumber(string kNumber);
    }
}