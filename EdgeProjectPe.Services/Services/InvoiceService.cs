using AutoMapper;
using EdgeProjectPe.DB.Entities;
using EdgeProjectPe.DB.Repositories.Generic;
using EdgeProjectPe.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeProjectPe.Services.Services
{
    public interface IInvoiceService
    {
        Task CreateInvoiceAsync(InvoiceDTO invoice);
        void UpdateInvoice(InvoiceDTO invoice);
        Task DeleteInvoiceAsync(int id);
        Task<InvoiceDTO> GetByIdAsync(int id);
    }
    public class InvoiceService : IInvoiceService
    {
        private readonly IGenericRepository<Invoice> _invRepository;
        private readonly IMapper _mapper;

        public InvoiceService(IGenericRepository<Invoice> InvRepository, IMapper mapper) {

            _invRepository = InvRepository;
            _mapper=mapper;
        }
        public async Task CreateInvoiceAsync(InvoiceDTO invoice)
        {
            var InvObj = _mapper.Map<Invoice>(invoice);
            await _invRepository.Insert(InvObj);
            _invRepository.Save();
        }

        public async Task DeleteInvoiceAsync(int id)
        {
            var InvObj = await _invRepository.GetById(id);
            if (InvObj != null)
            {
                await _invRepository.Delete(InvObj);
                _invRepository.Save();
            }
        }

        public async Task<InvoiceDTO> GetByIdAsync(int id)
        {
            var objSale = await _invRepository.GetById(id);
            return _mapper.Map<InvoiceDTO>(objSale);
        }

        public void UpdateInvoice(InvoiceDTO invoice)
        {
            var saleInvObj = _mapper.Map<Invoice>(invoice);
            _invRepository.Update(saleInvObj);
            _invRepository.Save();
        }
    }
}
