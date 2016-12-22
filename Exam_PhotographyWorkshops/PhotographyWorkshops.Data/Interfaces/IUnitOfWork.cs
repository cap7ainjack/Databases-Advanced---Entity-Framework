namespace PhotographyWorkshops.Data.Interfaces
{
    using PhotographyWorkshops.Models;

    public interface IUnitOfWork
    {

        IRepository<Camera> Cameras { get; }

        IRepository<Len> Lenses { get; }

        IRepository<Accessory> Accessories { get; }

        IRepository<Photographer> Photographers { get; }

        IRepository<Workshop> Workshops { get; }

        void Commit();
    }
}
