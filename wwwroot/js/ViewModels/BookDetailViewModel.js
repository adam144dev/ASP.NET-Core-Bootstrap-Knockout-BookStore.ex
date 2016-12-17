function BookDetailViewModel(model) {
    var self = this;
    self.cartItem = {
        cartId: cartSummaryViewModel.cart.id,   // TBD: not declared globally !
        quantity: ko.observable(1),
        book: model
    };
};
