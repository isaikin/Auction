namespace DaoContracts
{
    public interface IDescriptionProduct
    {
        void Add(int id, string description);

        string Get(int id);

        void Update(int id, string description);
    }
}