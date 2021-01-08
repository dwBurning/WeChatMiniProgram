App({
  onLaunch: function() {

  },
  globalData: {
    url: 'http://localhost:8089/api/LazyOrders',
    urlCarts: 'http://localhost:8089/api/Carts',
    urlCategory: 'http://localhost:8089/api/Category',
    urlMenu: 'http://localhost:8089/api/Menu',
    urlOrders: 'http://localhost:8089/api/Orders',
    carts: [],
    orders: [],
    sessionKey: ''
  }

})