namespace JwtWAspNetCore.Controllers
{
    using System;
    using System.Net;
    using JwtWAspNetCore.Domain;
    using JwtWAspNetCore.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Authorize]
    public class PartnerController : ControllerBase
    {
        private readonly IPartnerRepository partnerRepository;

        public PartnerController(IPartnerRepository partnerRepository)
        {
            this.partnerRepository = partnerRepository;
        }

        [HttpGet("api/Partner")]
        public IActionResult GetPartners()
        {
            try
            {
                return Ok(partnerRepository.GetPartners());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("api/Partner/{idPartner}")]
        public IActionResult GetPartnerById(int idPartner)
        {
            try
            {
                return Ok(this.partnerRepository.GetPartnerById(idPartner));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("api/Partner")]
        public IActionResult CreatePartner(Socio socio)
        {
            if (socio == null)
            {
                throw new ArgumentNullException(HttpStatusCode.BadRequest.ToString(), nameof(socio));
            }

            try
            {
                partnerRepository.CreatePartner(socio);
                return Created("", socio);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("api/Partner")]
        public IActionResult UpdatePartner(Socio socio)
        {
            if (socio == null)
            {
                throw new ArgumentNullException(HttpStatusCode.BadRequest.ToString(), nameof(socio));
            }

            try
            {
                Socio partner = partnerRepository.GetPartnerById(socio.IdSocio);

                if (partner == null)
                {
                    throw new ArgumentNullException(HttpStatusCode.NotFound.ToString(), nameof(partner));
                }

                partner.Nombre = socio.Nombre;
                partnerRepository.UpdatePartner(partner);
                return Ok(socio);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("api/Partner")]
        public IActionResult DeletePartner(int idPartner)
        {
            try
            {
                Socio partner = partnerRepository.GetPartnerById(idPartner);

                if (partner == null)
                {
                    throw new ArgumentNullException(HttpStatusCode.NotFound.ToString(), nameof(partner));
                }

                partnerRepository.DeletePartnet(partner);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
