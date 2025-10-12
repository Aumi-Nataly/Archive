using Archive.Domain.Models;
using Archive.Infrastructure.Repository;
using ArchiveContracts;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.Infrastructure.RabbitMQ.Consumers
{
    public class ArchiveCreatedConsumer : IConsumer<ArchiveCreated>
    {
        private readonly IArchiveRepository _repository;
        public ArchiveCreatedConsumer(IArchiveRepository repository)
        {
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<ArchiveCreated> context)
        {
            try
            {
                var message = context.Message;

                var record = new ArchivedRecord 
                {
                    ActivityKey = message.ActivityKey,
                    Name = message.Name,
                    Reason = message.Reason
                };

                await _repository.AddAsync(record);
            }
            catch (Exception ex)
            {            
                throw;
            }
        }

    }
}
