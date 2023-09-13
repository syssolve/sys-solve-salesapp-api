using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EdgeProjectPe.DB.Entities;
using EdgeProjectPe.Services.DTO;

namespace EdgeProjectPe.Services.Mapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration() { 
        
            CreateMap<User,UserDTO>();
            CreateMap<UserDTO,User>();

            CreateMap<CompanyDTO,Company>();
            CreateMap<Company, CompanyDTO>();

            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();

            CreateMap<SaleDTO, Sale>();
            CreateMap<Sale, SaleDTO>();

            CreateMap<Saleinvoice, SaleInvoiceDTO>();
            CreateMap<SaleInvoiceDTO, Saleinvoice>();

            CreateMap<Unit, UnitDTO>();
            CreateMap<UnitDTO, Unit>();

            CreateMap<Parameter, ParameterDTO>();
            CreateMap<ParameterDTO, Parameter>();

            CreateMap<Invoice, InvoiceDTO>();
            CreateMap<InvoiceDTO, Invoice>();

            CreateMap<Usertype, UserTypeDTO>();
            CreateMap<UserTypeDTO, Usertype>();
        }
    }
}
