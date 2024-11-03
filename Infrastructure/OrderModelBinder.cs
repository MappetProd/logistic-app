/*using LogisticApp.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace LogisticApp.Infrastructure
{
    public class OrderModelBinder : IModelBinder
    {
        private readonly IModelBinder _binder;
        public OrderModelBinder(IModelBinder binder)
        {
            _binder = binder;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            ValueProviderResult senderFullInCityAddress = bindingContext.ValueProvider.GetValue("sender_address");

            Dictionary<string, string> senderAddressComponents = Address.SplitInCityAddressString(senderFullInCityAddress);

            ValueProviderResult recipientFullAddress = bindingContext.ValueProvider.GetValue("recipient_address");
            Dictionary<string, string> recipientAddressComponents = Address.SplitInCityAddressString(recipientFullAddress);

            Postcode senderPostcode = _context.Postcodes.Single(pc => pc.Code == senderAddressComponents["postcode"]);
            Postcode recipientPostcode = _context.Postcodes.Single(pc => pc.Code == recipientAddressComponents["postcode"]);

            Address senderAddress = new Address(senderPostcode, senderAddressComponents["house"]);
            Address recipientAddress = new Address(recipientPostcode, recipientAddressComponents["house"]);

            ValueProviderResult orderCreationDtm = bindingContext.ValueProvider.GetValue("order_creation_dtm");
            ValueProviderResult cargoWeightInKilos = bindingContext.ValueProvider.GetValue("cargo_weight");

            DateTime.TryParse(orderCreationDtm.FirstValue, out DateTime parsedOrderCreationDtm);
            int cargoWeightInGrams = int.Parse(cargoWeightInKilos.FirstValue) * 1000;

            Order result = new Order
            {
                SenderAdress = senderAddress,
                RecipientAddress = recipientAddress,
                CreationDtm = parsedOrderCreationDtm,
                CargoWeightInGrams = cargoWeightInGrams
            };

            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }
    }
}
*/