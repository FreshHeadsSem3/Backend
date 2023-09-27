using FreshHeadBackend.Business;

namespace FreshHeadBackend.Interfaces
{
    public interface IDealRepository
    {
        Deal CreateDeal(Deal dealEntity);
        void Save();
        void Save(bool acceptChangesOnSuccess);
    }
}