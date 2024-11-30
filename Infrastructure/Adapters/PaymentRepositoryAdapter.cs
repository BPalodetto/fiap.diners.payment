using Domain.Entities.PaymentAggregate;
using Domain.Repositories;
using Infrastructure.Extensions;
using Infrastructure.MongoModels.Extensions;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Adapters;

public class PaymentRepositoryAdapter : IPaymentRepository
{
    private readonly IPaymentMongoDbRepository _paymentMongoDbRepository; 
    public PaymentRepositoryAdapter(IPaymentMongoDbRepository paymentMongoDbRepository)
    {
        _paymentMongoDbRepository = paymentMongoDbRepository;
    }
    public async Task<Payment> CreateAsync(Payment order, CancellationToken cancellationToken)
    {
        var orderMongo = order.ToPaymentMongoModel();
        orderMongo = await _paymentMongoDbRepository.CreateAsync(orderMongo, cancellationToken);
        return orderMongo.ToPayment();  
    }

    public async Task UpdateAsync(Payment order, CancellationToken cancellationToken)
    {
        var orderMongo = order.ToPaymentMongoModel();
        orderMongo = await _paymentMongoDbRepository.ReplaceOneAsync(orderMongo, cancellationToken);
    }
}
