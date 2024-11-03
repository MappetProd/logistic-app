$(".city_input").on("focus", function () {
    $(this).autocomplete({
        source: '/OrderForm/GetSuggestedCities',
    })
})

$('.address_input').on("focus", function () {
    $(this).autocomplete({
        source: function (request, response) {
            /*console.log(this.element)
            console.log(this.element.closest('.address'));*/
            //console.log(this.element.closest('.address').find(".city_input").eq(0).val())
            $.get('/OrderForm/GetSuggestedAddresses',
                { city: this.element.closest('.address').find(".city_input").eq(0).val(), address: request.term },
                function (suggestedAddressesArr) {
                    response(suggestedAddressesArr);
                });
        }
        // [];
    })
})