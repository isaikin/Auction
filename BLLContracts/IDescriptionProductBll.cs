namespace BllContracts
{
    public interface IDescriptionProductBll
    {
        void Add(int id, string description);

        string Get(int id);

        void Update(int idUser, int idProduct, string description);
    }
}