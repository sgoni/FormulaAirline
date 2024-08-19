namespace FormulaAirline.API.Services;

public interface IMessageProducer
{
    void Sendingmessage<T>(T message);
}