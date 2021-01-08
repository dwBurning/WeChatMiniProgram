// page/component/orders/orders.js
const app = getApp();

Page({
  data: {
    address: {},
    hasAddress: false,
    total: 0,
    orders: []
  },

  onReady() {
    this.getTotalPrice();
  },

  onShow: function() {
    const self = this;
    wx.getStorage({
      key: 'address',
      success(res) {
        self.setData({
          address: res.data,
          hasAddress: true
        })
      }
    });
    self.setData({
      orders: app.globalData.carts
    });
  },

  /**
   * 计算总价
   */
  getTotalPrice() {
    let orders = this.data.orders;
    let total = 0;
    for (let i = 0; i < orders.length; i++) {
      total += orders[i].Count * orders[i].Menu.Price;
    }
    this.setData({
      total: total
    })
  },

  toPay() {
    wx.showModal({
      title: '提示',
      content: '本系统只做演示，支付系统已屏蔽',
      text: 'center',
      complete() {
        wx.switchTab({
          url: '/page/component/user/user'
        })
      }
    })
  }
})