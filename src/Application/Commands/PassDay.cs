using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Transactions;
using Domain.Entities;
using Domain.Repositories;
using MassTransit;
using MediatR;

namespace Application.Commands
{
    public static class PassDay
    {
        public class Command : IRequest
        {
        }

        internal class Handler : IRequestHandler<Command>
        {
            private readonly IPublishEndpoint _publishEndpoint;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IUniverseRepository _universeRepository;

            public Handler(IUnitOfWork unitOfWork, IUniverseRepository universeRepository, IPublishEndpoint publishEndpoint)
            {
                _unitOfWork = unitOfWork;
                _universeRepository = universeRepository;
                _publishEndpoint = publishEndpoint;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var universe = await _universeRepository.GetActive();

                if (universe == null)
                {
                    universe = new Universe(Guid.NewGuid());
                    await _universeRepository.Add(universe);
                }
                else
                {
                    universe.PassDay();
                }

                await _unitOfWork.Commit();

                foreach (var domainEvent in universe.DomainEvents)
                {
                    await _publishEndpoint.Publish(domainEvent, cancellationToken);
                }
                
                universe.ClearEvents();

                return Unit.Value;
            }
        }
    }
}