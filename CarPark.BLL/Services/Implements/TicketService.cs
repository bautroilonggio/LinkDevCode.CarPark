using AutoMapper;
using CarPark.DAL;
using CarPark.DAL.Entities;
using CarPark.DAL.Models;

namespace CarPark.BLL.Services
{
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TicketService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ??
                throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<TicketDto>> GetTicketsAsync()
        {
            var ticketEntities = await _unitOfWork.TicketRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TicketDto>>(ticketEntities);
        }

        public async Task<TicketDto?> GetTicketAsync(int ticketId)
        {
            var ticketEntity = await _unitOfWork.TicketRepository.GetSingleAsync(ticketId);

            if (ticketEntity == null)
            {
                return null;
            }

            return _mapper.Map<TicketDto>(ticketEntity);
        }

        public async Task<TicketDto> CreateTicketAsync(TicketFroCreateDto ticket)
        {
            var tripEntity = await _unitOfWork.TripRepository
                                    .GetSingleConditionsAsync(trip => trip.Destination == ticket.Destination);
            ticket.TripId = tripEntity.TripId;

            var ticketEntity = _mapper.Map<Ticket>(ticket);

            _unitOfWork.TicketRepository.Add(ticketEntity);

            await _unitOfWork.ComitAsync();

            return _mapper.Map<TicketDto>(ticketEntity);
        }

        public async Task<bool> DeleteTicketAsync(int ticketId)
        {
            var ticketEntity = await _unitOfWork.TicketRepository.GetSingleAsync(ticketId);

            if (ticketEntity == null)
            {
                return false;
            }

            _unitOfWork.TicketRepository.Delete(ticketEntity);

            await _unitOfWork.ComitAsync();

            return true;
        }
    }
}