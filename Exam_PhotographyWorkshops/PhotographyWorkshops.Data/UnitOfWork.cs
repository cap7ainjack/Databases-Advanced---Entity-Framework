using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDeffect.Data
{
    using PhotographyWorkshops.Data;
    using PhotographyWorkshops.Data.Interfaces;
    using PhotographyWorkshops.Models;

    public class UnitOfWork : IUnitOfWork
    {
        private PhotographyWorkshopsContext context;
        private IRepository<Len> lens;
        private IRepository<Camera> cameras;
        private IRepository<Accessory> accessories;
        private IRepository<Photographer> photographers;
        private IRepository<Workshop> workshops;

        public UnitOfWork()
        {
            this.context = new PhotographyWorkshopsContext();
        }

        public IRepository<Len> Lenses => this.lens ?? (this.lens = new Repository<Len>(this.context.Lens));

        public IRepository<Camera> Cameras => this.cameras ?? (this.cameras = new Repository<Camera>(this.context.Cameras));

        public IRepository<Accessory> Accessories => this.accessories ?? (this.accessories = new Repository<Accessory>(this.context.Accessories));

        public IRepository<Photographer> Photographers => this.photographers ?? (this.photographers = new Repository<Photographer>(this.context.Photographers));

        public IRepository<Workshop> Workshops => this.workshops ?? (this.workshops = new Repository<Workshop>(this.context.Workshops));

        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}
