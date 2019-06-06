namespace JwtWAspNetCore.Services.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using JwtWAspNetCore.Domain;
    using JwtWAspNetCore.Services.Interfaces;

    public class PartnerRepository : IPartnerRepository
    {
        private readonly ApiContext db;

        public PartnerRepository(ApiContext db)
        {
            this.db = db;
        }

        public Socio CreatePartner(Socio socio)
        {
            db.Socios.Add(socio);
            db.SaveChanges();

            return socio;
        }

        public void DeletePartnet(Socio socio)
        {
            db.Socios.Remove(socio);
            db.SaveChanges();
        }

        public Socio GetPartnerById(int idPartner)
        {
            return db.Socios.FirstOrDefault(x => x.IdSocio == idPartner);
        }

        public IEnumerable<Socio> GetPartners()
        {
            return db.Socios.ToList();
        }

        public Socio UpdatePartner(Socio socio)
        {
            db.Entry(socio).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return socio;
        }
    }
}
