namespace JwtWAspNetCore.Services.Interfaces
{
    using System.Collections.Generic;
    using JwtWAspNetCore.Domain;

    public interface IPartnerRepository
    {
        IEnumerable<Socio> GetPartners();
        Socio GetPartnerById(int idPartner);
        Socio CreatePartner(Socio socio);
        Socio UpdatePartner(Socio socio);
        void DeletePartnet(Socio socio);
    }
}
