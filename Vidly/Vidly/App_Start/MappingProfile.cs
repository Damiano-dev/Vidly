using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Cliente, ClienteDTO>();
            Mapper.CreateMap<ClienteDTO, Cliente>().ForMember(c=>c.Id, opt=> opt.Ignore());
            Mapper.CreateMap<Film, FilmDTO>();
            Mapper.CreateMap<FilmDTO, Film>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<TipoAbbonamento, TipoAbbonamentoDTO>();
            Mapper.CreateMap<TipoAbbonamentoDTO, TipoAbbonamento>();
            Mapper.CreateMap<Genere, GenereDTO>();
            Mapper.CreateMap<GenereDTO, Genere>();
        }
    }
}