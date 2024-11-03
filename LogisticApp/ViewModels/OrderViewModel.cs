namespace LogisticApp.ViewModels
{
    public class OrderViewModel
    {
        public string SenderCityName {  get; set; }
        public string SenderFullInCityAddress {  get; set; }

        public string RecipientCityName { get; set; }
        public string RecipientFullInCityAddress { get; set; }

        public DateTime CreationDtm { get; set; }
        public float CargoWeightInKilograms { get; set; }

    }

}
